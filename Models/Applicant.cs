using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Applicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonalNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        public string PassportNumber { get; set; }
        public string DrivingLicence { get; set; }
        [Required]
        public string UserLocation { get; set; }
        
    }

    public class ApplicantHelper
    {
        public string action { get; set; }
        public Applicant applicant { get; set; }
    }
}