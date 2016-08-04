using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Project")]
    public class Log
    {
        public int logId;
        public string controller;
        public string requestType;
        public User requester;
        public DateTime dateTime;
        public string date;
        public string time;
        public string attribute1;
        public string attribute2;
        public string body;

        public Log()
        {
        }

        public Log(string controller, string requestType, User requester, DateTime dateTime,
            string attribute1, string attribute2, string body)
        {
            setController(controller);
            setRequestType(requestType);
            setRequester(requester);
            setDateTime(dateTime);
            setDate();
            setTime();
            setAttribute1(attribute1);
            setAttribute2(attribute2);
            setBody(body);
        }

        public Log(string controller, string requestType, User requester, string date,
            string time, string attribute1, string attribute2, string body)
        {
            setController(controller);
            setRequestType(requestType);
            setRequester(requester);
            setDate(date);
            setTime(time);
            setAttribute1(attribute1);
            setAttribute2(attribute2);
            setBody(body);
        }

        public Log(int logId, string controller, string requestType, User requester, string date,
            string time, string attribute1, string attribute2, string body)
        {
            setLogId(logId);
            setController(controller);
            setRequestType(requestType);
            setRequester(requester);
            setDate(date);
            setTime(time);
            setAttribute1(attribute1);
            setAttribute2(attribute2);
            setBody(body);
        }

        public Log(int logId, string controller, string requestType, User requester, DateTime dateTime,
            string attribute1, string attribute2, string body)
        {
            setLogId(logId);
            setController(controller);
            setRequestType(requestType);
            setRequester(requester);
            setDateTime(dateTime);
            setDate();
            setTime();
            setAttribute1(attribute1);
            setAttribute2(attribute2);
            setBody(body);
        }

        public void setLogId(int logId)
        {
            this.logId = logId;
        }

        public void setController(string controller)
        {
            this.controller = controller;
        }

        public void setRequestType(string requestType)
        {
            this.requestType = requestType;
        }

        public void setRequester(User requester)
        {
            this.requester = requester;
        }

        public void setDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public void setDate()
        {
            this.date = string.Format("{0:dd/MM/yyyy}", this.dateTime);
        }

        public void setDate(string date)
        {
            this.date = date;
        }

        public void setTime()
        {
            this.time = string.Format("{0:HH:mm:ss}", this.dateTime);
        }

        public void setTime(string time)
        {
            this.time = time;
        }

        public void setAttribute1(string attribute1)
        {
            this.attribute1 = attribute1;
        }

        public void setAttribute2(string attribute2)
        {
            this.attribute2 = attribute2;
        }

        public void setBody(string body)
        {
            this.body = body;
        }

        public int getLogId()
        {
            return this.logId;
        }

        public string getController()
        {
            return this.controller;
        }

        public string getRequestType()
        {
            return this.requestType;
        }

        public User getRequester()
        {
            return this.requester;
        }

        public DateTime getDateTime()
        {
            return this.dateTime;
        }

        public string getDate()
        {
            return this.date;
        }

        public string getTime()
        {
            return this.time;
        }

        public string getAttribute1()
        {
            return this.attribute1;
        }

        public string getAttribute2()
        {
            return this.attribute2;
        }

        public string getBody()
        {
            return this.body;
        }

        public string toString()
        {
            return string.Format("ID: {0}, Controller: {1}, Requester: {3}", this.logId, this.controller, this.requester.name);
        }
    }
}