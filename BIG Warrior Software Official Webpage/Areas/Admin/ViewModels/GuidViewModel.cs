using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BIG_Warrior_Software_Official_Webpage.Areas.Admin.ViewModels
{
    public class GuidViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string CRN
        {
            get
            {
                return "171A8705-367F-420D-9CEE-6D2F66B63CA5";
            }
        }
    }
}
