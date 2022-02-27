namespace FutManager.Models
{
    public class Club
    {
        public string Name { get; set; }
        public string League { get; set; }
        public int Rating { get; set; }

        public Club(string name, string league, int rating)
        {
            Name = name;
            League = league;
            Rating = rating;
        }

        public Club()
        {
            Name = "Unknow";
            League = "Unknow";
            Rating = 0;
        }
    }
}