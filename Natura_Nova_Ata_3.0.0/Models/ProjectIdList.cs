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
    [XmlRoot("ProjectIdList")]
    public class ProjectIdList
    {
        [XmlElement("projectIdList")]
        public int[] projectIdList = null;

        public ProjectIdList()
        {
        }

        public ProjectIdList(int[] projectIdList)
        {
            setProjectIdList(projectIdList);
        }

        public void addProjectToList(int position, int projectId)
        {
            this.projectIdList[position] = projectId;
        }

        public void setProjectIdList(int[] projectIdList)
        {
            this.projectIdList = projectIdList;
        }

        public int[] getProjectList()
        {
            return this.projectIdList;
        }

        public static int[] xmlToArrayOfIds(User requester, HttpContext context)
        {
            try
            {
                Stream stream = context.Request.InputStream;
                stream.Position = 0;
                SoapFormatter serializer = new SoapFormatter();
                int[] listOfIds = (int[])serializer.Deserialize(stream);
                stream.Close();
                return listOfIds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}