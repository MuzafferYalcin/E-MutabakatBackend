using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Business.Abstract
{
    public interface IMailService
    {
        IResult SendMail(SendMailDto sendMailDto);
    }
}
