using Natura_Nova_Ata_3._0._0.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Task")]
    public class Task
    {
        public int taskId;
        public int projectId;
        [XmlElement("responsibleList")]
        public string[] responsibleList = null;
        public string notifyMe;
        public string meetingDate;
        public string product;
        public string pWork;
        public string criticalActivity;
        public string activityTitle;
        public string activityDescription;
        public string parent;
        public string grandParent;
        public string responsible;
        public string start;
        public string finish;
        public string status;
        public string lastComment;
        public string activityOrigin;
        public string idProjectTask;
        public string idParentProjectTask;
        public string ident;
        public string hash;
        public string delayReason;
        public string delayDescription;
        public User createdBy;
        public int reworkCount;
        public string actualFinishDate;
        public string newStart;
        public string newFinish;
        public bool isFreezed;
        public bool wasDeleted;
        public bool wasInsertedAfterFreezing;

        public Task()
        {
        }

        public Task(int taskId, int projectId, string notifyMe, string meetingDate, string product, string pWork,
            string criticalActivity, string activityTitle, string activityDescription, string parent,
            string grandParent, string responsible, string start, string finish, string status,
            string lastComment, string activityOrigin, string idProjectTask, string idParentProjectTask,
            string ident, string hash, string delayReason, string delayDescription, User createdBy,
            int reworkCount, string actualFinishDate)
        {
            setTaskId(taskId);
            setProjectId(projectId);
            setNotifyMe(notifyMe);
            setMeetingDate(meetingDate);
            setProduct(product);
            setPWork(pWork);
            setCriticalActivity(criticalActivity);
            setActivityTitle(activityTitle);
            setActivityDescription(activityDescription);
            setParent(parent);
            setGrandParent(grandParent);
            setResponsible(responsible);
            setStart(start);
            setFinish(finish);
            setStatus(status);
            setLastComment(lastComment);
            setActivityOrigin(activityOrigin);
            setIdProjectTask(idProjectTask);
            setIdParentProjectTask(idParentProjectTask);
            setIdent(ident);
            setHash(hash);
            setDelayReason(delayReason);
            setDelayDescription(delayDescription);
            setCreatedBy(createdBy);
            setReworkCount(reworkCount);
            setActualFinishDate(actualFinishDate);
        }

        public Task(int taskId, int projectId, string notifyMe, string meetingDate, string product, string pWork,
            string criticalActivity, string activityTitle, string activityDescription, string parent,
            string grandParent, string responsible, string start, string finish, string status,
            string lastComment, string activityOrigin, string idProjectTask, string idParentProjectTask,
            string ident, string hash, string delayReason, string delayDescription, User createdBy,
            int reworkCount, string actualFinishDate, string newStart, string newFinish, string isFreezed,
            string wasDeleted, string wasInsertedAfterFreezing)
        {
            setTaskId(taskId);
            setProjectId(projectId);
            setNotifyMe(notifyMe);
            setMeetingDate(meetingDate);
            setProduct(product);
            setPWork(pWork);
            setCriticalActivity(criticalActivity);
            setActivityTitle(activityTitle);
            setActivityDescription(activityDescription);
            setParent(parent);
            setGrandParent(grandParent);
            setResponsible(responsible);
            setStart(start);
            setFinish(finish);
            setStatus(status);
            setLastComment(lastComment);
            setActivityOrigin(activityOrigin);
            setIdProjectTask(idProjectTask);
            setIdParentProjectTask(idParentProjectTask);
            setIdent(ident);
            setHash(hash);
            setDelayReason(delayReason);
            setDelayDescription(delayDescription);
            setCreatedBy(createdBy);
            setReworkCount(reworkCount);
            setActualFinishDate(actualFinishDate);
            setNewStart(newStart);
            setNewFinish(newFinish);
            setIsFreezed(isFreezed);
            setWasDeleted(wasDeleted);
            setWasInsertedAfterFreezing(wasInsertedAfterFreezing);
        }

        public void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public void setProjectId(int projectId)
        {
            this.projectId = projectId;
        }

        public void setNotifyMe(string notifyMe)
        {
            this.notifyMe = notifyMe;
        }

        public void setMeetingDate(string meetingDate)
        {
            this.meetingDate = meetingDate;
        }

        public void setProduct(string product)
        {
            this.product = product;
        }

        public void setPWork(string pWork)
        {
            this.pWork = pWork;
        }

        public void setCriticalActivity(string criticalActivity)
        {
            this.criticalActivity = criticalActivity;
        }

        public void setActivityTitle(string activityTitle)
        {
            if (activityTitle.Equals("") || activityTitle.Equals(null))
            {
                this.activityTitle = "Activity without title";
            }
            else
            {
                this.activityTitle = activityTitle;
            }
        }

        public void setActivityDescription(string activityDescription)
        {
            this.activityDescription = activityDescription;
        }

        public void setParent(string parent)
        {
            this.parent = parent;
        }

        public void setGrandParent(string grandParent)
        {
            this.grandParent = grandParent;
        }

        public void setResponsible(string responsible)
        {
            this.responsible = responsible;
            this.responsibleList = this.responsible.Split(';');
        }

        public void setStart(string start)
        {
            this.start = start;
        }

        public void setFinish(string finish)
        {
            this.finish = finish;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public void setLastComment(string lastComment)
        {
            this.lastComment = lastComment;
        }

        public void setActivityOrigin(string activityOrigin)
        {
            this.activityOrigin = activityOrigin;
        }

        public void setIdProjectTask(string idProjectTask)
        {
            this.idProjectTask = idProjectTask;
        }

        public void setIdParentProjectTask(string idParentProjectTask)
        {
            this.idParentProjectTask = idParentProjectTask;
        }

        public void setIdent(string ident)
        {
            this.ident = ident;
        }

        public void setHash(string hash)
        {
            this.hash = hash;
        }

        public void setDelayReason(string delayReason)
        {
            this.delayReason = delayReason;
        }

        public void setDelayDescription(string delayDescription)
        {
            this.delayDescription = delayDescription;
        }

        public void setCreatedBy(User createdBy)
        {
            this.createdBy = createdBy;
        }

        public void setReworkCount(int reworkCount)
        {
            this.reworkCount = reworkCount;
        }

        public void setActualFinishDate(string actualFinishDate)
        {
            this.actualFinishDate = actualFinishDate;
        }

        public void setNewStart(string newStart)
        {
            this.newStart = newStart;
        }

        public void setNewFinish(string newFinish)
        {
            this.newFinish = newFinish;
        }

        public void setIsFreezed(bool isFreezed)
        {
            this.isFreezed = isFreezed;
        }

        public void setIsFreezed(string isFreezed)
        {
            if (isFreezed == null || isFreezed.Equals("false"))
            {
                this.isFreezed = false;
            }
            else
            {
                this.isFreezed = true;
            }
        }

        public void setWasDeleted(bool wasDeleted)
        {
            this.wasDeleted = wasDeleted;
        }

        public void setWasDeleted(string wasDeleted)
        {
            if (wasDeleted == null || wasDeleted.Equals("false"))
            {
                this.wasDeleted = false;
            }
            else
            {
                this.wasDeleted = true;
            }
        }

        public void setWasInsertedAfterFreezing(bool wasInsertedAfterFreezing)
        {
            this.wasInsertedAfterFreezing = wasInsertedAfterFreezing;
        }

        public void setWasInsertedAfterFreezing(string wasInsertedAfterFreezing)
        {
            if (wasInsertedAfterFreezing == null || wasInsertedAfterFreezing.Equals("false"))
            {
                this.wasInsertedAfterFreezing = false;
            }
            else
            {
                this.wasInsertedAfterFreezing = true;
            }
        }

        public int getTaskId()
        {
            return this.taskId;
        }

        public int getProjectId()
        {
            return this.projectId;
        }

        public string getNotifyMe()
        {
            return this.notifyMe;
        }

        public string getMeetingDate()
        {
            return this.meetingDate;
        }

        public string getProduct()
        {
            return this.product;
        }

        public string getPWork()
        {
            return this.pWork;
        }

        public string getCriticalActivity()
        {
            return this.criticalActivity;
        }

        public string getActivityTitle()
        {
            return this.activityTitle;
        }

        public string getActivityDescription()
        {
            return this.activityDescription;
        }

        public string getParent()
        {
            return this.parent;
        }

        public string getGrandParent()
        {
            return this.grandParent;
        }

        public string getResponsible()
        {
            return this.responsible;
        }

        public string[] getResponsibleList()
        {
            return this.responsibleList;
        }

        public string getStart()
        {
            return this.start;
        }

        public string getFinish()
        {
            return this.finish;
        }

        public string getStatus()
        {
            return this.status;
        }

        public string getLastComment()
        {
            return this.lastComment;
        }

        public string getActivityOrigin()
        {
            return this.activityOrigin;
        }

        public string getIdProjectTask()
        {
            return this.idProjectTask;
        }

        public string getIdParentProjectTask()
        {
            return this.idParentProjectTask;
        }

        public string getIdent()
        {
            return this.ident;
        }

        public string getHash()
        {
            return this.hash;
        }

        public string getDelayReason()
        {
            return this.delayReason;
        }

        public string getDelayDescription()
        {
            return this.delayDescription;
        }

        public User getCreatedBy()
        {
            return this.createdBy;
        }

        public int getReworkCount()
        {
            return this.reworkCount;
        }

        public string getActualFinishDate()
        {
            return this.actualFinishDate;
        }

        public string getNewStart()
        {
            return this.newStart;
        }

        public string getNewFinish()
        {
            return this.newFinish;
        }

        public bool getIsFreezed()
        {
            return this.isFreezed;
        }

        public bool getWasDeleted()
        {
            return this.wasDeleted;
        }

        public bool getWasInsertedAfterFreezing()
        {
            return this.wasInsertedAfterFreezing;
        }

        public string toString()
        {
            return string.Format("Id: {0}", this.taskId);
        }

        public static Task[] xmlToArrayOfTasks(User requester, HttpContext context)
        {
            try
            {
                Stream stream = context.Request.InputStream;
                stream.Position = 0;
                SoapFormatter serializer = new SoapFormatter();
                Task[] listOfTasks = (Task[])serializer.Deserialize(stream);
                stream.Close();
                return listOfTasks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}