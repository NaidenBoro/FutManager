namespace FutManager.Models
{
    public class Nation
    {
        public string Name { get; set; }
        public string Confederation { get; set; }
        public int Rating { get; set; }

        public Nation(string name, string confederation,int rating)
        {
            Name = name;
            Confederation = confederation;
            Rating = rating;
        }

        public Nation()
        {
            Name = "Unknow";
            Confederation = "Unknow";
            Rating = 0;
        }
    }
}