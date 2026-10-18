using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    internal class Spam : IEmail
    {
        private User to;
        private string subject;
        private string content;

        public Spam(User to, string subject, string content)
        {
            this.to = to;
            this.subject = subject;
            this.content = content;
        }

        public string Subject { get => subject; set => subject = value; }
        public string Content { get => content; set => content = value; }
        internal User To { get => to; set => to = value; }

        public string getContent()
        {
            return content;
        }

        public User getFrom()
        {
            throw new NotImplementedException();
        }

        public string getSubject()
        {
            return subject;
        }

        public User getTo()
        {
            return to;
        }

        public bool isImportant()
        {
            return false;
        }
    }
}
