using System.Data;
using System.Data.OleDb;
using System.Text;

namespace OmniLifeValidationTool.Database
  {
  [System.Runtime.Versioning.SupportedOSPlatform("windows")]
  public class PremiumRepository : IPremiumRepository
    {
    private const string BLANK = "_";
    private const string SEPARATOR = "/";
    public DataTable GetDuplicates(string xsSupplierCode)
      {
      DataTable oAllPremiums = GetPremiums(xsSupplierCode);
      DataTable oDuplicates = oAllPremiums.Clone();
      Dictionary<string, DataRow> dBASKeys = new();

      for (int i = 0; i < oAllPremiums.Rows.Count; i++)
        {
        string sBasKey = GetBASKey(oAllPremiums.Rows[i]);
        if (dBASKeys.ContainsKey(sBasKey))
          {
          // original row
          oDuplicates.ImportRow(dBASKeys[sBasKey]);
          // duplicated row
          oDuplicates.ImportRow(oAllPremiums.Rows[i]);
          }
        else
          {
          dBASKeys.Add(sBasKey, oAllPremiums.Rows[i]);
          }
        }

      return oDuplicates;
      }

    public DataTable GetPremiums(string xsSupplierCode)
      {
      string sDatabaseName = $"Premiums - {xsSupplierCode}";
      string sTableName = $"Premium_{xsSupplierCode}";
      string sConnectionString = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Working\Omnium\Install\Premiums\{sDatabaseName}.accdb";

      using (OleDbConnection oConnection = new(sConnectionString))
        {
        string sQuery = $"select * from {sTableName} where FORMULA = 'BAS'";
        OleDbCommand oCommand = new(sQuery, oConnection);
        try
          {
          oConnection.Open();
          using (OleDbDataReader oReader = oCommand.ExecuteReader())
            {
            DataTable oData = new DataTable();
            oData.Load(oReader);
            return oData;
            }
          }
        catch (Exception ex)
          {
          throw new Exception(ex.Message);
          }
        }

      }

    private string GetBASKey(DataRow xoRow)
      {
      StringBuilder oSB = new StringBuilder();
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["FORMULA_CODE"].ToString()) ? xoRow["FORMULA_CODE"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["PREMIUM_TYPE"].ToString()) ? xoRow["PREMIUM_TYPE"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["GENDER"].ToString()) ? xoRow["GENDER"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["SMOKER"].ToString()) ? xoRow["SMOKER"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["MIN_AGE"].ToString()) ? xoRow["MIN_AGE"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["BENEFIT_PERIOD"].ToString()) ? xoRow["BENEFIT_PERIOD"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["WAITING_PERIOD"].ToString()) ? xoRow["WAITING_PERIOD"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["FREQUENCY"].ToString()) ? xoRow["FREQUENCY"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["BUYBACK"].ToString()) ? xoRow["BUYBACK"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["DOUBLE"].ToString()) ? xoRow["DOUBLE"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["OWNANY"].ToString()) ? xoRow["OWNANY"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["ICB"].ToString()) ? xoRow["ICB"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["ABO"].ToString()) ? xoRow["ABO"] : BLANK).Append(SEPARATOR);
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow["CLASS"].ToString()) ? xoRow["CLASS"] : BLANK).Append(SEPARATOR);
      return oSB.ToString();
      }


    }
  }
