using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }

    }
}
