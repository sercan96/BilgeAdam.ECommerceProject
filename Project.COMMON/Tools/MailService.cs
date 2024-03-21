using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public class MailService
    {
        public static void Send(string receiver, string password = "",string body="Test mesajıdır",string subject = "Email testi", string sender = "yzl3169@gmail.com")
        {
            MailAddress senderEmail = new(sender);
            MailAddress receiverEmail = new(receiver);

            // Bizim Email işlemlerimiz SMTP'ye göre yapılır... 
            // Kullandığınız gmail hesabınızın başka uygulamalar tarafından mesaj göndermesistemini açmanız lazım...
            SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address,password)
            };

            using(MailMessage message = new MailMessage(senderEmail,receiverEmail) // Maili gönder sonra yok et.
            {
                Subject = subject,
                Body = body,
            })
            {
                smtp.Send(message);
            }

            //MailMessage message = new(senderEmail, receiverEmail)
            //{
            //    Subject = subject,
            //    Body = body,
            //};
            //smtp.Send(message);



        }
        #region DefaultParameters
        /*
         * Bir metot parametresine default bir değer alırsa çağrılırken argüman almayabilir böylece o default değer parametreye gitmiş olur... ancak yine de eğer argüman verirseniz verdiğiniz argüman defeul değeri ezerek gönderilir...
         * 
         * Eğer parametreleriniz default bir değer almaya başladıysa onları takip eden parametreler değer almadan syntax hatası verirler... Defeult değer almayacak parametrelerinizii deger alanlardan önce yazmalısınız...
         * 
         * Params keywordu
         * 
         * Bir metodun kaç tane argüman alabileceğini öngöremediğimiz durumlarda paramtre keyword'u tanmılamasımıparams ile ypıyotuz... Böylce metot çarıldığında isterse hiç argüman almayabilir veya istediğiniz o ilgili tipte eleman ekleyebilirsiniz..
         * 
         * 
         */
        //public static void Deneme(int b,params char[] a)
        //{

        //}
        #endregion

    }
}
