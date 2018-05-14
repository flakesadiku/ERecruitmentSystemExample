using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class ApplicantsEducation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Applicant")]
        public int PersonalNumber { get; set; }
        public virtual Applicant Applicant { get; set; }
        [Required]
        [ForeignKey("Education")]
        public int Education_Id { get; set; }
        public virtual Education Education { get; set; }
    }
}