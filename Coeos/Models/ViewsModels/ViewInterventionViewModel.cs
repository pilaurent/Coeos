using Coeos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models.ViewsModels
{
    public class ViewInterventionViewModel
    {
        [Required]
        [Display(Name = "Intervention")]
        public Intervention Intervention { get; set; }
        [Required]
        [Display(Name = "Agent")]
        public IList<AgentIntervention> Items { get; set; }
    }
}
