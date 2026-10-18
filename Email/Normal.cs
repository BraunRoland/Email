using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    internal class Normal : IEmail
    {
        private User from;
        private User to;
        private string subject;
        private string content;

        public Normal(User from, User to, string subject, string content)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.content = content;
        }

        public string Subject { get => subject; set => subject = value; }
        public string Content { get => content; set => content = value; }
        internal User From { get => from; set => from = value; }
        internal User To { get => to; set => to = value; }

        public string getContent()
        {
            return content;
        }

        public User getFrom()
        {
            return from;
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
            if (subject.ToLower().Contains("important"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
