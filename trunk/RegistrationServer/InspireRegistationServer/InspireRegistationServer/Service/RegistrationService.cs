using System;
using System.Net.Mail;
using System.ServiceModel;
using System.Text;
using Inspire.Server.Registration;

namespace Inspire.Server.Registration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RegistrationService : IRegistrationService
    {
       public RegistrationResponseMessage Register(RegistrationRequestMessage request)
       {
           RegistrationResponseMessage reg = new RegistrationResponseMessage();

           if(request.RegKey == Guid.Empty)
           {
               reg.RegDate = DateTime.Now.AddMonths(3);
               reg.RegKey = Guid.Empty;
           }
           else
           {
               reg.RegDate = DateTime.Now.AddYears(10);
               reg.RegKey = Guid.NewGuid();
           }
          
            SendEmail(request);
           return reg;
        }


        private void SendEmail(RegistrationRequestMessage request)
        {
         try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.inspiredisplays.com");

                mail.From = new MailAddress("info@inspiredisplays.com");
                mail.To.Add("info@inspiredisplays.com");
                mail.Subject = "Inspire Display Client Registration";
                        
                StringBuilder email = new StringBuilder();

                    email.AppendLine(request.CompanyName);
                    email.AppendLine(request.FirstName);
                    email.AppendLine(request.LastName);
                    email.AppendLine(request.Address1);
                    email.AppendLine(request.Address2);
                    email.AppendLine(request.City);
                    email.AppendLine(request.State);
                    email.AppendLine(request.Zip);
                    email.AppendLine(request.Email);
                    email.AppendLine(request.Phone);
                         
                mail.Body = email.ToString();

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jeremy.haveard@inspiredisplays.com", "!nspire8");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                     
            }
            catch (Exception ex)
            {
                     throw new FaultException("Registration email failed to send: Description: " + ex.Message);   
            }
         }

    }
}

