using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.TPT
{
    public class TptSeason
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 TptSeasonId { get; set; }
       // public int TPTSeasonId { get; internal set; }

        //[EditLink]
        public Int16 TptYear { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 RevisionId { get; set; }
        public String RevisionRevisionName { get; set; }

        //[Visible(false), QuickFilter]
        public Int32 TptParameterId { get; set; }
        public String TptParameterParameterCode { get; set; }
        public Decimal Target { get; set; }
        public Decimal Actual { get; set; }
        public Decimal LastYearActual { get; set; }
        public Decimal TargetTex { get; set; }
        public Decimal TagetWil { get; set; }
        public Decimal ActualTex { get; set; }
        public Decimal ActualWil { get; set; }
        public List<TptRevision> TptRevision { get; set; }
        public List<TptParameter> TptParameter { get; set; }
    }
}