using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BaBsRecoinciliationManager : IBaBsReconciliationService
    {
        private readonly IBaBsRecoinciliationDal _baBsRecoinciliationDal;
        private readonly ICurrencyAccountService _currencyAccountService;
        private readonly IMailService _mailService;
        private readonly IMailTemplateService _mailTemplateService;
        private readonly IMailParameterService _mailParameterService;

        public BaBsRecoinciliationManager(IBaBsRecoinciliationDal baBsRecoinciliationDal, ICurrencyAccountService currencyAccountService, IMailService mailService, IMailTemplateService mailTemplateService, IMailParameterService mailParameterService)
        {
            _baBsRecoinciliationDal = baBsRecoinciliationDal;
            _currencyAccountService = currencyAccountService;
            _mailService = mailService;
            _mailTemplateService = mailTemplateService;
            _mailParameterService = mailParameterService;
        }
    }
}
