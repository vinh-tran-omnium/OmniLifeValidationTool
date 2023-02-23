using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniLifeValidationTool.Database
  {
  public interface IPremiumService
    {
    void GetPremiums(string xsSupplierCode);
    }
  }
