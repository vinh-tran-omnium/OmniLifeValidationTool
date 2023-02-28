using System.Data;

namespace OmniLifeValidationTool.Services
  {
  public interface IPremiumService
    {
    DataTable? GetPremiums(string xsFilePath);
    DataTable GetDuplicates(DataTable xoData);
    DataTable GetMismatchKey(DataTable xoData);
    }
  }
