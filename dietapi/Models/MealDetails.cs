namespace dietapi.Models
{
    public class MealDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DesertDetails Desert { get; set; }
    }
}