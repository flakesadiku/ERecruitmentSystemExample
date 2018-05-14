using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecruitmentSystem.Models
{
    public class Languages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Language_Id { get; set; }
        public string Education_Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [ForeignKey("Education")]
        public int Education_Id { get; set; }
        public virtual Education Education { get; set; }
    }
}