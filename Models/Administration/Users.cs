using KnowledgeApp_Test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Administration
{
    public class Users
    {
        public Int32 UserId { get; set; }
     
        public String Username { get; set; }
        
        public String DisplayName { get; set; }
        
        public String Email { get; set; }
        public String Source { get; set; }
        public Int32 UnitID { get; set; }
        public String UnitUnitName { get; set; }
        public String PassWord { get; set; }
        public String ConfirmPassWord { get; set; }
        public DateTime LastDirectoryUpdate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int32 InsertUserId { get; set; }
        public String UserImage { get; set; }
        public Int16 IsActive { get; set; }
        public Int32 UpdateUserId { get; set; }
        public String PasswordSalt { get; set; }
        public Int32 RoleId { get; set; }
        public String RoleName { get; set; }
        public Int32 UserRoleId { get; set; }

        public List<int> units { get; set; }

    }
    public class UserPermisssion
    {
        public Int32 UserId { get; set; }
        public Int32 MenuId { get; set; }
        public int UnitId { get; set; }
        public Int32 RoleId { get; set; }
        public Int32 SubMenuId { get; set; }
        public Int32 FormId { get; set; }
       // public Int32 USerId { get; set; }
        public bool BtnAdd { get; set; }
        public bool btnEdit { get; set; }
        public bool btnDelete { get; set; }
        public bool btnView { get; set; }
        public bool btnSearch { get; set; }
        public bool btnExportExcel { get; set; }
        public bool btnExportPdf { get; set; }
        public bool IsSelected { get; set; }
        public string FormName { get; set; }
        public string URL { get; set; }
        public Int32 SerialNumber { get; set; }
        public Int32 status { get; set; }
        public String RoleCode { get; set; }
        public String RoleName { get; set; }
        public bool BtnNotification { get; set; }


    }
    public class UserRoles
    {
        public bool IsSelect { get; set; }
        public Int32 UserId { get; set; }
        public Int32 RoleId { get; set; }
        public String USerName { get; set; }
        public String RoleName { get; set; }
        public Int32 MaippingId { get; set; }
        public int UnitId { get; set; }




    }

    public class FormValidation
    {
        public Int32 FormId { get; set; }
        // public Int32 USerId { get; set; }
        public bool BtnAdd { get; set; }
        public bool btnEdit { get; set; }
        public bool btnDelete { get; set; }
        public bool btnView { get; set; }
        public bool btnSearch { get; set; }
        public bool btnExportExcel { get; set; }
        public bool btnExportPdf { get; set; }
        //public bool IsSelected { get; set; }
        public string FormName { get; set; }




    }
}