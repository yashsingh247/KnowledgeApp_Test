﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Control
{
    public class ControlParameterGroup
    {
        public Int32 ParameterId { get; set; }
        //[EditLink]
        public String ParameterCode { get; set; }
        public String ParameterName { get; set; }
        public String ParameterDescription { get; set; }
        //[Visible(false), QuickFilter]
        public Int32 ParameterGroupId { get; set; }
        public String ParameterGroupControlParameterGroupName { get; set; }
        public Int16 SerialOrder { get; set; }
        public String ParameterType { get; set; }
        public Int32 ParameterWidth { get; set; }
        public string ControlParameterGroupName { get; set; }
    }
}