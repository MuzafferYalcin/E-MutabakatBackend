using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICurrencyAccountService
    {
        IResult Add(CurrencyAccount currencyAccount);
        IResult Update(CurrencyAccount currencyAccount);
        IResult Delete(CurrencyAccount currencyAccount);
        IDataResult<CurrencyAccount> Get(int id);
        IDataResult<List<CurrencyAccount>> GetList(int companyId);
    }
}
