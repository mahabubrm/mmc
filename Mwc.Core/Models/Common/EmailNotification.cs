using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;




/// <summary>
/// Summary description for EmailNotification
/// </summary>
public class EmailNotification
{
    private static string smtpPassword= "9sL7zphGM3UkrPHB";
    private delegate void AsyncMethodCaller(MailMessage message, SmtpClient smtpClient);
    private string apiKey = "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";

    public void SendEmail(MailMessage message)
    {
        SmtpClient SmtpServer = new SmtpClient();
        System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        SmtpServer.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, smtpPassword);
        SmtpServer.UseDefaultCredentials = false;
        message.From = new MailAddress("bcsgea.org@gmail.com", "BCSGEA Admin");
        //SendMailBrevoAPI(message);
        //Send(message, SmtpServer);
    }

    
    private void Send(MailMessage message, SmtpClient smtpClient)
    {
        try
        {
            var caller = new AsyncMethodCaller(SendMailInSeperateThread);
            var callbackHandler = new AsyncCallback(AsyncCallback);
            caller.BeginInvoke(message, smtpClient, callbackHandler, null);
        }
        catch (Exception e)
        {

        }
    }

    private void SendMailInSeperateThread(MailMessage message, SmtpClient smtpClient)
    {
        try
        {
            var client = new SmtpClient();
            client.Host = smtpClient.Host;
            client.Port = smtpClient.Port;
            client.Credentials = smtpClient.Credentials;
            client.EnableSsl = smtpClient.EnableSsl;

            client.Send(message);
            client.Dispose();
            message.Dispose();
        }
        catch (Exception e)
        {

        }

    }

    private void AsyncCallback(IAsyncResult ar)
    {
        try
        {
            var result = (AsyncResult)ar;
            var caller = (AsyncMethodCaller)result.AsyncDelegate;
            caller.EndInvoke(ar);
        }
        catch (Exception e)
        {

        }
    }
}
