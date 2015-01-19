using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entity
{
    public class Programme
    {       
        public int ProgrammeId { set; get; }

        [Required]      
        [Display(Name = "Programme Name")]
        public string ProgrammeName { set; get; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Start Date")]
        public DateTime StartDate { set; get; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { set; get; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Num of Question")]
        public int NumOfQuestion { set; get; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Time Limit")]
        public int TimeLimit { set; get; }

        [Required]
        [Display(Name = "Is Hourly")]
        [DefaultValue(true)]
        public bool IsHourly { set; get; }

        [Required]
        [Display(Name = "Is Active")]
        [DefaultValue(true)]
        public bool IsActive { set; get; }
    }
}
