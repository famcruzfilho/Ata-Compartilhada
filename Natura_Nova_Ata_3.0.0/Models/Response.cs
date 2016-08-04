using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Comment")]
    public class Response
    {
        public int taskId;
        public string status;
        public string hash;

        public Response()
        {
        }

        public Response(int taskId, string status, string hash)
        {
            setTaskId(taskId);
            setStatus(status);
            setHash(hash);
        }

        public void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public void setHash(string hash)
        {
            this.hash = hash;
        }

        public int getTaskId()
        {
            return this.taskId;
        }

        public string getStatus()
        {
            return this.status;
        }

        public string getHash()
        {
            return this.hash;
        }

        public string toString()
        {
            return string.Format("Task ID: {0}, Status: {1}, Hash: {2}", this.taskId, this.status, this.hash);
        }
    }
}