using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models
{
    public class AgentIntervention
    {
        public int InterventionID { get; set; }
        public Intervention Intervention { get; set; }
        public int AgentID { get; set; }
        public Agent Agent { get; set; }
    }
}
