using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Control
{
    public class BrixWeight
    {
        public Int32 BrixWeightId { get; set; }
        //[EditLink]
        [Required]
        public Decimal BrixValue { get; set; }
        public Decimal ValueAt20 { get; set; }
        public Decimal ValueAt27 { get; set; }
    }
}