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
      StringBuilder oSB = new();
      Dictionary<string, DataRow> dBASKeys = new();

      DataTable oAllPremiums = GetPremiums(xsSupplierCode);
      DataTable oDuplicates = oAllPremiums.Clone();
      

      for (int i = 0; i < oAllPremiums.Rows.Count; i++)
        {
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["FORMULA_CODE"].ToString()) ? oAllPremiums.Rows[i]["FORMULA_CODE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["PREMIUM_TYPE"].ToString()) ? oAllPremiums.Rows[i]["PREMIUM_TYPE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["GENDER"].ToString()) ? oAllPremiums.Rows[i]["GENDER"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["SMOKER"].ToString()) ? oAllPremiums.Rows[i]["SMOKER"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["MIN_AGE"].ToString()) ? oAllPremiums.Rows[i]["MIN_AGE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["BENEFIT_PERIOD"].ToString()) ? oAllPremiums.Rows[i]["BENEFIT_PERIOD"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["WAITING_PERIOD"].ToString()) ? oAllPremiums.Rows[i]["WAITING_PERIOD"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["FREQUENCY"].ToString()) ? oAllPremiums.Rows[i]["FREQUENCY"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["BUYBACK"].ToString()) ? oAllPremiums.Rows[i]["BUYBACK"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["DOUBLE"].ToString()) ? oAllPremiums.Rows[i]["DOUBLE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["OWNANY"].ToString()) ? oAllPremiums.Rows[i]["OWNANY"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["ICB"].ToString()) ? oAllPremiums.Rows[i]["ICB"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["ABO"].ToString()) ? oAllPremiums.Rows[i]["ABO"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(oAllPremiums.Rows[i]["CLASS"].ToString()) ? oAllPremiums.Rows[i]["CLASS"] : BLANK).Append(SEPARATOR);
        if (dBASKeys.ContainsKey(oSB.ToString()))
          {
          oDuplicates.ImportRow(oAllPremiums.Rows[i]);
          }
        else
          {
          dBASKeys.Add(oSB.ToString(), oAllPremiums.Rows[i]);
          }

        oSB.Clear();
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
    }
  }
