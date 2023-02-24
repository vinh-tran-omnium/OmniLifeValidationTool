using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OmniLifeValidationTool
  {
  public class Utility
    {
    private const string BLANK = "_";
    private const string SEPARATOR = "/";


    public static Dictionary<int, DataRow> GetKeyBAS(DataTable xoDT)
      {
      StringBuilder oSB = new();
      // ReSharper disable once CollectionNeverQueried.Local
      Dictionary<string, DataRow> dBASKeys = new();
      Dictionary<int, DataRow> dDuplicatedRows = new();


      for (int i = 0; i < xoDT.Rows.Count; i++)
        {
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["FORMULA_CODE"].ToString()) ? xoDT.Rows[i]["FORMULA_CODE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["PREMIUM_TYPE"].ToString()) ? xoDT.Rows[i]["PREMIUM_TYPE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["GENDER"].ToString()) ? xoDT.Rows[i]["GENDER"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["SMOKER"].ToString()) ? xoDT.Rows[i]["SMOKER"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["MIN_AGE"].ToString()) ? xoDT.Rows[i]["MIN_AGE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["BENEFIT_PERIOD"].ToString()) ? xoDT.Rows[i]["BENEFIT_PERIOD"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["WAITING_PERIOD"].ToString()) ? xoDT.Rows[i]["WAITING_PERIOD"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["FREQUENCY"].ToString()) ? xoDT.Rows[i]["FREQUENCY"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["BUYBACK"].ToString()) ? xoDT.Rows[i]["BUYBACK"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["DOUBLE"].ToString()) ? xoDT.Rows[i]["DOUBLE"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["OWNANY"].ToString()) ? xoDT.Rows[i]["OWNANY"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["ICB"].ToString()) ? xoDT.Rows[i]["ICB"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["ABO"].ToString()) ? xoDT.Rows[i]["ABO"] : BLANK).Append(SEPARATOR);
        oSB.Append(!string.IsNullOrWhiteSpace(xoDT.Rows[i]["CLASS"].ToString()) ? xoDT.Rows[i]["CLASS"] : BLANK).Append(SEPARATOR);
        try
          {
          dBASKeys.Add(oSB.ToString(), xoDT.Rows[i]);
          }
        catch (ArgumentException)
          {
          dDuplicatedRows.Add(i, xoDT.Rows[i]);
          }

        oSB.Clear();
        }

      return dDuplicatedRows;
      }





    }
  }
