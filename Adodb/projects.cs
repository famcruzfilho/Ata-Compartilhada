//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Adodb
{
    using System;
    using System.Collections.Generic;
    
    public partial class projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public projects()
        {
            this.tasks = new HashSet<tasks>();
            this.team_allocation = new HashSet<team_allocation>();
        }
    
        public int projectId { get; set; }
        public string name { get; set; }
        public int leaderOrSubmitter { get; set; }
        public string meaningLevel { get; set; }
        public string projectStatus { get; set; }
        public string scheduleStatus { get; set; }
        public string businessUnit { get; set; }
        public string category { get; set; }
        public string subBrand { get; set; }
        public string archetype { get; set; }
        public string productProjectStage { get; set; }
        public Nullable<int> totalSkus { get; set; }
        public Nullable<int> newSkus { get; set; }
        public string originalPBFGateAppDate { get; set; }
        public string originalBFGateAppDate { get; set; }
        public string originalPTGateAppDate { get; set; }
        public string originalVLGateAppDate { get; set; }
        public string originalDLGateAppDate { get; set; }
        public string originalEXGateAppDate { get; set; }
        public string originalEVGateAppDate { get; set; }
        public string originalLaunchYear { get; set; }
        public string displayPBFGateAppDate { get; set; }
        public string displayBFGateAppDate { get; set; }
        public string displayPTGateAppDate { get; set; }
        public string displayVLGateAppDate { get; set; }
        public string displayDLGateAppDate { get; set; }
        public string displayEXGateAppDate { get; set; }
        public string displayEVGateAppDate { get; set; }
        public string displayLaunchCycle { get; set; }
        public string displayLaunchYear { get; set; }
        public string actualPBFGateAppDate { get; set; }
        public string actualBFGateAppDate { get; set; }
        public string actualPTGateAppDate { get; set; }
        public string actualVLGateAppDate { get; set; }
        public string actualDLGateAppDate { get; set; }
        public string actualEXGateAppDate { get; set; }
        public string actualEVGateAppDate { get; set; }
        public string lastEstimatedPBFGateAppDate { get; set; }
        public string lastEstimatedBFGateAppDate { get; set; }
        public string lastEstimatedPTGateAppDate { get; set; }
        public string lastEstimatedVLGateAppDate { get; set; }
        public string lastEstimatedDLGateAppDate { get; set; }
        public string lastEstimatedEXGateAppDate { get; set; }
        public string lastEstimatedEVGateAppDate { get; set; }
        public string creationDate { get; set; }
        public string dateLastUpdated { get; set; }
        public string operatingCostCenter { get; set; }
        public string prototypePBFGateAppDate { get; set; }
        public string prototypeBFGateAppDate { get; set; }
        public string prototypePTGateAppDate { get; set; }
        public string prototypeVLGateAppDate { get; set; }
        public string prototypeDLGateAppDate { get; set; }
        public string prototypeEXGateAppDate { get; set; }
        public string prototypeEVGateAppDate { get; set; }
        public string scoreSharedGoalsPBF { get; set; }
        public string scoreSharedGoalsBF { get; set; }
        public string scoreSharedGoalsPT { get; set; }
        public string scoreSharedGoalsVL { get; set; }
        public string scoreSharedGoalsDL { get; set; }
        public string scoreSharedGoalsEX { get; set; }
        public string scoreSharedGoalsEV { get; set; }
        public string parentProgramName { get; set; }
        public string parentProgramIDNumber { get; set; }
        public string launchOrMaintenance { get; set; }
        public string targetRegions { get; set; }
        public string commemorationDate { get; set; }
        public string first12MonthsGrossRevenue { get; set; }
        public string first12MonthsIncrementalGrossRevenue { get; set; }
        public string description { get; set; }
        public string itemType { get; set; }
        public string projectOrganization { get; set; }
        public string timeToDelivery { get; set; }
        public string timeToMarket { get; set; }
        public Nullable<int> consumerSafetyComplexity { get; set; }
        public Nullable<int> dlComplexity { get; set; }
        public Nullable<int> fillingComplexity { get; set; }
        public Nullable<int> formulationComplexity { get; set; }
        public Nullable<int> packagingComplexity { get; set; }
        public Nullable<int> marketingComplexity { get; set; }
        public Nullable<int> processComplexity { get; set; }
        public Nullable<int> qualityComplexity { get; set; }
    
        public virtual users users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tasks> tasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<team_allocation> team_allocation { get; set; }
        public virtual notifications notifications { get; set; }
    }
}
