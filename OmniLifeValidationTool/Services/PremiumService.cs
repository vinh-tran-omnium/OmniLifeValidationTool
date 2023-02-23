using OmniLifeValidationTool.Database;
using System.Data;

namespace OmniLifeValidationTool.Services
  {
  public class PremiumService : IPremiumService
    {
    private readonly IPremiumRepository _premiumRepo;
    public PremiumService(IPremiumRepository premiumRepo)
      {
      _premiumRepo = premiumRepo;
      }

    public DataTable GetPremiums(string xsSupplierCode)
      {
      return _premiumRepo.GetPremiums(xsSupplierCode);
      }
    }
  }
