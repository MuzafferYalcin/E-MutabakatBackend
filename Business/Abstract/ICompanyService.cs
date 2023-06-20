using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        //CRUD
        IDataResult<List<Company>> GetList();
        IDataResult<UserCompany> GetCompany(int userId);
        IResult Add(Company company);
        IResult Update(Company company);
        IResult AddCompanyAndUserCompany(CompanyDto companyDto);
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userId, int companyId);
        IDataResult<Company> GetById(int id);
    }
}
