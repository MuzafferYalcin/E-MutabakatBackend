using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        //CRUD
        IDataResult<List<Company>> GetList();
        public IResult Add(Company company);
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userId, int companyId);
    }
}
