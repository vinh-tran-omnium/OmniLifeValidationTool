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
      if (string.IsNullOrWhiteSpace(LoadedSupplierTb.Text))
        {
        showDuplicatesBtn.Visible = false;
        }
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
      
      LoadedSupplierTb.Text = sSupplierCode;
      DataTable oData = _premiumService.GetPremiums(LoadedSupplierTb.Text);
      duplicateRowDgv.DataSource = oData;
      showDuplicatesBtn.Visible = true;
      

      }

    private void showDuplicatesBtn_Click(object sender, EventArgs e)
      {
      DataTable oAllPremiums = _premiumService.GetPremiums(LoadedSupplierTb.Text);
      DataTable oDuplicates = _premiumService.GetDuplicates(LoadedSupplierTb.Text);
      string sDuplicateText = "Show Duplicates";

      duplicateRowDgv.DataSource = null;
      if (showDuplicatesBtn.Text == sDuplicateText)
        {
        duplicateRowDgv.DataSource = oDuplicates;
        showDuplicatesBtn.Text = "Show All";
        }
      else
        {
        duplicateRowDgv.DataSource = oAllPremiums;
        showDuplicatesBtn.Text = sDuplicateText;
        }
      
      }
    }
  }