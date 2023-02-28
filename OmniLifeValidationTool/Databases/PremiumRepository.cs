using System.Data;
using System.Data.OleDb;

namespace OmniLifeValidationTool.Databases
  {
  [System.Runtime.Versioning.SupportedOSPlatform("windows")]
  public class PremiumRepository : IPremiumRepository
    {
    public DataTable? GetPremiums(string xsFilePath)
      {
      string sSupplierCode = xsFilePath.Split(new char[] { '-', '.' })[1].Trim();
      string sTableName = $"Premium_{sSupplierCode}";
      string sConnectionString = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={xsFilePath}";

      using OleDbConnection oConnection = new(sConnectionString);
      string sQuery = $"select * from {sTableName} where FORMULA = 'BAS'";
      OleDbCommand oCommand = new(sQuery, oConnection);
      try
        {
        oConnection.Open();
        using OleDbDataReader oReader = oCommand.ExecuteReader();
        DataTable oData = new();
        oData.Load(oReader);
        return oData;
        }
      catch (Exception)
        {
        MessageBox.Show(@"Incorrect database file loaded.");
        return null;
        }
      }
    }
  }
