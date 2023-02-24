using OmniLifeValidationTool.Services;
using System.Data;
using System.Windows.Forms;

namespace OmniLifeValidationTool
  {
  public partial class Form1 : Form
    {
    private readonly IPremiumService _premiumService;

    public Form1(IPremiumService premiumService)
      {
      _premiumService = premiumService;
      InitializeComponent();
      }

    private void loadSupplierBtn_Click(object sender, EventArgs e)
      {
      OpenFileDialog oDialog = new();
      DialogResult oResult = oDialog.ShowDialog();
      if (oResult != DialogResult.OK)
        {
        return;
        }

      string sFileName = oDialog.FileName;
      string sSupplierCode = sFileName.Split(new char[] { '-', '.' })[1].Trim();
      DataTable oData = _premiumService.GetPremiums(sSupplierCode);
      Dictionary<int, DataRow> oDuplicatedRow = Utility.GetKeyBAS(oData);

      DataTable newTable = new();
      newTable.Columns.Add("Duplicated_Row", typeof(string));
      newTable.Columns.Add("FORMULA_CODE", typeof(string));

      foreach (KeyValuePair<int, DataRow> oDuplicate in oDuplicatedRow)
        {
        DataRow dr = newTable.NewRow();
        dr["Duplicated_Row"] = oDuplicate.Key;
        dr["FORMULA_CODE"] = oDuplicate.Value.ItemArray[0];
        newTable.Rows.Add(dr);
        }

      duplicateRowDgv.DataSource = newTable;
      








      }





    }
  }