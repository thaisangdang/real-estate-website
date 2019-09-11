using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.ViewModels
{
    public class DuAnViewModel
    {
        public int Id { get; set; }

        public DuAn DuAn { get; set; }

        public string Title
        {
            get
            {
                return DuAn.Id == 0 ? "Tạo mới dự án" : "Chỉnh sửa dự án";
            }
        }

        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public DuAnViewModel()
        {
            DuAn = new DuAn();
            DuAn.Id = 0;
            DuAn.LoaiDuAn = new LoaiDuAn();
            DuAn.TinhThanhPho = new TinhThanhPho();
        }

        public DuAnViewModel(DuAn duAn)
        {
            DuAn = duAn;
        }

    }
}