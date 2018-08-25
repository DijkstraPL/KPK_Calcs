using KPK_CalcSite.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web.Mvc;

namespace CalcSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you have any questions about how calculators work or want to report an error, please feel free to contact me.";

            return View("Contact");
        }

        public ActionResult Calculators()
        {
            ViewBag.Message = "Your calculators.";

            return View();
        }

        public ActionResult ContactForm(MailModels emailData)
        {
            ViewBag.Message = "If you have any questions about how calculators work or want to report an error, please feel free to contact me.";

            if (ModelState.IsValid)
            {
                string fromAddress = emailData.Email;
                var subject = "Mail from " + emailData.FirstName + " " + emailData.LastName;

                StringBuilder message = new StringBuilder();
                MailAddress from = new MailAddress(emailData.Email.ToString());
                message.Append("<b>First Name:</b> " + emailData.FirstName + "<br/>");
                message.Append("<b>Last Name:</b> " + emailData.LastName + "<br/>");
                message.Append("<b>Country:</b> " + emailData.Country + "<br/>");
                message.Append("<b>Email:</b> " + emailData.Email + "<br/>");
                if (!string.IsNullOrWhiteSpace(emailData.Telephone))
                    message.Append("<b>Telephone:</b> " + emailData.Telephone + "<br/><br/>");
                else
                    message.Append("<br/>");
                message.Append(emailData.Message);

                var tEmail = new Thread(() =>
                    SendEmail("kania.konrad92@gmail.com", fromAddress, subject, message.ToString()));
                tEmail.Start();
            }
            return View("Contact");
        }

        public void SendEmail(string toAddress, string fromAddress,
                      string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    const string email = "kpk_calc_test@o2.pl";
                    const string password = "KPK_calc_test";

                    var loginInfo = new NetworkCredential(email, password);


                    mail.From = new MailAddress("kpk_calc_test@o2.pl");
                    mail.To.Add(new MailAddress(toAddress));
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = message;

                    try
                    {
                        using (var smtpClient = new SmtpClient())
                        // "smtp.mail.yahoo.com", 465))
                        {
                            smtpClient.Host = "poczta.o2.pl";
                            smtpClient.Port = 587;
                            smtpClient.EnableSsl = true;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = loginInfo;
                            smtpClient.Send(mail);
                        }

                    }

                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }

                }
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    var status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Response.Write("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        //resend
                        //smtpClient.Send(message);
                    }
                    else
                    {
                        Response.Write($"Failed to deliver message to {t.FailedRecipient}");
                    }
                }
            }
            catch (SmtpException Se)
            {
                // handle exception here
                Response.Write(Se.ToString());
            }

            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

    }
}