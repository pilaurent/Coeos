using Coeos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models.ViewsModels
{
    public class AddInterventionViewModel
    {
        [Required]
        [Display(Name = "Nom intervention")]
        public Intervention Intervention { get; set; }
    }
}
