namespace BgPeopleWebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BgPersonModel
    {
        public BgPersonModel()
        { 
        }

        public BgPersonModel(string firstName, string middleName, string lastName, bool isMale, DateTime birthday, string city, string phone, string egn)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.IsMale = isMale;
            this.BirthDay = birthday.Date;
            this.City = city;
            this.PhoneNumber = phone;
            this.EGN = egn;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        public bool IsMale { get; set; }

        public DateTime? BirthDay { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string EGN { get; set; }
    }
}
