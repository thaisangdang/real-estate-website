using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Dtos
{
    public class NhaDatDto
    {
        public int Id { get; set; }

        public string Ten { get; set; }

        public int DuAnId { get; set; }

        public bool IsRent { get; set; }

        public int LoaiNhaDatId { get; set; }

        public int TinhThanhPhoId { get; set; }

        public int QuanHuyenId { get; set; }
    }
}