using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class MSProjectDAO
    {
        public static Response delete(User requester, int taskId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var t = db.tasks.Find(taskId);
                if (t != null)
                {
                    t.wasDeleted = "true";
                    db.SaveChanges();
                }
                return new Response(taskId, "Deleted", "");
            }
            catch
            {
                return new Response(taskId, "Fail", "");
            }
        }

        public static List<Task> select(User requester, int projectId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var tasks = from t in db.tasks
                            where t.projectId == projectId
                            where t.activityOrigin.ToUpper() == "PROJECT"
                            select t;
                List<Task> listOfTasks = new List<Task>();
                foreach (var t in tasks)
                {
                    Task task = new Task(t.taskId, t.projectId, t.notifyMe, t.meetingDate, t.product, t.pWork, t.criticalActivity,
                        t.activityTitle, t.activityDescription, t.parent, t.grandParent, t.responsible, t.start, t.finish,
                        t.status, CommentDAO.selectLastComment(t.taskId), t.activityOrigin, t.idProjectTask, t.idParentProjectTask,
                        t.ident, t.hash, t.delayDescription, t.delayDescription, UserDAO.instanceById((int)t.createdBy),
                        (int)t.reworkCount, t.actualFinishDate, t.newStart, t.newFinish, t.isFreezed, t.wasDeleted,
                        t.wasInsertedAfterFreezing);
                    listOfTasks.Add(task);
                }
                return listOfTasks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Update> select(int projectId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                List<Update> listOfUpdates = new List<Update>();
                var tasks = from t in db.tasks
                            where t.projectId == projectId
                            where t.activityOrigin.ToUpper() == "PROJECT" && t.idParentProjectTask != ""
                            select new { t.taskId, t.pWork };
                foreach (var t in tasks)
                {
                    listOfUpdates.Add(new Update(t.taskId, t.pWork));
                }
                return listOfUpdates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Response insertOrUpdate(User requester, Task task)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                bool isNew = false;
                var t = (dynamic)null;
                int projectId = task.getProjectId();
                try
                {
                    string idProjectTask = task.getIdProjectTask();
                    t = (from p in db.tasks
                         where p.projectId == projectId
                         where p.idProjectTask == idProjectTask
                         where p.wasDeleted.ToUpper() == "FALSE"
                         select p).First();
                    task.setTaskId(t.taskId);
                    task.setHash(t.hash);
                }
                catch
                {
                    isNew = true;
                }
                bool isChangeAllowed = false;
                var project = (from p in db.projects
                               where p.projectId == projectId
                               select p).First();
                if (ProjectDAO.stageCorrespondence(project.productProjectStage) <= 3)
                {
                    isChangeAllowed = true;
                }
                if (isNew)
                {
                    t = db.tasks.Create();
                    t.createdBy = requester.getUserId();
                    t.creationDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    t.wasDeleted = "false";
                    t.reworkCount = 0;
                    if (!isChangeAllowed)
                    {
                        t.wasInsertedAfterFreezing = "true";
                        t.isFreezed = "true";
                    }
                    else
                    {
                        t.wasInsertedAfterFreezing = "false";
                        t.isFreezed = "false";
                    }
                }
                else
                {
                    if (!isChangeAllowed && t.wasInsertedAfterFreezing.Equals("false"))
                    {
                        t.pWork = task.getPWork();
                        t.status = task.getStatus();
                        t.hash = task.getHash();
                        t.newStart = task.getStart();
                        t.newFinish = task.getFinish();
                        db.SaveChanges();
                        return new Response(task.getTaskId(), "Edited", task.getHash());
                    }
                }
                t.projectId = task.getProjectId();
                t.notifyMe = task.getNotifyMe();
                t.meetingDate = task.getMeetingDate();
                t.product = task.getProduct();
                if (task.getPWork().Equals("100") || task.getStatus().ToUpper().Equals("COMPLETO"))
                {
                    t.status = "Completo";
                    t.pWork = "100";
                    t.actualFinishDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                }
                else
                {
                    t.status = task.getStatus();
                    t.pWork = task.getPWork();
                    t.actualFinishDate = task.getActualFinishDate();
                }
                t.criticalActivity = task.getCriticalActivity();
                t.activityTitle = task.getActivityTitle();
                t.activityDescription = task.getActivityDescription();
                t.parent = task.getParent();
                t.grandParent = task.getGrandParent();
                t.responsible = task.getResponsible();
                t.start = task.getStart();
                t.finish = task.getFinish();
                t.activityOrigin = task.getActivityOrigin();
                t.idProjectTask = task.getIdProjectTask();
                t.idParentProjectTask = task.getIdParentProjectTask();
                t.ident = task.getIdent();
                t.hash = task.getHash();
                t.newStart = task.getNewStart();
                t.newFinish = task.getNewFinish();
                if (isNew)
                {
                    db.tasks.Add(t);
                }
                db.SaveChanges();
                if (isNew)
                {
                    return new Response(t.taskId, "Created", task.getHash());
                }
                else
                {
                    return new Response(task.getTaskId(), "Edited", task.getHash());
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public static List<Response> insertOrUpdate(User requester, Task[] listOfTasks)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                List<Response> listOfResponses = new List<Response>();
                int projectId = listOfTasks[0].getProjectId();
                var tasks = from t in db.tasks
                            where t.projectId == projectId
                            where t.activityOrigin.ToUpper().Equals("PROJECT")
                            select t;
                var result = tasks.ToList().Where(x => !listOfTasks.Any(y => x.idProjectTask == y.getIdProjectTask()));
                if (result.Count() > 0)
                {
                    foreach (var task in result)
                    {
                        listOfResponses.Add(delete(requester, task.taskId));
                    }
                }
                foreach (Task task in listOfTasks)
                {
                    listOfResponses.Add(insertOrUpdate(requester, task));
                }
                return listOfResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}