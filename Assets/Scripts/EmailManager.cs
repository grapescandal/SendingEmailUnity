using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailManager : MonoBehaviour
{
    [SerializeField]
    private string path;
    public void SendEmail() 
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("jirachai@madvrstudio.com");
        mail.To.Add("divinetrees@gmail.com");
        mail.Subject = "Test";
        mail.Body = "Your pictures";
        mail.Attachments.Add(new Attachment(path));

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("jirachai@madvrstudio.com", "") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {return true;};
        smtpServer.Send(mail);
    }
}
