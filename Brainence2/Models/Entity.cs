using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brainence2.Models
{
    public class Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; private set; }
        public String Sentence { get; set; }
        public String Word { get; set; }
        public Int32 Counter { get; set; }
    }
}