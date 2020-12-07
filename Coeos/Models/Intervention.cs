using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        [Display(Name = "Agents")]
        public IList<AgentIntervention> AgentInterventions { get; set; } = new List<AgentIntervention>();

        public List<Lieu> Lieux { get; set; }
        public string Description { get; set; }

      

        [DataType(DataType.Date)]
        public DateTime Dateintervention { get; set; }

        public Boolean Encours { get; set; }
        public Boolean Fin { get; set; }
        public List<Photo> Photos { get; set; }
        public string Escalade { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datecre { get; set; }

        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
