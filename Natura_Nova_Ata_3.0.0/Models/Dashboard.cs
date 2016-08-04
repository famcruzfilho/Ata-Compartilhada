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
    [XmlRoot("Dashboard")]
    public class Dashboard
    {
        public int projectId;
        public string projectName;
        [XmlArray]
        public List<Task> listOfTasks = new List<Task>();

        public Dashboard()
        {
        }

        public Dashboard(string projectIdAndName)
        {
            setProjectIdAndName(projectIdAndName);
        }

        public Dashboard(int projectId, string projectName, List<Task> listOfTasks)
        {
            setProjectId(projectId);
            setProjectName(projectName);
            setListOfTasks(listOfTasks);
        }

        public void setProjectId(int projectId)
        {
            this.projectId = projectId;
        }
        
        public void setProjectName(string projectName)
        {
            this.projectName = projectName;
        }

        public void setProjectIdAndName(string projectIdAndName)
        {
            this.projectId = Convert.ToInt32(projectIdAndName.Split('?')[0]);
            this.projectName = projectIdAndName.Split('?')[1];
        }

        public void addTaskToList(Task task)
        {
            this.listOfTasks.Add(task);
        }

        public void setListOfTasks(List<Task> listOfTasks)
        {
            this.listOfTasks = listOfTasks;
        }

        public int getProjectId()
        {
            return this.projectId;
        }

        public string getProjectName()
        {
            return this.projectName;
        }

        public List<Task> getListOfTasks()
        {
            return this.listOfTasks;
        }

        public static void dashboardToXml(Dashboard dashboard)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\resource\Desktop\Nova Ata\dashboard.xml", FileMode.OpenOrCreate);
                SoapFormatter serializer = new SoapFormatter();
                serializer.Serialize(fs, dashboard);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Dashboard xmlToDashboard(User requester, HttpContext context)
        {
            try
            {
                Stream stream = context.Request.InputStream;
                stream.Position = 0;
                SoapFormatter serializer = new SoapFormatter();
                Dashboard dashboard = (Dashboard)serializer.Deserialize(stream);
                stream.Close();
                return dashboard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}