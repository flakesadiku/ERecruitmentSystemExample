using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Education_Id { get; set; }
        [Required]
        public string Education_Name { get; set; }
        [Required]
        public string Education_Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Degree_Img_Link { get; set; }
    }
}