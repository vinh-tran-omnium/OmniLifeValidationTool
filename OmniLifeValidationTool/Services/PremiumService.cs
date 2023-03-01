using OmniLifeValidationTool.Enums;
using System.Data;
using System.Text;
using OmniLifeValidationTool.Databases;

namespace OmniLifeValidationTool.Services
  {
  public class PremiumService : IPremiumService
    {
    private readonly IPremiumRepository _premiumRepo;
    private const string BLANK = "_";
    private const string SEPARATOR = "/";
    private const string COL_RECORD_NUM = "Row #";
    public PremiumService(IPremiumRepository premiumRepo)
      {
      _premiumRepo = premiumRepo;
      }

    public DataTable GetMismatchKey(DataTable xoData)
      {
      DataTable oLocalData = xoData.Copy();
      oLocalData.Columns.Add(COL_RECORD_NUM);
      List<IGrouping<string?, DataRow>>? grouped = oLocalData
        .AsEnumerable()
        .GroupBy(x => x.Field<string>(SupplierPremiumHeader.FORMULA_CODE.ToString()))
        .ToList();
      DataTable oMismatched = oLocalData.Clone();

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
              oRow[COL_RECORD_NUM] = oLocalData.Rows.IndexOf(oRow) + 1;
              oMismatched.ImportRow(oRow);
              }
            }
          }
        }
      return oMismatched;
      }

    public DataTable GetDuplicates(DataTable xoData)
      {
      DataTable oLocalData = xoData.Copy();
      if (!oLocalData.Columns.Contains(COL_RECORD_NUM))
        {
        oLocalData.Columns.Add(COL_RECORD_NUM);
        }
      
      DataTable oDuplicates = oLocalData.Clone();
      Dictionary<string, DataRow> dBASKeys = new();

      for (int i = 0; i < oLocalData.Rows.Count; i++)
        {
        string sBasKey = GetBASKey(oLocalData.Rows[i]);
        if (dBASKeys.ContainsKey(sBasKey))
          {
          // original row
          DataRow oOriginalRow = dBASKeys[sBasKey];
          oOriginalRow[COL_RECORD_NUM] = oLocalData.Rows.IndexOf(oOriginalRow) + 1;
          oDuplicates.ImportRow(oOriginalRow);
          // duplicated row
          DataRow oDuplicateRow = oLocalData.Rows[i];
          oDuplicateRow[COL_RECORD_NUM] = i + 1;
          oDuplicates.ImportRow(oDuplicateRow);
          }
        else
          {
          dBASKeys.Add(sBasKey, oLocalData.Rows[i]);
          }
        }

      return oDuplicates;
      }

    public DataTable? GetPremiums(string xsFilePath)
      {
      return _premiumRepo.GetPremiums(xsFilePath);
      }

    private string GetBASKey(DataRow xoRow)
      {
      StringBuilder oSB = new();
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
      StringBuilder sbNullKey = new();
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.FORMULA_CODE.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.GENDER.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.SMOKER.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.MIN_AGE.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.BENEFIT_PERIOD.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.WAITING_PERIOD.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.FREQUENCY.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.BUYBACK.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.DOUBLE.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.OWNANY.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.ICB.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.ABO.ToString()].ToString()) ? "N" : "Y");
      sbNullKey.Append(string.IsNullOrWhiteSpace(xoRow[SupplierPremiumHeader.CLASS.ToString()].ToString()) ? "N" : "Y");
      return sbNullKey.ToString();
      }

    
    }
  }
