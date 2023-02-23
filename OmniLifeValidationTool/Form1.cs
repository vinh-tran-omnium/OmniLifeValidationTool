using OmniLifeValidationTool.Database;

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
      _premiumService.GetPremiums("ACC");
      }
    }
  }