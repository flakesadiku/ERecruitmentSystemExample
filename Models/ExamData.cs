using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class ExamData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Exam_Data_Id { get; set; }
        [Required]
        public string Exam_Title { get; set; }
        [Required]
        public int Performance_Summary { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int Exam_Id { get; set; }
        public virtual Exam Exam { get; set; }
        [Required]
        public DateTime Exam_Date { get; set; }
    }
}