using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class DashboardDAO
    {
        public static List<Dashboard> select(User requester, int taskStatus)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                int userId = requester.getUserId();
                string userArea = requester.getArea();
                string userAlias = requester.getAlias();
                List<Dashboard> listOfDashboards = new List<Dashboard>();
                var projects = from ta in db.team_allocation
                               join p in db.projects on ta.projectId equals p.projectId
                               join u in db.users on ta.userId equals u.userId
                               where (u.alias == userAlias && ta.userId == u.userId) || (p.leaderOrSubmitter == userId)
                               group ta by new { p.projectId, p.name, p.projectStatus, p.productProjectStage, p.parentProgramIDNumber, p.parentProgramName} into g
                               orderby g.Key.projectId ascending
                               select new { g.Key.projectId, g.Key.name, g.Key.projectStatus, g.Key.productProjectStage, g.Key.parentProgramIDNumber, g.Key.parentProgramName };
                List<string> listOfIds = new List<string>();
                foreach (var project in projects)
                {
                    try
                    {
                        if (!listOfIds.Any(y => y == string.Format("{0}?{1}", project.projectId, project.name)))
                        {
                            listOfIds.Add(string.Format("{0}?{1}", project.projectId, project.name));
                        }
                        if (project.parentProgramIDNumber != "0" && !listOfIds.Any(x => x == string.Format("{0}?{1}", project.parentProgramIDNumber, project.parentProgramName)))
                        {
                            listOfIds.Add(string.Format("{0}?{1}", project.parentProgramIDNumber, project.parentProgramName));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                var tasks = (dynamic)null;
                foreach (string project in listOfIds)
                {
                    Dashboard dashboard = new Dashboard(project);
                    int projectId = dashboard.getProjectId();
                    //Somente atividades em andamento ou atrasadas
                    if (taskStatus == 1)
                    {
                        tasks = from t in db.tasks
                                join p in db.projects on t.projectId equals p.projectId
                                where t.projectId == projectId
                                where t.status.ToUpper() == "ANDAMENTO" || t.status.ToUpper() == "ATRASADO"
                                where t.responsible.Contains(userArea)
                                orderby t.finish ascending
                                select new { tarefas = t, projeto = p };
                    }
                    //Todas as atividades
                    else if (taskStatus == 0)
                    {
                        tasks = from t in db.tasks
                                join p in db.projects on t.projectId equals p.projectId
                                where t.projectId == projectId
                                where t.responsible.Contains(userArea)
                                orderby t.finish ascending
                                select new { tarefas = t, projeto = p };
                    }
                    //Somente atividades completas
                    else
                    {
                        tasks = from t in db.tasks
                                join p in db.projects on t.projectId equals p.projectId
                                where t.projectId == projectId
                                where t.status.ToUpper() == "COMPLETO"
                                where t.responsible.Contains(userArea)
                                orderby t.finish ascending
                                select new { tarefas = t, projeto = p };
                    }
                    foreach (var task in tasks)
                    {
                        Task t = new Task(task.tarefas.taskId, task.tarefas.projectId, task.tarefas.notifyMe, task.tarefas.meetingDate,
                            task.tarefas.product, task.tarefas.pWork, task.tarefas.criticalActivity, task.tarefas.activityTitle,
                            task.tarefas.activityDescription, task.tarefas.parent, task.tarefas.grandParent, task.tarefas.responsible,
                            task.tarefas.start, task.tarefas.finish, task.tarefas.status, CommentDAO.selectLastComment(task.tarefas.taskId),
                            task.tarefas.activityOrigin, task.tarefas.idProjectTask, task.tarefas.idParentProjectTask, task.tarefas.ident,
                            task.tarefas.hash, task.tarefas.delayReason, task.tarefas.delayDescription, requester, task.tarefas.reworkCount,
                            task.tarefas.actualFinishDate);
                        dashboard.addTaskToList(t);
                    }
                    if (dashboard.listOfTasks.Count() > 0)
                    {
                        listOfDashboards.Add(dashboard);
                    }
                }
                return listOfDashboards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}