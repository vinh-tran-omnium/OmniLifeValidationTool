using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniLifeValidationTool.Database
  {
  public interface IPremiumRepository
    {
    void GetPremiums(string xsSupplierCode);
    }
  }
