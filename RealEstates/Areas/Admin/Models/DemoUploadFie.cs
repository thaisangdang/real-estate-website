using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class DemoUploadFie
    {
        public string FilePath { get; set; }
        public HttpPostedFile ImageFile { get; set; }
    }
}