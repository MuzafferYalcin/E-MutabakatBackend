using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserCompanyManager : IUserCompanyService
    {
        private readonly IUserCompanyDal _userCompanyDal;

        public UserCompanyManager(IUserCompanyDal userCompanyDal)
        {
            _userCompanyDal = userCompanyDal;
        }

    }
}
