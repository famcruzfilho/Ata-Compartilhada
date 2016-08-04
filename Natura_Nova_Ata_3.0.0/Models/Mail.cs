using Microsoft.Exchange.WebServices.Data;
using Natura_Nova_Ata_3._0._0.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.Models
{
    public class Mail
    {
        protected static string adjustName(string name)
        {
            try
            {
                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                name = ci.TextInfo.ToTitleCase(name.ToLower());
                if (name.Contains(" De "))
                {
                    name = name.Replace(" De ", " de ");
                }
                if (name.Contains(" Da "))
                {
                    name = name.Replace(" Da ", " da ");
                }
                if (name.Contains(" Do "))
                {
                    name = name.Replace(" Do ", " do ");
                }
                return name;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void sendMail(int action, List<User> listOfUsers, int projectId, string projectName)
        {
            try
            {
                string fromAddress = SecurityDAO.decrypt(ConfigurationManager.AppSettings["fromAddress"]);
                string userLogin = SecurityDAO.decrypt(ConfigurationManager.AppSettings["userLogin"]);
                string userPassword = SecurityDAO.decrypt(ConfigurationManager.AppSettings["userPassword"]);
                string userDomain = SecurityDAO.decrypt(ConfigurationManager.AppSettings["userDomain"]);
                int serverTime = Convert.ToInt32(string.Format("{0:HH}", DateTime.Now));
                string greeting = string.Empty;
                if (serverTime >= 6 && serverTime < 12)
                {
                    greeting = "Bom dia";
                }
                else if (serverTime >= 12 && serverTime < 18)
                {
                    greeting = "Boa tarde";
                }
                else
                {
                    greeting = "Boa noite";
                }
                string body = string.Empty;
                string subject = string.Empty;
                //Se zero, notifica que as atividades de execução de lançamento foram finalizadas
                if (action == 0)
                {
                    subject = "Finalização Tarefas Execução de Lançamento";
                    body = string.Format("<p>{0}!</p><p>&nbsp;</p><p>Informamos que as atividades de Execu&ccedil;&atilde;o do Lan&ccedil;amento do projeto {1} - {2} foram finalizadas com base nos dados da ata integrada.</p><p>&nbsp;</p><p>Atenciosamente,</p><p>&nbsp;</p><p>SGN.</p>", greeting, projectId, projectName);
                }
                //Se não for zero, notifica que mais atividades de execução de lançamento foram criadas após a finalização
                else
                {
                    subject = "Nova Tarefa Execução de Lançamento";
                    body = string.Format("<p>{0}!</p><p>&nbsp;</p><p>Informamos que as atividades de Execu&ccedil;&atilde;o do Lan&ccedil;amento do projeto {1} - {2} j&aacute; haviam sido finalizadas, entretando, uma nova atividade foi criada. Aguarde nova notifica&ccedil;&atilde;o para que a etapa esteja liberada para aprova&ccedil;&atilde;o.</p><p>&nbsp;</p><p>Atenciosamente,</p><p>&nbsp;</p><p>SGN.</p><p>", greeting, projectId, projectName);
                }
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                service.Credentials = new WebCredentials(userLogin, userPassword, userDomain);
                //service.AutodiscoverUrl(fromAddress);
                service.Url = new Uri("https://legacy.natura.net/EWS/Exchange.asmx");
                EmailMessage message = new EmailMessage(service);
                message.From = fromAddress;
                message.Subject = subject;
                message.Body = body;
                message.Body.BodyType = BodyType.HTML;
                foreach (User user in listOfUsers)
                {
                    message.ToRecipients.Add(user.getEmail());
                }
                message.SendAndSaveCopy();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}