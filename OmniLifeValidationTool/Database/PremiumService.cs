using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniLifeValidationTool.Database
  {
  public class PremiumService : IPremiumService
    {
    private readonly IPremiumRepository _premiumRepo;
    public PremiumService(IPremiumRepository premiumRepo)
      {
      _premiumRepo = premiumRepo;
      }

    public void GetPremiums(string xsSupplierCode)
      {
      _premiumRepo.GetPremiums(xsSupplierCode);
      }
    }
  }
