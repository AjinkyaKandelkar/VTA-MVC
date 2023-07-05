namespace VTA.Models
{
    public class UserVehicalDto
    {
        public string VehicleNumber { get; set; }
        public long VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public long Manufacturingyear { get; set; }
        public long Loadcarryingcapacity { get; set; }
        public string Makeofvehicle { get; set; }
        public string ModelNumber { get; set; }
        public int Bodytype { get; set; }
        public string Organisationname { get; set; }
        public int? UserID { get; set; }
        public int DeviceId { get; set; }
    }
}
