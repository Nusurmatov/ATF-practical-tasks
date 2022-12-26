namespace Framework.Models
{
    public class ComputeEngine
    {
        public string NumberOfInstances { get; set; } 

        public string OperatingSystemOrSoftwareText { get; set; }   

        public string ProvisionModelText { get; set; }

        public string MachineTypeText { get; set; }

        public string GpuTypeText { get; set; }

        public string NumberOfGpus { get; set; }
        
        public string LocalSddText { get; set; }

        public string DataCenterLocationText { get; set; }

        public string CommittedUsageText { get; set; }

        public string EmailTextField { get; set; }
    }
}
