using System.Data;
using System.Data.OleDb;

namespace OmniLifeValidationTool.Database
  {
  [System.Runtime.Versioning.SupportedOSPlatform("windows")]
  public class PremiumRepository : IPremiumRepository
    {
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
