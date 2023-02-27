using OmniLifeValidationTool.Database;
using OmniLifeValidationTool.Enums;
using System.Data;
using System.Text;

namespace OmniLifeValidationTool.Services
  {
  public class PremiumService : IPremiumService
    {
    private readonly IPremiumRepository _premiumRepo;
    private const string BLANK = "_";
    private const string SEPARATOR = "/";
    public PremiumService(IPremiumRepository premiumRepo)
      {
      _premiumRepo = premiumRepo;
      }

    public DataTable GetMismatchKey(DataTable xoData)
      {
      List<IGrouping<string?, DataRow>>? grouped = xoData
        .AsEnumerable()
        .GroupBy(x => x.Field<string>(SupplierPremiumHeader.FORMULA_CODE.ToString()))
        .ToList();
      DataTable oMismatched = xoData.Clone();

      foreach (IGrouping<string?, DataRow>? oGroup in grouped)
        {
        string? sCurrentGroupKey = null;
        foreach (DataRow? oRow in oGroup)
          {
          if (string.IsNullOrWhiteSpace(sCurrentGroupKey))
            {
            sCurrentGroupKey = GetNullKey(oRow);
            }
          else
            {
            string sKey = GetNullKey(oRow);
            if (sCurrentGroupKey != sKey)
              {
              oMismatched.ImportRow(oRow);
              }
            }
          }
        }
      return oMismatched;
      }

    public DataTable GetDuplicates(DataTable xoData)
      {
      DataTable oDuplicates = xoData.Clone();
      Dictionary<string, DataRow> dBASKeys = new();

      for (int i = 0; i < xoData.Rows.Count; i++)
        {
        string sBasKey = GetBASKey(xoData.Rows[i]);
        if (dBASKeys.ContainsKey(sBasKey))
          {
          // original row
          oDuplicates.ImportRow(dBASKeys[sBasKey]);
          // duplicated row
          oDuplicates.ImportRow(xoData.Rows[i]);
          }
        else
          {
          dBASKeys.Add(sBasKey, xoData.Rows[i]);
          }
        }

      return oDuplicates;
      }

    public DataTable? GetPremiums(string xsSupplierCode)
      {
      return _premiumRepo.GetPremiums(xsSupplierCode);
      }

    private string GetBASKey(DataRow xoRow)
      {
      StringBuilder oSB = new StringBuilder();
      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.FORMULA_CODE.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.FORMULA_CODE.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.PREMIUM_TYPE.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.PREMIUM_TYPE.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.GENDER.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.GENDER.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.SMOKER.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.SMOKER.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.MIN_AGE.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.MIN_AGE.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.BENEFIT_PERIOD.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.BENEFIT_PERIOD.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.WAITING_PERIOD.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.WAITING_PERIOD.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.FREQUENCY.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.FREQUENCY.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.BUYBACK.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.BUYBACK.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.DOUBLE.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.DOUBLE.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.OWNANY.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.OWNANY.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.ICB.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.ICB.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.ABO.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.ABO.ToString()] : BLANK).Append(SEPARATOR);

      oSB.Append(!string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.CLASS.ToString()].ToString()) 
        ? xoRow[SupplierPremiumHeader.CLASS.ToString()] : BLANK).Append(SEPARATOR);
      return oSB.ToString();
      }

    private static string GetNullKey(DataRow xoRow)
      {
      StringBuilder sbNullKey = new StringBuilder();
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.FORMULA_CODE.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.GENDER.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.SMOKER.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.MIN_AGE.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.BENEFIT_PERIOD.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.WAITING_PERIOD.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.FREQUENCY.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.BUYBACK.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.DOUBLE.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.OWNANY.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.ICB.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.ABO.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrEmpty(xoRow[SupplierPremiumHeader.CLASS.ToString()].ToString()) ? "N" : "Y");
      return sbNullKey.ToString();
      }

    
    }
  }
