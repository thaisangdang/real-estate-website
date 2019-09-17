using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Dtos
{
    public class QuanHuyenDto
    {
        public int Id { get; set; }

        public string Ten { get; set; }

        public string Prefix { get; set; }

        public int TinhThanhPhoId { get; set; }

    }
}