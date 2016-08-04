using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class SecurityDAO
    {
        public static bool isPMO(User user, Project project)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                int projectId = project.getProjectId();
                string userAlias = user.getAlias();
                var pmo = from ta in db.team_allocation
                          join p in db.projects on ta.projectId equals p.projectId
                          where ta.users.alias == userAlias && p.projectId == projectId && ta.users.area == "GP"
                          select new { ta.userId };
                if (pmo.ToList().Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool isLeaderOrSubmitter(User user, Project project)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                int projectId = project.getProjectId();
                int userId = user.getUserId();
                string userArea = user.getArea();
                var leader = from p in db.projects
                             where p.leaderOrSubmitter == userId && p.projectId == projectId && userArea == "GP"
                             select new { p.leaderOrSubmitter };
                if (leader.ToList().Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool isResponsibleForTask(User user, Task task)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                int taskId = task.getTaskId();
                string userArea = user.getArea();
                var responsible = from t in db.tasks
                                  where t.taskId == taskId
                                  where task.getResponsibleList().Contains(t.responsible)
                                  select new { t.responsible };
                if (responsible.ToList().Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool isCreatorOfTask(User user, Task task)
        {
            nova_ataEntities db = new nova_ataEntities();
            int taskId = task.getTaskId();
            int userId = user.getUserId();
            var creator = from t in db.tasks
                          where t.taskId == taskId
                          where t.createdBy == userId
                          select new { t.responsible };
            if (creator.ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string encrypt(string word)
        {
            Byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(word);
            return Convert.ToBase64String(bytes);
        }

        public static string decrypt(string word)
        {
            Byte[] bytes = Convert.FromBase64String(word);
            return ASCIIEncoding.ASCII.GetString(bytes);
        }
    }
}