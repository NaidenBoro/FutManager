namespace FutManager.Models
{
    public class Manager
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Nation? Nationality { get; set; }
        public Club? Club { get; set; }
        public int Rating { get; set; }
        public bool isReal { get; set; }

        public Manager(string fname, string lname, int age, Nation nat, Club club, int rat, bool real)
        {
            FisrtName = fname;
            LastName = lname;
            Age = age;
            Nationality = nat;
            Club = club;
            Rating = rat;
            isReal = real;
        }

        public Manager()
        {
            FisrtName = "John";
            LastName = "John";
            Age = 20;
            Nationality = null;
            Club = null;
            Rating = 0;
            isReal = false;
        }
    }
}
