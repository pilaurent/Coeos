using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models
{
    public class Lieu
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Site { get; set; }
        public string Code { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datecre { get; set; }

    }
}
