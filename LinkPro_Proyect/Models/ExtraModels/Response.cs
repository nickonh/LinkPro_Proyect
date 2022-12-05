using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LinkPro_Proyect.Models.ExtraModels
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
    }
}