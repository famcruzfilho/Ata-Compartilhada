using Natura_Nova_Ata_3._0._0.DAO;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Natura_Nova_Ata_3._0._0
{
    /// <summary>
    /// WebService para utilização da nova versão da ata compartilhada baseada em XML
    /// </summary>
    [WebService(Namespace = "http://www.w3.org/2001/XMLSchema")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod(Description = "Método lista as atas que o usuário solicitante deve enxergar. Parâmetro 0: lista todos os projetos. Parâmetro 1: lista somente projetos ativos ou em etapa de Execução de Lançamento")]
        public List<Minute> getMinutes(int projectstatus)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("getMinutes", "GET", requester, DateTime.Now, projectstatus.ToString(), "", "");
                LogDAO.insert(log);
                return MinuteDAO.select(requester, projectstatus);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que retorna todas as atividades de um determinado projeto informado como parâmetro")]
        public List<Task> getTasks(int projectId)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("getTasks", "POST", requester, DateTime.Now, projectId.ToString(), "", "");
                LogDAO.insert(log);
                return TaskDAO.select(requester, projectId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que recebe as tarefas que serão salvas no banco de dados")]
        public List<Response> saveTasks()
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("saveTasks", "POST", requester, DateTime.Now, "", "", "");
                LogDAO.insert(log);
                return TaskDAO.insertOrUpdate(requester, Task.xmlToArrayOfTasks(requester, HttpContext.Current));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que recebe as tarefas do Microsoft Project que serão salvas no banco de dados")]
        public List<Response> saveTasksMSProject()
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("saveTasksMSProject", "POST", requester, DateTime.Now, "", "", "");
                LogDAO.insert(log);
                return MSProjectDAO.insertOrUpdate(requester, Task.xmlToArrayOfTasks(requester, HttpContext.Current));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que indica atualização o andamento das atividades da ata para o Microsoft Project")]
        public List<Update> updateMSProject(int projectId)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("updateMSProject", "POST", requester, DateTime.Now, "", "", "");
                LogDAO.insert(log);
                return MSProjectDAO.select(projectId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que finaliza uma atividade, bastando informar seu id")]
        public Response finishTask(int taskId)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("finishTask", "POST", requester, DateTime.Now, taskId.ToString(), "", "");
                LogDAO.insert(log);
                return TaskDAO.finishTask(requester, TaskDAO.instanceById(taskId));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que retorna todos os comentários de uma determinada atividade")]
        public List<Comment> getComments(int taskId)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("getComments", "GET", requester, DateTime.Now, taskId.ToString(), "", "");
                LogDAO.insert(log);
                return CommentDAO.select(taskId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que insere um novo comentário em uma tarefa")]
        public Response saveComments()
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("saveComments", "POST", requester, DateTime.Now, "", "", "");
                LogDAO.insert(log);
                return CommentDAO.insert(requester, Comment.xmlToComment(requester, HttpContext.Current));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que recebe um id de um projeto como parâmetro e devolve suas informações")]
        public Project getProjectInformation(int projectId)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("getProjectInformation", "GET", requester, DateTime.Now, projectId.ToString(), "", "");
                LogDAO.insert(log);
                return ProjectDAO.select(projectId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que retorna as informações do cockpit")]
        public List<CockpitSAP> getCockpit()
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("getCockpit", "GET", requester, DateTime.Now, "", "", "");
                LogDAO.insert(log);
                return CockpitDAO.select(requester, ProjectIdList.xmlToArrayOfIds(requester, HttpContext.Current));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que salva dados no cockpit")]
        public List<Response> saveCockpit()
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("saveCockpit", "POST", requester, DateTime.Now, "", "", "");
                LogDAO.insert(log);
                return CockpitDAO.insertOrUpdate(requester, Cockpit.xmlToArrayOfCockpits(requester, HttpContext.Current));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que coleta informações para montagem do dashboard. Parâmetro 0: Todas as atividades. Parâmetro 1: Somente atividades em Andamento e Atrasadas. Parâmetro 2: Apenas atividades Completas")]
        public List<Dashboard> getDashboard(int taskStatus)
        {
            try
            {
                User requester = UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
                Log log = new Log("getDashboard", "GET", requester, DateTime.Now, taskStatus.ToString(), "", "");
                LogDAO.insert(log);
                return DashboardDAO.select(requester, taskStatus);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que devolve as informações do usuário requisitante, identificado pelo NTLM")]
        public User getMyUserInformation()
        {
            try
            {
                return UserDAO.instanceByAlias(HttpContext.Current.Request.LogonUserIdentity.Name);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que recebe um id de um usuário como parâmetro e devolve as informações do usuário informado")]
        public User getUserInformationById(int userId)
        {
            try
            {
                return UserDAO.instanceById(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que recebe um alias de um usuário como parâmetro e devolve as informações do usuário informado")]
        public User getUserInformationByAlias(string alias)
        {
            try
            {
                return UserDAO.instanceByAlias(alias);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }

        [WebMethod(Description = "Método que recebe um nome de um usuário como parâmetro e devolve as informações do usuário informado")]
        public User getUserInformationByName(string name)
        {
            try
            {
                return UserDAO.instanceByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Ops! An error has ocurred: {0}", ex.Message));
            }
        }
    }
}
