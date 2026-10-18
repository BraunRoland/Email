using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    internal class User
    {
        private string emailAdress;


        private List<IEmail> inbox;
        private List<IEmail> sentMessages;
        private bool hasSpamFilter;

        public User(string emailAdress)
        {
            this.emailAdress = emailAdress;
            this.inbox = new List<IEmail>();
            this.sentMessages = new List<IEmail>();
            this.hasSpamFilter = false;
        }

        public void GetEmail(IEmail email)
        {
            if (!email.getFrom().emailAdress.Contains("spam") && !this.hasSpamFilter)
            {
                if (email.isImportant())
                {
                    inbox.Insert(0, email);
                }
                else
                {
                    inbox.Add(email);
                }
            }
        }

        public void SendEmail(string subject, string content, User to)
        {
            Normal email = new Normal(this,to, subject, content);
            this.sentMessages.Add(email);
            to.GetEmail(email);
        }

        public void SpamFilterChange()
        {
            this.hasSpamFilter = !this.hasSpamFilter;
        }

        public string getEmailAdress()
        {
            return this.emailAdress;
        }

        public bool getHasSpamFilter()
        {
            return this.hasSpamFilter;
        }

        public List<IEmail> getInbox()
        {
            return this.inbox;
        }

        public List<IEmail> getSentMessages()
        {
            return this.sentMessages;
        }

        public string EmailAdress { get => emailAdress; set => emailAdress = value; }
        public bool HasSpamFilter { get => hasSpamFilter; set => hasSpamFilter= value; }
        internal List<IEmail> Inbox { get; }
        internal List<IEmail> SentMessages { get; }
    }
}
