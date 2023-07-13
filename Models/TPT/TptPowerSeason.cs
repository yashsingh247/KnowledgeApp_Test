using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.TPT
{
    public class TptPowerSeason
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 TptPowerSeasonId { get; set; }
        //[EditLink]
        public Int16 TptYear { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 RevisionId { get; set; }
        public String RevisionRevisionName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 TptPowerParameterId { get; set; }
        public String TptPowerParameterTptPowerCode { get; set; }
        public Decimal Target { get; set; }
        public Decimal Actual { get; set; }
        public Decimal LastYearActual { get; set; }
        public List<TptRevision> TptRevision { get; set; }
        public List<TptParameter> TptParameter { get; set; }
    }
}