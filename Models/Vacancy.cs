using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Vacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vacancy_Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class VacancyHelper
    {
        public string action { get; set; }
        public Vacancy vacancy { get; set; }
    }
}