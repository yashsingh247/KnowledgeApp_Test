﻿namespace KnowledgeApp_Test.App_Start
{
    internal class RedirectToActionResult
    {
        private string v1;
        private string v2;
        private object p;

        public RedirectToActionResult(string v1, string v2, object p)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.p = p;
        }
    }
}