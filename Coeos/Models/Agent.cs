using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Poste { get; set; }
        public string Categorie { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datecre { get; set; }
        public List<AgentIntervention> AgentInterventions { get; set; }

        public string FullName
        {
            get
            {
                return $"{Nom} {Prenom}";
            }
        }
    }
}
