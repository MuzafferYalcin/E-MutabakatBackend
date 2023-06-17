﻿using DataAccess.Abstract;
using Entities.DTOs;
using System.Net;
using System.Net.Mail;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMailDal : IMailDal
    {
        public void SendMail(SendMailDto sendMailDto)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(sendMailDto.MailParameter.Email);
                mail.To.Add(sendMailDto.Email);
                mail.Subject = sendMailDto.Subject;
                mail.Body = sendMailDto.Body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add();

                using (SmtpClient smtp = new SmtpClient(sendMailDto.MailParameter.SMTP))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(sendMailDto.MailParameter.Email,sendMailDto.MailParameter.Password);
                    smtp.EnableSsl = sendMailDto.MailParameter.SSL;
                    smtp.Port = sendMailDto.MailParameter.Port;
                    smtp.Send(mail);
                }
            }
        }
    }
}
