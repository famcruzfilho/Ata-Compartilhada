using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Minute")]
    public class Minute
    {
        public int projectId;
        public string name;
        public string projectStatus;
        public string productProjectStage;

        public Minute()
        {
        }

        public Minute(int projectId, string name, string projectStatus, string productProjectStage)
        {
            setProjectId(projectId);
            setName(name);
            setProjectStatus(projectStatus);
            setProductProjectStage(productProjectStage);
        }

        public void setProjectId(int projectId)
        {
            this.projectId = projectId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setProjectStatus(string projectStatus)
        {
            this.projectStatus = projectStatus;
        }

        public void setProductProjectStage(string productProjectStage)
        {
            this.productProjectStage = productProjectStage;
        }

        public int getProjectId()
        {
            return this.projectId;
        }

        public string getName()
        {
            return this.name;
        }

        public string getProjectStatus()
        {
            return this.projectStatus;
        }

        public string getProductProjectStage()
        {
            return this.productProjectStage;
        }

        public string toString()
        {
            return string.Format("ID: {0}, Name: {1}", this.projectId, this.name);
        }
    }
}