using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Dtos
{
    public class LoaiNhaDatDto
    {
        public int Id { get; set; }

        public string TenLoai { get; set; }

        public bool IsRent { get; set; }
    }
}