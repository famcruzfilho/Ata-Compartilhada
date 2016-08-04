using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class ProjectDAO
    {
        public static List<Project> select()
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                List<Project> lp = new List<Project>();
                var projects = from pr in db.projects
                               select pr;
                foreach (var p in projects.ToList())
                {
                    Project project = new Project(p.projectId, p.name, p.leaderOrSubmitter, p.meaningLevel, p.projectStatus,
                        p.scheduleStatus, p.businessUnit, p.category, p.subBrand, p.archetype, p.productProjectStage, (int)p.totalSkus,
                        (int)p.newSkus, p.originalPBFGateAppDate, p.originalBFGateAppDate, p.originalPTGateAppDate,
                        p.originalVLGateAppDate, p.originalDLGateAppDate, p.originalEXGateAppDate, p.originalEVGateAppDate,
                        p.originalLaunchYear, p.displayPBFGateAppDate, p.displayBFGateAppDate, p.displayPTGateAppDate,
                        p.displayVLGateAppDate, p.displayDLGateAppDate, p.displayEXGateAppDate, p.displayEVGateAppDate,
                        p.displayLaunchCycle, p.displayLaunchYear, p.actualPBFGateAppDate, p.actualBFGateAppDate,
                        p.actualPTGateAppDate, p.actualVLGateAppDate, p.actualDLGateAppDate, p.actualEXGateAppDate,
                        p.actualEVGateAppDate, p.lastEstimatedPBFGateAppDate, p.lastEstimatedBFGateAppDate,
                        p.lastEstimatedPTGateAppDate, p.lastEstimatedVLGateAppDate, p.lastEstimatedDLGateAppDate,
                        p.lastEstimatedEXGateAppDate, p.lastEstimatedEVGateAppDate, p.creationDate, p.dateLastUpdated,
                        p.operatingCostCenter, p.prototypePBFGateAppDate, p.prototypeBFGateAppDate, p.prototypePTGateAppDate,
                        p.prototypeVLGateAppDate, p.prototypeDLGateAppDate, p.prototypeEXGateAppDate, p.prototypeEVGateAppDate,
                        p.scoreSharedGoalsPBF, p.scoreSharedGoalsBF, p.scoreSharedGoalsPT, p.scoreSharedGoalsVL,
                        p.scoreSharedGoalsDL, p.scoreSharedGoalsEX, p.scoreSharedGoalsEV, p.parentProgramIDNumber,
                        p.parentProgramName, p.launchOrMaintenance, p.targetRegions, p.commemorationDate,
                        p.first12MonthsGrossRevenue, p.first12MonthsIncrementalGrossRevenue, p.description, p.itemType,
                        p.projectOrganization, p.timeToDelivery, p.timeToMarket, (int)p.consumerSafetyComplexity,
                        (int)p.dlComplexity, (int)p.fillingComplexity, (int)p.formulationComplexity, (int)p.packagingComplexity,
                        (int)p.marketingComplexity, (int)p.processComplexity, (int)p.qualityComplexity);
                    int projectId = project.getProjectId();
                    var team = from ta in db.team_allocation
                               where ta.projectId == projectId
                               select new { ta.users };
                    foreach (var usr in team.ToList())
                    {
                        User user = new User(usr.users.userId, usr.users.alias, usr.users.name, usr.users.exchangeName, usr.users.email,
                            usr.users.area, usr.users.managerName, usr.users.managerLogin, usr.users.managerEmail, usr.users.type);
                        project.addTeamMember(user);
                    }
                    lp.Add(project);
                }
                return lp;
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public static Project select(int projectId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var p = (from pr in db.projects
                         where pr.projectId == projectId
                         select pr).First();
                int newSkus = int.TryParse(p.newSkus.ToString(), out newSkus) ? newSkus : 0;
                int totalSkus = int.TryParse(p.totalSkus.ToString(), out totalSkus) ? totalSkus : 0;
                int consumerSafetyComplexity = int.TryParse(p.consumerSafetyComplexity.ToString(), out consumerSafetyComplexity) ? consumerSafetyComplexity : 0;
                int dlComplexity = int.TryParse(p.dlComplexity.ToString(), out dlComplexity) ? dlComplexity : 0;
                int fillingComplexity = int.TryParse(p.fillingComplexity.ToString(), out fillingComplexity) ? fillingComplexity : 0;
                int formulationComplexity = int.TryParse(p.formulationComplexity.ToString(), out formulationComplexity) ? formulationComplexity : 0;
                int packagingComplexity = int.TryParse(p.packagingComplexity.ToString(), out packagingComplexity) ? packagingComplexity : 0;
                int marketingComplexity = int.TryParse(p.marketingComplexity.ToString(), out marketingComplexity) ? marketingComplexity : 0;
                int processComplexity = int.TryParse(p.processComplexity.ToString(), out processComplexity) ? processComplexity : 0;
                int qualityComplexity = int.TryParse(p.qualityComplexity.ToString(), out qualityComplexity) ? qualityComplexity : 0;
                Project project = new Project(p.projectId, p.name, p.leaderOrSubmitter, p.meaningLevel, p.projectStatus,
                    p.scheduleStatus, p.businessUnit, p.category, p.subBrand, p.archetype, p.productProjectStage, totalSkus,
                    newSkus, p.originalPBFGateAppDate, p.originalBFGateAppDate, p.originalPTGateAppDate,
                    p.originalVLGateAppDate, p.originalDLGateAppDate, p.originalEXGateAppDate, p.originalEVGateAppDate,
                    p.originalLaunchYear, p.displayPBFGateAppDate, p.displayBFGateAppDate, p.displayPTGateAppDate,
                    p.displayVLGateAppDate, p.displayDLGateAppDate, p.displayEXGateAppDate, p.displayEVGateAppDate,
                    p.displayLaunchCycle, p.displayLaunchYear, p.actualPBFGateAppDate, p.actualBFGateAppDate,
                    p.actualPTGateAppDate, p.actualVLGateAppDate, p.actualDLGateAppDate, p.actualEXGateAppDate,
                    p.actualEVGateAppDate, p.lastEstimatedPBFGateAppDate, p.lastEstimatedBFGateAppDate,
                    p.lastEstimatedPTGateAppDate, p.lastEstimatedVLGateAppDate, p.lastEstimatedDLGateAppDate,
                    p.lastEstimatedEXGateAppDate, p.lastEstimatedEVGateAppDate, p.creationDate, p.dateLastUpdated,
                    p.operatingCostCenter, p.prototypePBFGateAppDate, p.prototypeBFGateAppDate, p.prototypePTGateAppDate,
                    p.prototypeVLGateAppDate, p.prototypeDLGateAppDate, p.prototypeEXGateAppDate, p.prototypeEVGateAppDate,
                    p.scoreSharedGoalsPBF, p.scoreSharedGoalsBF, p.scoreSharedGoalsPT, p.scoreSharedGoalsVL,
                    p.scoreSharedGoalsDL, p.scoreSharedGoalsEX, p.scoreSharedGoalsEV, p.parentProgramIDNumber,
                    p.parentProgramName, p.launchOrMaintenance, p.targetRegions, p.commemorationDate,
                    p.first12MonthsGrossRevenue, p.first12MonthsIncrementalGrossRevenue, p.description, p.itemType,
                    p.projectOrganization, p.timeToDelivery, p.timeToMarket, consumerSafetyComplexity, dlComplexity,
                    fillingComplexity, formulationComplexity, packagingComplexity, marketingComplexity, processComplexity,
                    qualityComplexity);
                var team = from ta in db.team_allocation
                           where ta.projectId == projectId
                           select new { ta.users };
                foreach (var usr in team.ToList())
                {
                    User user = new User(usr.users.userId, usr.users.alias, usr.users.name, usr.users.exchangeName, usr.users.email,
                        usr.users.area, usr.users.managerName, usr.users.managerLogin, usr.users.managerEmail, usr.users.type);
                    project.addTeamMember(user);
                }
                return project;
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public static int stageCorrespondence(string stage)
        {
            if (stage.Equals("PRE BRIEFING"))
            {
                return 1;
            }
            else if (stage.Equals("BRIEFING"))
            {
                return 2;
            }
            else if (stage.Equals("PROTOTYPE"))
            {
                return 3;
            }
            else if (stage.Equals("VALIDATION"))
            {
                return 4;
            }
            else if (stage.Equals("DELIVERY"))
            {
                return 5;
            }
            else if (stage.Equals("LAUNCH EXECUTION"))
            {
                return 6;
            }
            else if (stage.Equals("EVALUATION"))
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }
    }
}