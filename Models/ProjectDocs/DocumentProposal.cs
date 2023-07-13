using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.ProjectDocs
{
    public class DocumentProposal
    {

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Visible(false)]
        public Int32 DocumentProposalId { get; set; }
        public Int16 ProposalCode { get; set; }
        //[EditLink]
        public String ProposalName { get; set; }
    }
}