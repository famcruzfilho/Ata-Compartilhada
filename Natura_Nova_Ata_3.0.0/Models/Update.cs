using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Update")]
    public class Update
    {
        public int taskId;
        public string pWork;

        public Update()
        {
        }

        public Update(int taskId, string pWork)
        {
            setTaskId(taskId);
            setPWork(pWork);
        }

        public void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public void setPWork(string pWork)
        {
            this.pWork = pWork;
        }

        public int getTaskId()
        {
            return this.taskId;
        }

        public string getPWork()
        {
            return this.pWork;
        }
    }
}