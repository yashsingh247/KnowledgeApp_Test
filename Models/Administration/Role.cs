using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Administration
{
    public class Role
    {
        public Int32 RoleId { get; set; }
        public String RoleName { get; set; }
        public List<int> Units { get; set; }
    }

    public class RolePermisssion
    {
        public Int32 UnitID { get;set; }
        public Int32 MenuId { get; set; }
        public Int32 RoleId { get; set; }
        public Int32 SubMenuId { get; set; }
        public Int32 FormId { get; set; }
        public Int32 USerId { get; set; }
        public bool BtnAdd { get; set; }
        public bool btnEdit { get; set; }
        public bool btnDelete { get; set; }
        public bool btnView { get; set; }
        public bool btnSearch { get; set; }
        public bool btnExportExcel { get; set; }
        public bool btnExportPdf { get; set; }
        public bool IsSelected { get; set; }
        public string FormName { get; set; }
        public string FormNameName { get; set; }
        public string URL { get; set; }
        public Int32 SerialNumber { get; set; }
        public Int32 status { get; set; }
        public String RoleCode{ get; set; }
        public String RoleName { get; set; }
        public bool BtnNotification { get; set; }
        public String SubMenuName { get; set; }
        public string MenuName { get; set; }
        //public string SubMenuName { get; set; }
    }
   
}