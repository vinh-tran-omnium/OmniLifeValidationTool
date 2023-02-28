using System.Data;

namespace OmniLifeValidationTool.Databases
  {
  public interface IPremiumRepository
    {
    DataTable? GetPremiums(string xsFilePath);
    }
  }
