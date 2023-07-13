using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Administration
{
    public class FormMaster
    {
       
        public int FormID { get; set; }
        public int MenuID { get; set; }
        public int SubMenuID { get; set; }
        public String FormNameName { get; set; }
        public String  URL { get; set; }
        public int SrialNo { get; set; }
        public bool Status { get; set; }
       

    }
    public class MenuMaster
    {
        public int MenuID { get; set; }
        public String MenuName { get; set; }
        public String URL { get; set; }
        public int SrialNo { get; set; }
        public bool Status { get; set; }

    }
    public class SubMenuMaster
    {
        public int SubMenuID { get; set; }
        public int MenuID { get; set; }
        public String SubMenuName { get; set; }
        public String URL { get; set; }
        public int SrialNo { get; set; }
        public int Status { get; set; }

    }
    public class RolePermisssionList
    {
        public Int32 MenuID { get; set; }
        public Int32 RoleID { get; set; }
        public Int32 SubMenuID { get; set; }
        public Int32 FormID { get; set; }
        public Int32 USerId { get; set; }
        public String BtnAdd { get; set; }
        public String btnEdit { get; set; }
        public String btnDelete { get; set; }
        public String btnView { get; set; }
        public String btnSearch { get; set; }
        public String btnExportExcel { get; set; }
        public String btnExportPdf { get; set; }
        public String IsSelected { get; set; }
        public string FormName { get; set; }
        public String BtnNotification { get; set; }


    }

}