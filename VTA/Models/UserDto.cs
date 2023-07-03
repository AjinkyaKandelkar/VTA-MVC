namespace VTA.Models
{
    public class UserDto
    {
       public int? Id { get; set; }
        public string Name { get; set; }
        public long MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string password { get; set; }
        public string Localtion { get; set; }
        public string? photopath { get; set; }
    }
}
