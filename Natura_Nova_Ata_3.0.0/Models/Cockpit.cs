using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Cockpit")]
    public class Cockpit
    {
        public int cockpitId;
        public int projectId;
        public string projectName;
        public string description;
        public string type;
        public string code;
        public string dummyCode;
        public string parentSellCode;
        public string parentZpac;
        public string workItemText;
        public string status;
        public string responsible;
        public string generation;
        public string start;
        public string end;
        public string deadline;
        public string hash;

        public Cockpit()
        {
        }

        public Cockpit(int projectId, string projectName, string description, string type, string code, string dummyCode,
            string parentSellCode, string parentZpac, string workItemText, string status, string responsible,
            string generation, string start, string end, string deadline, string hash)
        {
            setProjectId(projectId);
            setProjectName(projectName);
            setDescription(description);
            setType(type);
            setCode(code);
            setDummyCode(dummyCode);
            setParentSellCode(parentSellCode);
            setParentZpac(parentZpac);
            setWorkItemText(workItemText);
            setStatus(status);
            setResponsible(responsible);
            setGeneration(generation);
            setStart(start);
            setEnd(end);
            setDeadline(deadline);
            setHash(hash);
        }

        public Cockpit(int cockpitId, int projectId, string projetctName, string description, string type, string code,
            string dummyCode, string parentSellCode, string parentZpac, string hash)
        {
            setCockpitId(cockpitId);
            setProjectId(projectId);
            setProjectName(projectName);
            setDescription(description);
            setType(type);
            setCode(code);
            setDummyCode(dummyCode);
            setParentSellCode(parentSellCode);
            setParentZpac(parentZpac);
            setHash(hash);
        }

        public Cockpit(int cockpitId, int projectId, string projectName, string description, string type, string code,
            string dummyCode, string parentSellCode, string parentZpac, string workItemText, string status, string responsible,
            string generation, string start, string end, string deadline, string hash)
        {
            setCockpitId(cockpitId);
            setProjectId(projectId);
            setProjectName(projectName);
            setDescription(description);
            setType(type);
            setCode(code);
            setDummyCode(dummyCode);
            setParentSellCode(parentSellCode);
            setParentZpac(parentZpac);
            setWorkItemText(workItemText);
            setStatus(status);
            setResponsible(responsible);
            setGeneration(generation);
            setStart(start);
            setEnd(end);
            setDeadline(deadline);
            setHash(hash);
        }

        public void setCockpitId(int cockpitId)
        {
            this.cockpitId = cockpitId;
        }

        public void setProjectId(int projectId)
        {
            this.projectId = projectId;
        }

        public void setProjectName(string projectName)
        {
            this.projectName = projectName;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public void setCode(string code)
        {
            this.code = code;
        }

        public void setDummyCode(string dummyCode)
        {
            this.dummyCode = dummyCode;
        }

        public void setParentSellCode(string parentSellCode)
        {
            this.parentSellCode = parentSellCode;
        }

        public void setParentZpac(string parentZpac)
        {
            this.parentZpac = parentZpac;
        }

        public void setWorkItemText(string workItemText)
        {
            this.workItemText = workItemText;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public void setResponsible(string responsible)
        {
            this.responsible = responsible;
        }

        public void setGeneration(string generation)
        {
            this.generation = generation;
        }

        public void setStart(string start)
        {
            this.start = start;
        }

        public void setEnd(string end)
        {
            this.end = end;
        }

        public void setDeadline(string deadline)
        {
            this.deadline = deadline;
        }

        public void setHash(string hash)
        {
            this.hash = hash;
        }

        public int getCockpitId()
        {
            return this.cockpitId;
        }

        public int getProjectId()
        {
            return this.projectId;
        }

        public string getProjectName()
        {
            return this.projectName;
        }

        public string getDescription()
        {
            return this.description;
        }

        public string getType()
        {
            return this.type;
        }

        public string getCode()
        {
            return this.code;
        }

        public string getDummyCode()
        {
            return this.dummyCode;
        }

        public string getParentSellCode()
        {
            return this.parentSellCode;
        }

        public string getParentZpac()
        {
            return this.parentZpac;
        }

        public string getWorkItemText()
        {
            return this.workItemText;
        }

        public string getStatus()
        {
            return this.status;
        }

        public string getResponsible()
        {
            return this.responsible;
        }

        public string getGeneration()
        {
            return this.generation;
        }

        public string getStart()
        {
            return this.start;
        }

        public string getEnd()
        {
            return this.end;
        }

        public string getDeadline()
        {
            return this.deadline;
        }

        public string getHash()
        {
            return this.hash;
        }

        public string toString()
        {
            return string.Format("Id: {0}", this.cockpitId);
        }

        public static void cockpitToXml(Cockpit[] listOfCockpits)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\resource\Desktop\Nova Ata\cockpits.xml", FileMode.OpenOrCreate);
                SoapFormatter serializer = new SoapFormatter();
                serializer.Serialize(fs, listOfCockpits);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Cockpit[] xmlToArrayOfCockpits(User requester, HttpContext context)
        {
            try
            {
                Stream stream = context.Request.InputStream;
                stream.Position = 0;
                SoapFormatter serializer = new SoapFormatter();
                Cockpit[] listOfCockpits = (Cockpit[])serializer.Deserialize(stream);
                stream.Close();
                return listOfCockpits;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}