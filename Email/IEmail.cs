using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    internal interface IEmail
    {
        User getTo();
        User getFrom();
        string getSubject();
        string getContent();
        bool isImportant();
    }
}
