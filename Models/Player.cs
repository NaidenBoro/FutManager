namespace FutManager.Models
{
    public class Player
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }
        public string Nationality { get; set; }
        public string Club { get; set; }
        public int Overal { get; set; }
        public bool isReal { get; set; }

        public Player(string fname,string lname,string pos,int age,int num,string nat,string club, int ov,bool real)
        {
            FisrtName = fname;
            LastName = lname;
            Position = pos;
            Age = age;
            ShirtNumber = num;
            Nationality = nat;
            Club = club;
            Overal = ov;
            isReal = real;
        }
    }
}
