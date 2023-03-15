namespace Template.Api.ViewModels
{
    public class DeveloperVM
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
