namespace FutManager.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public int Rating { get; set; }

        public Club(int id,string name, string league, int rating)
        {
            Id = id;
            Name = name;
            League = league;
            Rating = rating;
        }

        public Club()
        {
            Id = -1;
            Name = "Unknow";
            League = "Unknow";
            Rating = 0;
        }
    }
}