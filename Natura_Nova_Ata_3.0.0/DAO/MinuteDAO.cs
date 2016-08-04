using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class MinuteDAO
    {
        public static List<Minute> select(User requester, int projectStatus)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                List<Minute> lm = new List<Minute>();
                var proj = (dynamic)null;
                int userId = requester.getUserId();
                string userAlias = requester.getAlias();
                switch (projectStatus)
                {
                    //Retorna todos os projetos
                    case 0:
                        proj = from ta in db.team_allocation
                               join p in db.projects on ta.projectId equals p.projectId
                               join u in db.users on ta.userId equals u.userId
                               where (u.alias == userAlias && ta.userId == u.userId) || (p.leaderOrSubmitter == userId)
                               group ta by new { p.projectId, p.name, p.projectStatus, p.productProjectStage, p.parentProgramIDNumber } into g
                               orderby g.Key.projectId ascending
                               select new { idProjetoGensight = g.Key.projectId, nomeProjetoGensight = g.Key.name, statusProjeto = g.Key.projectStatus, estagio = g.Key.productProjectStage, programa = g.Key.parentProgramIDNumber };
                        break;
                    //Retorna apenas projetos ativos ou programas
                    case 1:
                        proj = from ta in db.team_allocation
                               join p in db.projects on ta.projectId equals p.projectId
                               join u in db.users on ta.userId equals u.userId
                               where p.projectStatus == "ACTIVE" || p.productProjectStage == "LAUNCH EXECUTION" || p.productProjectStage == "PROGRAMA"
                               where (u.alias == userAlias && ta.userId == u.userId) || (p.leaderOrSubmitter == userId)
                               group ta by new { p.projectId, p.name, p.projectStatus, p.productProjectStage, p.parentProgramIDNumber } into g
                               orderby g.Key.projectId ascending
                               select new { idProjetoGensight = g.Key.projectId, nomeProjetoGensight = g.Key.name, statusProjeto = g.Key.projectStatus, estagio = g.Key.productProjectStage, programa = g.Key.parentProgramIDNumber };
                        break;
                    default:
                        throw new Exception("Invalid option selected");
                }
                List<int> listAll = new List<int>();
                foreach (var p in proj)
                {
                    try
                    {
                        if (!listAll.Any(y => y == p.idProjetoGensight))
                        {
                            listAll.Add(p.idProjetoGensight);
                        }
                        if (p.programa != "0" && !listAll.Any(x => x == Convert.ToInt32(p.programa)))
                        {
                            listAll.Add(Convert.ToInt32(p.programa));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                proj = from p in db.projects
                       where listAll.Contains(p.projectId)
                       select new { p.projectId, p.name, p.projectStatus, p.productProjectStage, p.parentProgramIDNumber };
                foreach (var p in proj)
                {
                    Minute minute = new Minute(p.projectId, p.name, p.projectStatus, p.productProjectStage);
                    lm.Add(minute);
                }
                return lm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}