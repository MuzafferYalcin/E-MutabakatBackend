using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MailManeger : IMailService
    {
        private readonly IMailDal _mailDal;

        public MailManeger(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public IResult SendMail(SendMailDto sendMailDto)
        {
            _mailDal.SendMail(sendMailDto);
            return new SuccessResult(Messages.MailSendSucessful);
        }
    }
}
