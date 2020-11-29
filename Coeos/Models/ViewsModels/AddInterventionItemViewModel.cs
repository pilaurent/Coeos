using Coeos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models.ViewsModels
{
    public class AddInterventionItemViewModel
    {
        public Intervention Intervention { get; set; }
        public List<SelectListItem> Agents { get; set; }

        public int InterventionID { get; set; }
        public int AgentID { get; set; }

        public AddInterventionItemViewModel() {}

        public AddInterventionItemViewModel(Intervention intervention, IEnumerable<Agent> agents)
        {
            Agents = new List<SelectListItem>();

            foreach (var agent in agents)
            {
                Agents.Add(new SelectListItem
                {
                    Value = agent.Id.ToString(),
                    Text = agent.FullName
                });
            }

            Intervention = intervention;
        }
    }
}
