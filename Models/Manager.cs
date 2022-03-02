namespace FutManager.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int NationalityId { get; set; }
        public Nation? Nation { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        public int Rating { get; set; }
        public bool isReal { get; set; }

        public Manager(int id, string fname, string lname, int age, int nat, int club, int rat, bool real)
        {
            Id = id;
            FisrtName = fname;
            LastName = lname;
            Age = age;
            NationalityId = nat;
            ClubId = club;
            Rating = rat;
            isReal = real;
        }

        public Manager()
        {
            Id = -1;
            FisrtName = "John";
            LastName = "John";
            Age = 20;
            NationalityId = -1;
            ClubId = -1;
            Rating = 0;
            isReal = false;
        }
    }
}
