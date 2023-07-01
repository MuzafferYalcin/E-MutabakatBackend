using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAccountReconciliationService
    {
        IResult Add(AccountReconciliation accountReconciliation);
        IResult Delete(AccountReconciliation accountReconciliation);
        IResult Update(AccountReconciliation accountReconciliation);
        IDataResult<AccountReconciliation> GetById(int id);
        IDataResult<List<AccountReconciliation>> GetList(int companyId);


    }
}
