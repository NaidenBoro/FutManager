namespace FutManager.Models
{
    public class Nation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Confederation { get; set; }
        public int Rating { get; set; }

        public Nation(int id,string name, string confederation,int rating)
        {
            Id = id;
            Name = name;
            Confederation = confederation;
            Rating = rating;
        }

        public Nation()
        {
            Name = "";
            Confederation = "";
        }
    }
}