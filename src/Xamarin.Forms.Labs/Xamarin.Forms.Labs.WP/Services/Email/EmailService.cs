﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services.Email;

[assembly: Dependency(typeof(Xamarin.Forms.Labs.WP.Services.Email.EmailService))]

namespace Xamarin.Forms.Labs.WP.Services.Email
{
    public class EmailService : IEmailService
    {
        #region IEmailService Members
        public bool CanSend
        {
            get { return true; }
        }

        public void ShowDraft(string subject, string body, bool html, string to, IEnumerable<string> attachments)
        {
            var task = new EmailComposeTask()
            {
                Subject = subject,
                Body = body,
                To = to
            };

            task.Show();
        }

        public void ShowDraft(string subject, string body, bool html, string[] to, string[] cc, string[] bcc, IEnumerable<string> attachments)
        {
            var task = new EmailComposeTask()
            {
                Subject = subject,
                Body = body,
                
            };

            var stringBuilder = new StringBuilder();

            if (to.Any())
            {
                foreach (var t in to)
                {
                    stringBuilder.Append(t);
                    stringBuilder.Append(";");
                }

                task.To = stringBuilder.ToString();
                stringBuilder.Clear();
            }

            if (cc.Any())
            {
                foreach (var c in cc)
                {
                    stringBuilder.Append(c);
                    stringBuilder.Append(";");
                }

                task.Cc = stringBuilder.ToString();
                stringBuilder.Clear();
            }

            if (bcc.Any())
            {
                foreach (var b in bcc)
                {
                    stringBuilder.Append(b);
                    stringBuilder.Append(";");
                }

                task.Bcc = stringBuilder.ToString();
                stringBuilder.Clear();
            }

            task.Show();

        }

        #endregion
    }
}
