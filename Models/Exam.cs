using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Exam_Id { get; set; }
        [Required]
        public string Exam_Description { get; set; }
        [Required]
        public int TotalPoints { get; set; }
        [Required]
        public int Pass_Threshold { get; set; }
        [Required]
        public int Exam_Page_No { get; set; }

    }
}