namespace CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.ViewModels
{
    public class EditCarViewModel
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public double EnginePower { get; set; }
        public string EngineType { get; set; }
        public int NumberOfCylinders { get; set; }
        public string Color { get; set; }
        public DateTime DateOfCreating { get; set; }
        public bool Availability { get; set; }
        public IFormFile? PhotoToUpdate { get; set; }
        public byte[]? PhotoToDisplay { get; set; }
    }
}
