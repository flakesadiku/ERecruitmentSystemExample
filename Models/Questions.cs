using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Question_Id { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int Exam_Id { get; set; }
        public virtual Exam Exam { get; set; }
        public int Vacancy_Code { get; set; }
        public bool Answer { get; set; }
    }
}