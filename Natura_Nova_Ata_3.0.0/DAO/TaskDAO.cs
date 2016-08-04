using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class TaskDAO
    {
        public static Task instanceById(int taskId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var t = db.tasks.Find(taskId);
                Task task = new Task(t.taskId, t.projectId, t.notifyMe, t.meetingDate, t.product, t.pWork, t.criticalActivity,
                    t.activityTitle, t.activityDescription, t.parent, t.grandParent, t.responsible, t.start, t.finish,
                    t.status, CommentDAO.selectLastComment(t.taskId), t.activityOrigin, t.idProjectTask, t.idParentProjectTask,
                    t.ident, t.hash, t.delayDescription, t.delayDescription, UserDAO.instanceById((int)t.createdBy),
                    (int)t.reworkCount, t.actualFinishDate, t.newStart, t.newFinish, t.isFreezed, t.wasDeleted,
                    t.wasInsertedAfterFreezing);
                return task;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Response finishTask(User requester, Task task)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var t = db.tasks.Find(task.getTaskId());
                if (t != null)
                {
                    t.status = "Completo";
                    t.pWork = "100";
                    t.actualFinishDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    db.SaveChanges();
                }
                return new Response(task.getTaskId(), "Edited", task.getHash());
            }
            catch
            {
                return new Response(task.getTaskId(), "Fail", task.getHash());
            }
        }

        public static Response delete(User requester, Task task)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var t = db.tasks.Find(task.getTaskId());
                if (t != null)
                {
                    t.wasDeleted = "true";
                    db.SaveChanges();
                }
                return new Response(task.getTaskId(), "Deleted", task.getHash());
            }
            catch
            {
                return new Response(task.getTaskId(), "Fail", task.getHash());
            }
        }

        public static Response insertOrUpdate(User requester, Task task)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                if (task.getTaskId() < 0)
                {
                    if (!task.getCriticalActivity().Equals("5000"))
                    {
                        int taskId = Math.Abs(task.getTaskId());
                        task.setTaskId(taskId);
                        return TaskDAO.delete(requester, task);
                    }
                    else
                    {
                        return new Response(task.getTaskId(), "Failed. Launch Exetution activity can't be deleted", task.getHash());
                    }
                }
                bool isNew = false;
                bool isChangeAllowed = false;
                int projectId = task.getProjectId();
                var project = (from p in db.projects
                               where p.projectId == projectId
                               select p).First();
                if (ProjectDAO.stageCorrespondence(project.productProjectStage) <= 3)
                {
                    isChangeAllowed = true;
                }
                var t = (dynamic)null;
                if (task.getTaskId() == 0)
                {
                    isNew = true;
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
                    isNew = false;
                    t = db.tasks.Find(task.getTaskId());
                    if (t == null)
                    {
                        return new Response(task.getTaskId(), "Fail. Result not found", task.getHash());
                    }
                    if (!isChangeAllowed && t.wasInsertedAfterFreezing.Equals("false"))
                    {
                        t.pWork = task.getPWork();
                        t.status = task.getStatus();
                        t.hash = task.getHash();
                        if (!task.getStart().Equals(t.start))
                        {
                            t.newStart = task.getStart();
                        }
                        if (!task.getFinish().Equals(t.finish))
                        {
                            t.newFinish = task.getFinish();
                        }
                        t.criticalActivity = task.getCriticalActivity();
                        t.activityTitle = task.getActivityTitle();
                        t.activityDescription = task.getActivityDescription();
                        t.parent = task.getParent();
                        t.grandParent = task.getGrandParent();
                        t.responsible = task.getResponsible();
                        t.ident = task.getIdent();
                        db.SaveChanges();
                        return new Response(task.getTaskId(), "Edited", task.getHash());
                    }
                }
                t.projectId = task.getProjectId();
                t.notifyMe = task.getNotifyMe();
                t.meetingDate = task.getMeetingDate();
                t.product = task.getProduct();
                /*if (task.getPWork().Equals("100") || task.getStatus().ToUpper().Equals("COMPLETO"))
                {
                    t.status = "Completo";
                    t.pWork = "100";
                    t.actualFinishDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                }
                else
                {
                    if (!isNew)
                    {
                        if (!task.getStatus().ToUpper().Equals("COMPLETO") && t.status.ToUpper().Equals("COMPLETO"))
                        {
                            t.reworkCount = Convert.ToInt32(t.reworkCount) + 1;
                        }
                    }
                    else
                    {
                        t.reworkCount = task.getReworkCount();
                    }
                    t.status = task.getStatus();
                    t.pWork = task.getPWork();
                    t.actualFinishDate = task.getActualFinishDate();
                }*/
                if (!isNew)
                {
                    if (!task.getStatus().ToUpper().Equals("COMPLETO") && t.status.ToUpper().Equals("COMPLETO"))
                    {
                        t.reworkCount = Convert.ToInt32(t.reworkCount) + 1;
                        t.status = task.getStatus();
                        t.pWork = task.getPWork();
                    }
                    else if (task.getActivityOrigin().ToUpper().Equals("PROJECT"))
                    {
                        t.status = task.getStatus();
                        t.pWork = task.getPWork();
                    }
                }
                else
                {
                    t.status = task.getStatus();
                    t.pWork = task.getPWork();
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
                    return new Response(task.getTaskId(), "Created", task.getHash());
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
                List<Response> listOfResponses = new List<Response>();
                int projectId = 0;
                foreach (Task task in listOfTasks)
                {
                    if (projectId == 0)
                    {
                        projectId = task.getProjectId();
                    }
                    listOfResponses.Add(insertOrUpdate(requester, task));
                }
                if (projectId > 0)
                {
                    checkIfNotificationIsNecessary(projectId);
                }
                return listOfResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void checkIfNotificationIsNecessary(int projectId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                string projectName = string.Empty;
                string businessUnit = string.Empty;
                bool isAllCompleted = true;
                bool needsNotification = false;
                var tasks = from t in db.tasks
                            where t.criticalActivity == "5000"
                            where t.projectId == projectId
                            select new { t.status, t.projects.businessUnit, t.projects.name };
                if (tasks.ToList().Count() > 0)
                {
                    businessUnit = tasks.ToList()[0].businessUnit;
                    projectName = tasks.ToList()[0].name;
                    foreach (var t in tasks)
                    {
                        if (!t.status.ToUpper().Equals("COMPLETO"))
                        {
                            isAllCompleted = false;
                        }
                    }
                }
                else
                {
                    isAllCompleted = false;
                }
                var notification = (dynamic)null;
                notification = db.notifications.Find(projectId);
                if (notification == null)
                {
                    needsNotification = true;
                    notification = db.notifications.Create();
                    notification.projectId = projectId;
                    notification.status = "NOT SENT";
                    db.notifications.Add(notification);
                    db.SaveChanges();
                }
                else
                {
                    if (notification.status.Equals("NOT SENT"))
                    {
                        needsNotification = true;
                    }
                }
                if (isAllCompleted && needsNotification)
                {
                    notification.status = "SENT";
                    db.SaveChanges();
                    Mail.sendMail(0, UserDAO.instanceByBusinessUnit(businessUnit), projectId, projectName);
                }
                if (!isAllCompleted && !needsNotification)
                {
                    notification.status = "NOT SENT";
                    db.SaveChanges();
                    Mail.sendMail(1, UserDAO.instanceByBusinessUnit(businessUnit), projectId, projectName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Task> select(User requester, int projectId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                List<Task> listOfTasks = new List<Task>();
                var tasks = from t in db.tasks
                            where t.projectId == projectId && t.wasDeleted == "false"
                            select t;
                foreach (var t in tasks)
                {
                    Task task = new Task(t.taskId, t.projectId, t.notifyMe, t.meetingDate, t.product, t.pWork, t.criticalActivity,
                        t.activityTitle, t.activityDescription, t.parent, t.grandParent, t.responsible, t.start, t.finish,
                        t.status, CommentDAO.selectLastComment(t.taskId), t.activityOrigin, t.idProjectTask, t.idParentProjectTask,
                        t.ident, t.hash, t.delayReason, t.delayDescription, UserDAO.instanceById((int)t.createdBy),
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
    }
}