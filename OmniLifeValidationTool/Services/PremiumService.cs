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

    public DataTable GetDuplicates(string xsSupplierCode)
      {
      return _premiumRepo.GetDuplicates(xsSupplierCode);
      }

    public DataTable GetPremiums(string xsSupplierCode)
      {
      return _premiumRepo.GetPremiums(xsSupplierCode);
      }
    }
  }
