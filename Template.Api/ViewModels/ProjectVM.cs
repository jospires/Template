namespace Template.Api.ViewModels
{
    public class ProjectVM
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
