using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.ViewModels
{
    public class LoaiDuAnViewModel
    {
        public LoaiDuAn LoaiDuAn { get; set; }

        public string Title
        {
            get
            {
                return LoaiDuAn.Id == 0 ? "Tạo mới loại dự án" : "Chỉnh sửa loại dự án";
            }
        }

        public LoaiDuAnViewModel()
        {
            LoaiDuAn = new LoaiDuAn();
            LoaiDuAn.Id = 0;
        }

        public LoaiDuAnViewModel(LoaiDuAn loaiDuAn)
        {
            LoaiDuAn = loaiDuAn;
        }
    }
}