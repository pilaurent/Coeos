using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models
{
    public class Societe
    {
        public int SocieteId { get; set; }
        public string Nom { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datecre { get; set; }

    }
}
