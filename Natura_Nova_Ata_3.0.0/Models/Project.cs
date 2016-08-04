using Natura_Nova_Ata_3._0._0.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Project")]
    public class Project
    {
        public int projectId;
        public string name;
        public User leaderOrSubmitter;
        public string meaningLevel;
        public string projectStatus;
        public string scheduleStatus;
        public string businessUnit;
        public string category;
        public string subBrand;
        public string archetype;
        public string productProjectStage;
        public int totalSkus;
        public int newSkus;
        public string originalPBFGateAppDate;
        public string originalBFGateAppDate;
        public string originalPTGateAppDate;
        public string originalVLGateAppDate;
        public string originalDLGateAppDate;
        public string originalEXGateAppDate;
        public string originalEVGateAppDate;
        public string originalLaunchYear;
        public string displayPBFGateAppDate;
        public string displayBFGateAppDate;
        public string displayPTGateAppDate;
        public string displayVLGateAppDate;
        public string displayDLGateAppDate;
        public string displayEXGateAppDate;
        public string displayEVGateAppDate;
        public string displayLaunchCycle;
        public string displayLaunchYear;
        public string actualPBFGateAppDate;
        public string actualBFGateAppDate;
        public string actualPTGateAppDate;
        public string actualVLGateAppDate;
        public string actualDLGateAppDate;
        public string actualEXGateAppDate;
        public string actualEVGateAppDate;
        public string lastEstimatedPBFGateAppDate;
        public string lastEstimatedBFGateAppDate;
        public string lastEstimatedPTGateAppDate;
        public string lastEstimatedVLGateAppDate;
        public string lastEstimatedDLGateAppDate;
        public string lastEstimatedEXGateAppDate;
        public string lastEstimatedEVGateAppDate;
        public string creationDate;
        public string dateLastUpdated;
        [XmlArray]
        public List<User> team = new List<User>();
        public string operatingCostCenter;
        public string prototypePBFGateAppDate;
        public string prototypeBFGateAppDate;
        public string prototypePTGateAppDate;
        public string prototypeVLGateAppDate;
        public string prototypeDLGateAppDate;
        public string prototypeEXGateAppDate;
        public string prototypeEVGateAppDate;
        public string scoreSharedGoalsPBF;
        public string scoreSharedGoalsBF;
        public string scoreSharedGoalsPT;
        public string scoreSharedGoalsVL;
        public string scoreSharedGoalsDL;
        public string scoreSharedGoalsEX;
        public string scoreSharedGoalsEV;
        public string parentProgramIDNumber;
        public string parentProgramName;
        public string launchOrMaintenance;
        public string targetRegions;
        public string commemorationDate;
        public string first12MonthsGrossRevenue;
        public string first12MonthsIncrementalGrossRevenue;
        public string description;
        public string itemType;
        public string projectOrganization;
        public string timeToDelivery;
        public string timeToMarket;
        public int consumerSafetyComplexity;
        public int dlComplexity;
        public int fillingComplexity;
        public int formulationComplexity;
        public int packagingComplexity;
        public int marketingComplexity;
        public int processComplexity;
        public int qualityComplexity;

        public Project()
        {
        }

        public Project(int projectId, string name, int leaderOrSubmitter, string meaningLevel, string projectStatus, string scheduleStatus,
            string businessUnit, string category, string subBrand, string archetype, string productProjectStage, int totalSkus, int newSkus,
            string originalPBFGateAppDate, string originalBFGateAppDate, string originalPTGateAppDate, string originalVLGateAppDate,
            string originalDLGateAppDate, string originalEXGateAppDate, string originalEVGateAppDate, string originalLaunchYear,
            string displayPBFGateAppDate, string displayBFGateAppDate, string displayPTGateAppDate, string displayVLGateAppDate,
            string displayDLGateAppDate, string displayEXGateAppDate, string displayEVGateAppDate, string displayLaunchCycle,
            string displayLaunchYear, string actualPBFGateAppDate, string actualBFGateAppDate, string actualPTGateAppDate,
            string actualVLGateAppDate, string actualDLGateAppDate, string actualEXGateAppDate, string actualEVGateAppDate,
            string lastEstimatedPBFGateAppDate, string lastEstimatedBFGateAppDate, string lastEstimatedPTGateAppDate,
            string lastEstimatedVLGateAppDate, string lastEstimatedDLGateAppDate, string lastEstimatedEXGateAppDate,
            string lastEstimatedEVGateAppDate, string creationDate, string dateLastUpdated, string operatingCostCenter,
            string prototypePBFGateAppDate, string prototypeBFGateAppDate, string prototypePTGateAppDate,
            string prototypeVLGateAppDate, string prototypeDLGateAppDate, string prototypeEXGateAppDate, string prototypeEVGateAppDate,
            string scoreSharedGoalsPBF, string scoreSharedGoalsBF, string scoreSharedGoalsPT, string scoreSharedGoalsVL,
            string scoreSharedGoalsDL, string scoreSharedGoalsEX, string scoreSharedGoalsEV, string parentProgramIDNumber,
            string parentProgramName, string launchOrMaintenance, string targetRegions, string commemorationDate,
            string first12MonthsGrossRevenue, string first12MonthsIncrementalGrossRevenue, string description, string itemType,
            string projectOrganization, string timeToDelivery, string timeToMarket, int consumerSafetyComplexity, int dlComplexity,
            int fillingComplexity, int formulationComplexity, int packagingComplexity, int marketingComplexity, int processComplexity,
            int qualityComplexity)
        {
            setProjectId(projectId);
            setName(name);
            setLeaderOrSubmitter(leaderOrSubmitter);
            setMeaningLevel(meaningLevel);
            setProjectStatus(projectStatus);
            setScheduleStatus(scheduleStatus);
            setBusinessUnit(businessUnit);
            setCategory(category);
            setSubBrand(subBrand);
            setArchetype(archetype);
            setProductProjectStage(productProjectStage);
            setTotalSkus(totalSkus);
            setNewSkus(newSkus);
            setOriginalPBFGateAppDate(originalPBFGateAppDate);
            setOriginalBFGateAppDate(originalBFGateAppDate);
            setOriginalPTGateAppDate(originalPTGateAppDate);
            setOriginalVLGateAppDate(originalVLGateAppDate);
            setOriginalDLGateAppDate(originalDLGateAppDate);
            setOriginalEXGateAppDate(originalEXGateAppDate);
            setOriginalEVGateAppDate(originalEVGateAppDate);
            setOriginalLaunchYear(originalLaunchYear);
            setDisplayPBFGateAppDate(displayPBFGateAppDate);
            setDisplayBFGateAppDate(displayBFGateAppDate);
            setDisplayPTGateAppDate(displayPTGateAppDate);
            setDisplayVLGateAppDate(displayVLGateAppDate);
            setDisplayDLGateAppDate(displayDLGateAppDate);
            setDisplayEXGateAppDate(displayEXGateAppDate);
            setDisplayEVGateAppDate(displayEVGateAppDate);
            setDisplayLaunchCycle(displayLaunchCycle);
            setDisplayLaunchYear(displayLaunchYear);
            setActualPBFGateAppDate(actualPBFGateAppDate);
            setActualBFGateAppDate(actualBFGateAppDate);
            setActualPTGateAppDate(actualPTGateAppDate);
            setActualVLGateAppDate(actualVLGateAppDate);
            setActualDLGateAppDate(actualDLGateAppDate);
            setActualEXGateAppDate(actualEXGateAppDate);
            setActualEVGateAppDate(actualEVGateAppDate);
            setLastEstimatedPBFGateAppDate(lastEstimatedPBFGateAppDate);
            setLastEstimatedBFGateAppDate(lastEstimatedBFGateAppDate);
            setLastEstimatedPTGateAppDate(lastEstimatedPTGateAppDate);
            setLastEstimatedVLGateAppDate(lastEstimatedVLGateAppDate);
            setLastEstimatedDLGateAppDate(lastEstimatedDLGateAppDate);
            setLastEstimatedEXGateAppDate(lastEstimatedEXGateAppDate);
            setLastEstimatedEVGateAppDate(lastEstimatedEVGateAppDate);
            setCreationDate(creationDate);
            setDateLastUpdated(dateLastUpdated);
            setPrototypePBFGateAppDate(prototypePBFGateAppDate);
            setPrototypeBFGateAppDate(prototypeBFGateAppDate);
            setPrototypePTGateAppDate(prototypePTGateAppDate);
            setPrototypeVLGateAppDate(prototypeVLGateAppDate);
            setPrototypeDLGateAppDate(prototypeDLGateAppDate);
            setPrototypeEXGateAppDate(prototypeEXGateAppDate);
            setPrototypeEVGateAppDate(prototypeEVGateAppDate);
            setOperatingCostCenter(operatingCostCenter);
            setParentProgramName(parentProgramName);
            setParentProgramIDNumber(parentProgramIDNumber);
            setScoreSharedGoalsPBF(scoreSharedGoalsPBF);
            setScoreSharedGoalsBF(scoreSharedGoalsBF);
            setScoreSharedGoalsPT(scoreSharedGoalsPT);
            setScoreSharedGoalsVL(scoreSharedGoalsVL);
            setScoreSharedGoalsDL(scoreSharedGoalsDL);
            setScoreSharedGoalsEX(scoreSharedGoalsEX);
            setScoreSharedGoalsEV(scoreSharedGoalsEV);
            setFirst12MonthsGrossRevenue(first12MonthsGrossRevenue);
            setTargetRegions(targetRegions);
            setFirst12MonthsIncrementalGrossRevenue(first12MonthsIncrementalGrossRevenue);
            setDescription(description);
            setItemType(itemType);
            setProjectOrganization(projectOrganization);
            setCommemorationDate(commemorationDate);
            setLaunchOrMaintenance(launchOrMaintenance);
            setTimeToDelivery(timeToDelivery);
            setTimeToMarket(timeToMarket);
            setConsumerSafetyComplexity(consumerSafetyComplexity);
            setDlComplexity(dlComplexity);
            setFillingComplexity(fillingComplexity);
            setFormulationComplexity(formulationComplexity);
            setPackagingComplexity(packagingComplexity);
            setMarketingComplexity(marketingComplexity);
            setProcessComplexity(processComplexity);
            setQualityComplexity(qualityComplexity);
        }

        public Project(int projectId, string name, int leaderOrSubmitter, string meaningLevel, string projectStatus, string scheduleStatus,
            string businessUnit, string category, string subBrand, string archetype, string productProjectStage, int totalSkus, int newSkus,
            string originalPBFGateAppDate, string originalBFGateAppDate, string originalPTGateAppDate, string originalVLGateAppDate,
            string originalDLGateAppDate, string originalEXGateAppDate, string originalEVGateAppDate, string originalLaunchYear,
            string displayPBFGateAppDate, string displayBFGateAppDate, string displayPTGateAppDate, string displayVLGateAppDate,
            string displayDLGateAppDate, string displayEXGateAppDate, string displayEVGateAppDate, string displayLaunchCycle,
            string displayLaunchYear, string actualPBFGateAppDate, string actualBFGateAppDate, string actualPTGateAppDate,
            string actualVLGateAppDate, string actualDLGateAppDate, string actualEXGateAppDate, string actualEVGateAppDate,
            string lastEstimatedPBFGateAppDate, string lastEstimatedBFGateAppDate, string lastEstimatedPTGateAppDate,
            string lastEstimatedVLGateAppDate, string lastEstimatedDLGateAppDate, string lastEstimatedEXGateAppDate,
            string lastEstimatedEVGateAppDate, string creationDate, string dateLastUpdated, string operatingCostCenter,
            string prototypePBFGateAppDate, string prototypeBFGateAppDate, string prototypePTGateAppDate,
            string prototypeVLGateAppDate, string prototypeDLGateAppDate, string prototypeEXGateAppDate, string prototypeEVGateAppDate,
            string scoreSharedGoalsPBF, string scoreSharedGoalsBF, string scoreSharedGoalsPT, string scoreSharedGoalsVL,
            string scoreSharedGoalsDL, string scoreSharedGoalsEX, string scoreSharedGoalsEV, string parentProgramIDNumber,
            string parentProgramName, string launchOrMaintenance, string targetRegions, string commemorationDate, List<string> team,
            string first12MonthsGrossRevenue, string first12MonthsIncrementalGrossRevenue, string description, string itemType,
            string projectOrganization, string timeToDelivery, string timeToMarket, int consumerSafetyComplexity, int dlComplexity,
            int fillingComplexity, int formulationComplexity, int packagingComplexity, int marketingComplexity, int processComplexity,
            int qualityComplexity)
        {
            setProjectId(projectId);
            setName(name);
            setLeaderOrSubmitter(leaderOrSubmitter);
            setMeaningLevel(meaningLevel);
            setProjectStatus(projectStatus);
            setScheduleStatus(scheduleStatus);
            setBusinessUnit(businessUnit);
            setCategory(category);
            setSubBrand(subBrand);
            setArchetype(archetype);
            setProductProjectStage(productProjectStage);
            setTotalSkus(totalSkus);
            setNewSkus(newSkus);
            setOriginalPBFGateAppDate(originalPBFGateAppDate);
            setOriginalBFGateAppDate(originalBFGateAppDate);
            setOriginalPTGateAppDate(originalPTGateAppDate);
            setOriginalVLGateAppDate(originalVLGateAppDate);
            setOriginalDLGateAppDate(originalDLGateAppDate);
            setOriginalEXGateAppDate(originalEXGateAppDate);
            setOriginalEVGateAppDate(originalEVGateAppDate);
            setOriginalLaunchYear(originalLaunchYear);
            setDisplayPBFGateAppDate(displayPBFGateAppDate);
            setDisplayBFGateAppDate(displayBFGateAppDate);
            setDisplayPTGateAppDate(displayPTGateAppDate);
            setDisplayVLGateAppDate(displayVLGateAppDate);
            setDisplayDLGateAppDate(displayDLGateAppDate);
            setDisplayEXGateAppDate(displayEXGateAppDate);
            setDisplayEVGateAppDate(displayEVGateAppDate);
            setDisplayLaunchCycle(displayLaunchCycle);
            setDisplayLaunchYear(displayLaunchYear);
            setActualPBFGateAppDate(actualPBFGateAppDate);
            setActualBFGateAppDate(actualBFGateAppDate);
            setActualPTGateAppDate(actualPTGateAppDate);
            setActualVLGateAppDate(actualVLGateAppDate);
            setActualDLGateAppDate(actualDLGateAppDate);
            setActualEXGateAppDate(actualEXGateAppDate);
            setActualEVGateAppDate(actualEVGateAppDate);
            setLastEstimatedPBFGateAppDate(lastEstimatedPBFGateAppDate);
            setLastEstimatedBFGateAppDate(lastEstimatedBFGateAppDate);
            setLastEstimatedPTGateAppDate(lastEstimatedPTGateAppDate);
            setLastEstimatedVLGateAppDate(lastEstimatedVLGateAppDate);
            setLastEstimatedDLGateAppDate(lastEstimatedDLGateAppDate);
            setLastEstimatedEXGateAppDate(lastEstimatedEXGateAppDate);
            setLastEstimatedEVGateAppDate(lastEstimatedEVGateAppDate);
            setCreationDate(creationDate);
            setDateLastUpdated(dateLastUpdated);
            setPrototypePBFGateAppDate(prototypePBFGateAppDate);
            setPrototypeBFGateAppDate(prototypeBFGateAppDate);
            setPrototypePTGateAppDate(prototypePTGateAppDate);
            setPrototypeVLGateAppDate(prototypeVLGateAppDate);
            setPrototypeDLGateAppDate(prototypeDLGateAppDate);
            setPrototypeEXGateAppDate(prototypeEXGateAppDate);
            setPrototypeEVGateAppDate(prototypeEVGateAppDate);
            setOperatingCostCenter(operatingCostCenter);
            setParentProgramName(parentProgramName);
            setParentProgramIDNumber(parentProgramIDNumber);
            setScoreSharedGoalsPBF(scoreSharedGoalsPBF);
            setScoreSharedGoalsBF(scoreSharedGoalsBF);
            setScoreSharedGoalsPT(scoreSharedGoalsPT);
            setScoreSharedGoalsVL(scoreSharedGoalsVL);
            setScoreSharedGoalsDL(scoreSharedGoalsDL);
            setScoreSharedGoalsEX(scoreSharedGoalsEX);
            setScoreSharedGoalsEV(scoreSharedGoalsEV);
            setFirst12MonthsGrossRevenue(first12MonthsGrossRevenue);
            setTargetRegions(targetRegions);
            setFirst12MonthsIncrementalGrossRevenue(first12MonthsIncrementalGrossRevenue);
            setDescription(description);
            setItemType(itemType);
            setProjectOrganization(projectOrganization);
            setCommemorationDate(commemorationDate);
            setTeam(team);
            setLaunchOrMaintenance(launchOrMaintenance);
            setTimeToDelivery(timeToDelivery);
            setTimeToMarket(timeToMarket);
            setConsumerSafetyComplexity(consumerSafetyComplexity);
            setDlComplexity(dlComplexity);
            setFillingComplexity(fillingComplexity);
            setFormulationComplexity(formulationComplexity);
            setPackagingComplexity(packagingComplexity);
            setMarketingComplexity(marketingComplexity);
            setProcessComplexity(processComplexity);
            setQualityComplexity(qualityComplexity);
        }

        public void setProjectId(int projetId)
        {
            this.projectId = projetId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setLeaderOrSubmitter(int leaderOrSubmitter)
        {
            this.leaderOrSubmitter = UserDAO.instanceById(leaderOrSubmitter);
        }

        public void setMeaningLevel(string meaningLevel)
        {
            this.meaningLevel = meaningLevel;
        }

        public void setProjectStatus(string projectStatus)
        {
            this.projectStatus = projectStatus;
        }

        public void setScheduleStatus(string scheduleStatus)
        {
            this.scheduleStatus = scheduleStatus;
        }

        public void setBusinessUnit(string businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        public void setCategory(string category)
        {
            this.category = category;
        }

        public void setSubBrand(string subBrand)
        {
            this.subBrand = subBrand;
        }

        public void setArchetype(string archetype)
        {
            this.archetype = archetype;
        }

        public void setProductProjectStage(string productProjectStage)
        {
            this.productProjectStage = productProjectStage;
        }

        public void setProductProjectStage(string projectStage, string meaningLevel)
        {
            if (projectStage.Equals("0") && meaningLevel.Equals("PROGRAM"))
            {
                this.productProjectStage = "PROGRAM";
            }
            else
            {
                this.productProjectStage = projectStage;
            }
        }

        public void setTotalSkus(int totalSkus)
        {
            try
            {
                this.totalSkus = totalSkus;
            }
            catch
            {
                this.totalSkus = 0;
            }
        }

        public void setNewSkus(int newSkus)
        {
            try
            {
                this.newSkus = newSkus;
            }
            catch
            {
                this.newSkus = 0;
            }
        }

        public void setOriginalPBFGateAppDate(string originalPBFGateAppDate)
        {
            this.originalPBFGateAppDate = originalPBFGateAppDate;
        }

        public void setOriginalBFGateAppDate(string originalBFGateAppDate)
        {
            this.originalBFGateAppDate = originalBFGateAppDate;
        }

        public void setOriginalPTGateAppDate(string originalPTGateAppDate)
        {
            this.originalPTGateAppDate = originalPTGateAppDate;
        }

        public void setOriginalVLGateAppDate(string originalVLGateAppDate)
        {
            this.originalVLGateAppDate = originalVLGateAppDate;
        }

        public void setOriginalDLGateAppDate(string originalDLGateAppDate)
        {
            this.originalDLGateAppDate = originalDLGateAppDate;
        }

        public void setOriginalEXGateAppDate(string originalEXGateAppDate)
        {
            this.originalEXGateAppDate = originalEXGateAppDate;
        }

        public void setOriginalEVGateAppDate(string originalEVGateAppDate)
        {
            this.originalEVGateAppDate = originalEVGateAppDate;
        }

        public void setOriginalLaunchYear(string originalLaunchYear)
        {
            this.originalLaunchYear = originalLaunchYear;
        }

        public void setDisplayPBFGateAppDate(string displayPBFGateAppDate)
        {
            this.displayPBFGateAppDate = displayPBFGateAppDate;
        }

        public void setDisplayBFGateAppDate(string displayBFGateAppDate)
        {
            this.displayBFGateAppDate = displayBFGateAppDate;
        }

        public void setDisplayPTGateAppDate(string displayPTGateAppDate)
        {
            this.displayPTGateAppDate = displayPTGateAppDate;
        }

        public void setDisplayVLGateAppDate(string displayVLGateAppDate)
        {
            this.displayVLGateAppDate = displayVLGateAppDate;
        }

        public void setDisplayDLGateAppDate(string displayDLGateAppDate)
        {
            this.displayDLGateAppDate = displayDLGateAppDate;
        }

        public void setDisplayEXGateAppDate(string displayEXGateAppDate)
        {
            this.displayEXGateAppDate = displayEXGateAppDate;
        }

        public void setDisplayEVGateAppDate(string displayEVGateAppDate)
        {
            this.displayEVGateAppDate = displayEVGateAppDate;
        }

        public void setDisplayLaunchCycle(string displayLaunchCycle)
        {
            this.displayLaunchCycle = displayLaunchCycle;
        }

        public void setDisplayLaunchYear(string displayLaunchYear)
        {
            this.displayLaunchYear = displayLaunchYear;
        }

        public void setActualPBFGateAppDate(string actualPBFGateAppDate)
        {
            this.actualPBFGateAppDate = actualPBFGateAppDate;
        }

        public void setActualBFGateAppDate(string actualBFGateAppDate)
        {
            this.actualBFGateAppDate = actualBFGateAppDate;
        }

        public void setActualPTGateAppDate(string actualPTGateAppDate)
        {
            this.actualPTGateAppDate = actualPTGateAppDate;
        }

        public void setActualVLGateAppDate(string actualVLGateAppDate)
        {
            this.actualVLGateAppDate = actualVLGateAppDate;
        }

        public void setActualDLGateAppDate(string actualDLGateAppDate)
        {
            this.actualDLGateAppDate = actualDLGateAppDate;
        }

        public void setActualEXGateAppDate(string actualEXGateAppDate)
        {
            this.actualEXGateAppDate = actualEXGateAppDate;
        }

        public void setActualEVGateAppDate(string actualEVGateAppDate)
        {
            this.actualEVGateAppDate = actualEVGateAppDate;
        }

        public void setLastEstimatedPBFGateAppDate(string lastEstimatedPBFGateAppDate)
        {
            this.lastEstimatedPBFGateAppDate = lastEstimatedPBFGateAppDate;
        }

        public void setLastEstimatedBFGateAppDate(string lastEstimatedBFGateAppDate)
        {
            this.lastEstimatedBFGateAppDate = lastEstimatedBFGateAppDate;
        }

        public void setLastEstimatedPTGateAppDate(string lastEstimatedPTGateAppDate)
        {
            this.lastEstimatedPTGateAppDate = lastEstimatedPTGateAppDate;
        }

        public void setLastEstimatedVLGateAppDate(string lastEstimatedVLGateAppDate)
        {
            this.lastEstimatedVLGateAppDate = lastEstimatedVLGateAppDate;
        }

        public void setLastEstimatedDLGateAppDate(string lastEstimatedDLGateAppDate)
        {
            this.lastEstimatedDLGateAppDate = lastEstimatedDLGateAppDate;
        }

        public void setLastEstimatedEXGateAppDate(string lastEstimatedEXGateAppDate)
        {
            this.lastEstimatedEXGateAppDate = lastEstimatedEXGateAppDate;
        }

        public void setLastEstimatedEVGateAppDate(string lastEstimatedEVGateAppDate)
        {
            this.lastEstimatedEVGateAppDate = lastEstimatedEVGateAppDate;
        }

        public void setCreationDate(string creationDate)
        {
            this.creationDate = creationDate;
        }

        public void setDateLastUpdated(string dateLastUpdated)
        {
            this.dateLastUpdated = dateLastUpdated;
        }

        public void setPrototypePBFGateAppDate(string prototypePBFGateAppDate)
        {
            this.prototypePBFGateAppDate = prototypePBFGateAppDate;
        }

        public void setPrototypeBFGateAppDate(string prototypeBFGateAppDate)
        {
            this.prototypeBFGateAppDate = prototypeBFGateAppDate;
        }

        public void setPrototypePTGateAppDate(string prototypePTGateAppDate)
        {
            this.prototypePTGateAppDate = prototypePTGateAppDate;
        }

        public void setPrototypeVLGateAppDate(string prototypeVLGateAppDate)
        {
            this.prototypeVLGateAppDate = prototypeVLGateAppDate;
        }

        public void setPrototypeDLGateAppDate(string prototypeDLGateAppDate)
        {
            this.prototypeDLGateAppDate = prototypeDLGateAppDate;
        }

        public void setPrototypeEXGateAppDate(string prototypeEXGateAppDate)
        {
            this.prototypeEXGateAppDate = prototypeEXGateAppDate;
        }

        public void setPrototypeEVGateAppDate(string prototypeEVGateAppDate)
        {
            this.prototypeEVGateAppDate = prototypeEVGateAppDate;
        }

        public void setOperatingCostCenter(string operatingCostCenter)
        {
            this.operatingCostCenter = operatingCostCenter;
        }

        public void setParentProgramName(string parentProgramName)
        {
            this.parentProgramName = parentProgramName;
        }

        public void setParentProgramIDNumber(string parentProgramIDNumber)
        {
            this.parentProgramIDNumber = parentProgramIDNumber;
        }

        public void setScoreSharedGoalsPBF(string scoreSharedGoalsPBF)
        {
            this.scoreSharedGoalsPBF = scoreSharedGoalsPBF;
        }

        public void setScoreSharedGoalsBF(string scoreSharedGoalsBF)
        {
            this.scoreSharedGoalsBF = scoreSharedGoalsBF;
        }

        public void setScoreSharedGoalsPT(string scoreSharedGoalsPT)
        {
            this.scoreSharedGoalsPT = scoreSharedGoalsPT;
        }

        public void setScoreSharedGoalsVL(string scoreSharedGoalsVL)
        {
            this.scoreSharedGoalsVL = scoreSharedGoalsVL;
        }

        public void setScoreSharedGoalsDL(string scoreSharedGoalsDL)
        {
            this.scoreSharedGoalsDL = scoreSharedGoalsDL;
        }

        public void setScoreSharedGoalsEX(string scoreSharedGoalsEX)
        {
            this.scoreSharedGoalsEX = scoreSharedGoalsEX;
        }

        public void setScoreSharedGoalsEV(string scoreSharedGoalsEV)
        {
            this.scoreSharedGoalsEV = scoreSharedGoalsEV;
        }

        public void setFirst12MonthsGrossRevenue(string first12MonthsGrossRevenue)
        {
            this.first12MonthsGrossRevenue = first12MonthsGrossRevenue;
        }

        public void setTargetRegions(string targetRegions)
        {
            this.targetRegions = targetRegions;
        }

        public void setFirst12MonthsIncrementalGrossRevenue(string first12MonthsIncrementalGrossRevenue)
        {
            this.first12MonthsIncrementalGrossRevenue = first12MonthsIncrementalGrossRevenue;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setItemType(string itemType)
        {
            this.itemType = itemType;
        }

        public void setProjectOrganization(string projectOrganization)
        {
            this.projectOrganization = projectOrganization;
        }

        public void setCommemorationDate(string commemorationDate)
        {
            this.commemorationDate = commemorationDate;
        }

        public void setTeam(List<User> team)
        {
            this.team = team;
        }

        public void setTeam(List<string> team)
        {
            try
            {
                foreach (string u in team)
                {
                    User user = UserDAO.instanceByName(u);
                    if (user == null)
                    {
                        continue;
                    }
                    else
                    {
                        this.team.Add(user);
                    }
                }
            }
            catch
            {
                this.team = null;
            }
        }

        public void addTeamMember(User usr)
        {
            this.team.Add(usr);
        }

        public void setLaunchOrMaintenance(string launchOrMaintenance)
        {
            this.launchOrMaintenance = launchOrMaintenance;
        }

        public void setTimeToDelivery(string timeToDelivery)
        {
            this.timeToDelivery = timeToDelivery;
        }

        public void setTimeToMarket(string timeToMarket)
        {
            this.timeToMarket = timeToMarket;
        }

        public void setConsumerSafetyComplexity(int consumerSafetyComplexity)
        {
            this.consumerSafetyComplexity = consumerSafetyComplexity;
        }

        public void setDlComplexity(int dlComplexity)
        {
            this.dlComplexity = dlComplexity;
        }

        public void setFillingComplexity(int fillingComplexity)
        {
            this.fillingComplexity = fillingComplexity;
        }

        public void setFormulationComplexity(int formulationComplexity)
        {
            this.formulationComplexity = formulationComplexity;
        }

        public void setPackagingComplexity(int packagingComplexity)
        {
            this.packagingComplexity = packagingComplexity;
        }

        public void setMarketingComplexity(int marketingComplexity)
        {
            this.marketingComplexity = marketingComplexity;
        }

        public void setProcessComplexity(int processComplexity)
        {
            this.processComplexity = processComplexity;
        }

        public void setQualityComplexity(int qualityComplexity)
        {
            this.qualityComplexity = qualityComplexity;
        }

        public int getProjectId()
        {
            return this.projectId;
        }

        public string getName()
        {
            return this.name;
        }

        public User getLeaderOrSubmitter()
        {
            return this.leaderOrSubmitter;
        }

        public string getMeaningLevel()
        {
            return this.meaningLevel;
        }

        public string getProjectStatus()
        {
            return this.projectStatus;
        }

        public string getScheduleStatus()
        {
            return this.scheduleStatus;
        }

        public string getBusinessUnit()
        {
            return this.businessUnit;
        }

        public string getCategory()
        {
            return this.category;
        }

        public string getSubBrand()
        {
            return this.subBrand;
        }

        public string getArchetype()
        {
            return this.archetype;
        }

        public string getProductProjectStage()
        {
            return this.productProjectStage;
        }

        public int getTotalSkus()
        {
            return this.totalSkus;
        }

        public int getNewSkus()
        {
            return this.newSkus;
        }

        public string getOriginalPBFGateAppDate()
        {
            return this.originalPBFGateAppDate;
        }

        public string getOriginalBFGateAppDate()
        {
            return this.originalBFGateAppDate;
        }

        public string getOriginalPTGateAppDate()
        {
            return this.originalPTGateAppDate;
        }

        public string getOriginalVLGateAppDate()
        {
            return this.originalVLGateAppDate;
        }

        public string getOriginalDLGateAppDate()
        {
            return this.originalDLGateAppDate;
        }

        public string getOriginalEXGateAppDate()
        {
            return this.originalEXGateAppDate;
        }

        public string getOriginalEVGateAppDate()
        {
            return this.originalEVGateAppDate;
        }

        public string getOriginalLaunchYear()
        {
            return this.originalLaunchYear;
        }

        public string getDisplayPBFGateAppDate()
        {
            return this.displayPBFGateAppDate;
        }

        public string getDisplayBFGateAppDate()
        {
            return this.displayBFGateAppDate;
        }

        public string getDisplayPTGateAppDate()
        {
            return this.displayPTGateAppDate;
        }

        public string getDisplayVLGateAppDate()
        {
            return this.displayVLGateAppDate;
        }

        public string getDisplayDLGateAppDate()
        {
            return this.displayDLGateAppDate;
        }

        public string getDisplayEXGateAppDate()
        {
            return this.displayEXGateAppDate;
        }

        public string getDisplayEVGateAppDate()
        {
            return this.displayEVGateAppDate;
        }

        public string getDisplayLaunchCycle()
        {
            return this.displayLaunchCycle;
        }

        public string getDisplayLaunchYear()
        {
            return this.displayLaunchYear;
        }

        public string getActualPBFGateAppDate()
        {
            return this.actualPBFGateAppDate;
        }

        public string getActualBFGateAppDate()
        {
            return this.actualBFGateAppDate;
        }

        public string getActualPTGateAppDate()
        {
            return this.actualPTGateAppDate;
        }

        public string getActualVLGateAppDate()
        {
            return this.actualVLGateAppDate;
        }

        public string getActualDLGateAppDate()
        {
            return this.actualDLGateAppDate;
        }

        public string getActualEXGateAppDate()
        {
            return this.actualEXGateAppDate;
        }

        public string getActualEVGateAppDate()
        {
            return this.actualEVGateAppDate;
        }

        public string getLastEstimatedPBFGateAppDate()
        {
            return this.lastEstimatedPBFGateAppDate;
        }

        public string getLastEstimatedBFGateAppDate()
        {
            return this.lastEstimatedBFGateAppDate;
        }

        public string getLastEstimatedPTGateAppDate()
        {
            return this.lastEstimatedPTGateAppDate;
        }

        public string getLastEstimatedVLGateAppDate()
        {
            return this.lastEstimatedVLGateAppDate;
        }

        public string getLastEstimatedDLGateAppDate()
        {
            return this.lastEstimatedDLGateAppDate;
        }

        public string getLastEstimatedEXGateAppDate()
        {
            return this.lastEstimatedEXGateAppDate;
        }

        public string getLastEstimatedEVGateAppDate()
        {
            return this.lastEstimatedEVGateAppDate;
        }

        public string getCreationDate()
        {
            return this.creationDate;
        }

        public string getDateLastUpdated()
        {
            return this.dateLastUpdated;
        }

        public string getPrototypePBFGateAppDate()
        {
            return this.prototypePBFGateAppDate;
        }

        public string getPrototypeBFGateAppDate()
        {
            return this.prototypeBFGateAppDate;
        }

        public string getPrototypePTGateAppDate()
        {
            return this.prototypePTGateAppDate;
        }

        public string getPrototypeVLGateAppDate()
        {
            return this.prototypeVLGateAppDate;
        }

        public string getPrototypeDLGateAppDate()
        {
            return this.prototypeDLGateAppDate;
        }

        public string getPrototypeEXGateAppDate()
        {
            return this.prototypeEXGateAppDate;
        }

        public string getPrototypeEVGateAppDate()
        {
            return this.prototypeEVGateAppDate;
        }

        public string getOperatingCostCenter()
        {
            return this.operatingCostCenter;
        }

        public string getParentProgramName()
        {
            return this.parentProgramName;
        }

        public string getParentProgramIDNumber()
        {
            return this.parentProgramIDNumber;
        }

        public string getScoreSharedGoalsPBF()
        {
            return this.scoreSharedGoalsPBF;
        }

        public string getScoreSharedGoalsBF()
        {
            return this.scoreSharedGoalsBF;
        }

        public string getScoreSharedGoalsPT()
        {
            return this.scoreSharedGoalsPT;
        }

        public string getScoreSharedGoalsVL()
        {
            return this.scoreSharedGoalsVL;
        }

        public string getScoreSharedGoalsDL()
        {
            return this.scoreSharedGoalsDL;
        }

        public string getScoreSharedGoalsEX()
        {
            return this.scoreSharedGoalsEX;
        }

        public string getScoreSharedGoalsEV()
        {
            return this.scoreSharedGoalsEV;
        }

        public string getFirst12MonthsGrossRevenue()
        {
            return this.first12MonthsGrossRevenue;
        }

        public string getTargetRegions()
        {
            return this.targetRegions;
        }

        public string getFirst12MonthsIncrementalGrossRevenue()
        {
            return this.first12MonthsIncrementalGrossRevenue;
        }

        public string getDescription()
        {
            return this.description;
        }

        public string getItemType()
        {
            return this.itemType;
        }

        public string getProjectOrganization()
        {
            return this.projectOrganization;
        }

        public string getCommemorationDate()
        {
            return this.commemorationDate;
        }

        public List<User> getTeam()
        {
            return this.team;
        }

        public string getLaunchOrMaintenance()
        {
            return this.launchOrMaintenance;
        }

        public string getTimeToDelivery()
        {
            return this.timeToDelivery;
        }

        public string getTimeToMarket()
        {
            return this.timeToMarket;
        }

        public int getConsumerSafetyComplexity()
        {
            return this.consumerSafetyComplexity;
        }

        public int getDlComplexity()
        {
            return this.dlComplexity;
        }

        public int getFillingComplexity()
        {
            return this.fillingComplexity;
        }

        public int getFormulationComplexity()
        {
            return this.formulationComplexity;
        }

        public int getPackagingComplexity()
        {
            return this.packagingComplexity;
        }

        public int getMarketingComplexity()
        {
            return this.marketingComplexity;
        }

        public int getProcessComplexity()
        {
            return this.processComplexity;
        }

        public int getQualityComplexity()
        {
            return this.qualityComplexity;
        }

        public string toString()
        {
            return string.Format("ID: {0}, Name: {1}", this.projectId, this.name);
        }
    }
}