using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.Utilities
{
   public class IdNamePairRM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int ParentID { get; set; }
        public int ParentID_1 { get; set; }
        public int ParentID_2 { get; set; }
        public string ParentName { get; set; }

        public SelectListGroup Group { get; set; }


    }
}
