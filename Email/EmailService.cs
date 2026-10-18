using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    internal class EmailService
    {
        private HashSet<User> users;

        public EmailService()
        {
            this.users = new HashSet<User>();
        }

        public bool RegisterUser(string emailAddress)
        {
            if (!emailAddress.Contains('@'))
            {
                return false;
            }
            else if (emailAddress[0] == '@')
            {
                return false;
            }
            else if (emailAddress.Split('@')[1][0] == '.')
            {
                return false;
            }
            // a hashSet alapbol kezeli a duplikaciot :)
            else
            {
                User user = new User(emailAddress);
                users.Add(user);
                return true;
            }
        }

        public void SendEmail(string from, string to,  string subject, string content)
        {
            User fromUser = null;
            User toUser = null;
            foreach (User u in users)
            {
                if (u.GetEmailAdress() == from)
                {
                    fromUser = u;
                }
                if (u.GetEmailAdress() == to)
                {
                    toUser = u;
                }
                if (fromUser != null && toUser != null)
                {
                    break;
                }
            }
            if (fromUser != null && toUser != null)
            {
                fromUser.SendEmail(subject, content, toUser);
            }
            else
            {
                throw new Exception("Nincs(enek) ilyen email cím(ek)!");
            }
        }

        public void SendSpam(string subject, string content)
        {
            foreach (User u in users)
            {
                u.GetEmail(new Spam(u, subject, content));
            }
        }
    }
}
