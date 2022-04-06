namespace Yummy.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string Difficulty { get; set; }
        public int NumberOfLikes { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }
        public string TricksAndTips { get; set; }
    }
}