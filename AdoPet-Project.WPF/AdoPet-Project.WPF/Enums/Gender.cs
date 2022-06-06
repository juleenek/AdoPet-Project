using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoPet_Project.WPF.Enums
{
   public enum Gender
    {
        [Display(Name = "male")] male,
        [Display(Name = "female")] female
    }
}
