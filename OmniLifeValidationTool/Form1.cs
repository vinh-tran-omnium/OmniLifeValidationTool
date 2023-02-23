using OmniLifeValidationTool.Services;
using System.Data;

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
      if (oResult == DialogResult.OK)
        {
        string sFileName = oDialog.FileName;
        string sSupplierCode = sFileName.Split(new char[] { '-', '.' })[1].Trim();
        DataTable oData = _premiumService.GetPremiums(sSupplierCode);
        }
      
      }
    }
  }