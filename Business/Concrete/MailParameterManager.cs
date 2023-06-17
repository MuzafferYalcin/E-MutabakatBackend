using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MailParameterManager : IMailParameterService
    {
        private readonly IMailParameterDal _mailParameterDal;
        private readonly IMailService _mailService;


        public MailParameterManager(IMailParameterDal mailParameterDal, IMailService mailService)
        {
            _mailParameterDal = mailParameterDal;
            _mailService = mailService;
        }

        public IDataResult<MailParameter> Get(int companyId)
        {
            return new SuccesDataResult<MailParameter>(_mailParameterDal.Get(m => m.CompanyId == companyId));

        }

        public IResult Update(MailParameter mailParameter)
        {
            var result = Get(mailParameter.CompanyId);
            if(result.Data == null)
            {
                _mailParameterDal.Add(mailParameter);
            }
            else
            {
                result.Data.SMTP = mailParameter.SMTP;
                result.Data.Port = mailParameter.Port;
                result.Data.SSL = mailParameter.SSL;
                result.Data.Email = mailParameter.Email;
                result.Data.Password = mailParameter.Password;
                _mailParameterDal.Update(mailParameter);
            }
            return new SuccessResult(Messages.MailParameterUpdated);
        }
    }
}
