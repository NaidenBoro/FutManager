using System.ComponentModel.DataAnnotations;

namespace FutManager.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Age { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int ShirtNumber { get; set; }
        public int NationalityId { get; set; }
        public Nation? Nation { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Overall { get; set; }
        public bool isReal { get; set; }

        public Player(int id, string fname,string lname,string pos,int age,int num,int nat,int club, int ov,bool real)
        {
            Id = id;
            FisrtName = fname;
            LastName = lname;
            Position = pos;
            Age = age;
            ShirtNumber = num;
            NationalityId = nat;
            ClubId = club;
            Overall = ov;
            isReal = real;
        }

        public Player()
        {
            Id = -1;
            FisrtName = "Uknown";
            LastName = "Uknown";
            Position = "Uknown";
            Age = 0;
            ShirtNumber = 0;
            NationalityId = -1;
            ClubId = -1;
            Overall = 0;
            isReal = false;
        }
    }
}
