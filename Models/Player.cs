namespace FutManager.Models
{
    public class Player
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }
        public Nation? Nationality { get; set; }
        public Club? Club { get; set; }
        public int Overall { get; set; }
        public bool isReal { get; set; }

        public Player(string fname,string lname,string pos,int age,int num,Nation nat,Club club, int ov,bool real)
        {
            FisrtName = fname;
            LastName = lname;
            Position = pos;
            Age = age;
            ShirtNumber = num;
            Nationality = nat;
            Club = club;
            Overall = ov;
            isReal = real;
        }

        public Player()
        {
            FisrtName = "Uknown";
            LastName = "Uknown";
            Position = "Uknown";
            Age = 0;
            ShirtNumber = 0;
            Nationality = null;
            Club = null;
            Overall = 0;
            isReal = false;
        }
    }
}
