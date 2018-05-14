using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int App_ID { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Applicant_IP { get; set; }
        [Required]
        [ForeignKey("Vacancy")]
        public int Vacancy_Code { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        [Required]
        [ForeignKey("Applicant")]
        public int PersonalNumber { get; set; }
        public virtual Applicant Applicant { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int Exam_Id { get; set; }
        public virtual Exam Exam { get; set; }

        public bool Is_Confirmed { get; set; }
    }

    public class ApplicationHelper
    {
        public string action { get; set; }
        public Application application { get; set; }
    }
}