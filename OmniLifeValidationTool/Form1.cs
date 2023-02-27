using OmniLifeValidationTool.Services;
using System.Data;

namespace OmniLifeValidationTool
  {
  public partial class Form1 : Form
    {
    private readonly IPremiumService _premiumService;
    private DataTable? _loadedSupplier = null;

    public Form1(IPremiumService premiumService)
      {
      _premiumService = premiumService;

      InitializeComponent();
      if (string.IsNullOrWhiteSpace(LoadedSupplierTb.Text)) { HideButtons(); }
      }

    private void loadSupplierBtn_Click(object sender, EventArgs e)
      {
      OpenFileDialog oDialog = new();
      DialogResult oResult = oDialog.ShowDialog();
      if (oResult != DialogResult.OK) { return; }

      string sFileName = oDialog.FileName;
      _loadedSupplier = _premiumService.GetPremiums(sFileName);
      if (_loadedSupplier == null)
        {
        return;
        }
      string sSupplierCode = sFileName.Split(new char[] { '-', '.' })[1].Trim();
      LoadedSupplierTb.Text = sSupplierCode;
      duplicateRowDgv.DataSource = _loadedSupplier;
      ShowButtons();
      }

    private void showDuplicatesBtn_Click(object sender, EventArgs e)
      {
      DataTable oDuplicates = _premiumService.GetDuplicates(_loadedSupplier!);
      duplicateRowDgv.DataSource = oDuplicates;
      }

    private void showMismatchBtn_Click(object sender, EventArgs e)
      {
      DataTable oMismatch = _premiumService.GetMismatchKey(_loadedSupplier!);
      duplicateRowDgv.DataSource = oMismatch;
      }

    private void showAllBtn_Click(object sender, EventArgs e)
      {
      duplicateRowDgv.DataSource = _loadedSupplier;
      }

    private void ShowButtons()
      {
      showAllBtn.Visible = true;
      showDuplicatesBtn.Visible = true;
      showMismatchBtn.Visible = true;
      }

    private void HideButtons()
      {
      showAllBtn.Visible = false;
      showDuplicatesBtn.Visible = false;
      showMismatchBtn.Visible = false;
      }

    }
  }