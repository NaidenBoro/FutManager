namespace FutManager.Models
{
    public class Manager
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Club { get; set; }
        public int Rating { get; set; }
        public bool isReal { get; set; }

        public Manager(string fname, string lname, int age, string nat, string club, int rat, bool real)
        {
            FisrtName = fname;
            LastName = lname;
            Age = age;
            Nationality = nat;
            Club = club;
            Rating = rat;
            isReal = real;
        }
    }
}
