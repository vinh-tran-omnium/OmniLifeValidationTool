using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniLifeValidationTool.Services
  {
  public interface IPremiumService
    {
    DataTable GetPremiums(string xsSupplierCode);
    }
  }
