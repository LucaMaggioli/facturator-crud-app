using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Services
{
    public class EmailService
    {
        /// <summary>
        /// This method is to check if the email is in a valid format
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
