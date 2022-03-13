using System.ComponentModel.DataAnnotations;

namespace FutManager.Models
{
    public class Manager
    {
        public int Id { get; set; }
       
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        [Range(1, int.MaxValue,ErrorMessage = "Please enter a value bigger than {1}")]
        public int Age { get; set; }
        public int NationalityId { get; set; }
        public Nation? Nation { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
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
            NationalityId = -1;  
            ClubId = -1;
            Id = -1;
            FisrtName = "Uknown";
            LastName = "Uknown";
           
            Age = 0;
            NationalityId = -1;
            ClubId = -1;
            Rating = 0;
            isReal = false;
        }
    }
}
