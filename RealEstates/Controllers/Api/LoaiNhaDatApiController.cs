using AutoMapper;
using RealEstates.Dtos;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealEstates.Controllers.Api
{
    public class LoaiNhaDatApiController : ApiController
    {
        private ApplicationDbContext _context;

        public LoaiNhaDatApiController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetLoaiNhaDats(bool isRent)
        {
            var loaiNhaDatsInDb = _context.LoaiNhaDats.Where(x => x.IsRent == isRent).ToList();
            var loaiNhaDatDtos = loaiNhaDatsInDb.Select(Mapper.Map<LoaiNhaDat, LoaiNhaDatDto>);
            return Ok(loaiNhaDatDtos);
        }

        public IHttpActionResult GetLoaiNhaDatTinRaos(int loaiTinRao)
        {
            if (loaiTinRao == 1 || loaiTinRao == 2)
            {
                var loaiNhaDatInDb = _context.LoaiNhaDats.Where(x => !x.IsRent).ToList();
                var loaiNhaDatDtos = loaiNhaDatInDb.Select(Mapper.Map<LoaiNhaDat, LoaiNhaDatDto>);
                return Ok(loaiNhaDatDtos);
            } else
            {
                var loaiNhaDatInDb = _context.LoaiNhaDats.Where(x => x.IsRent).ToList();
                var loaiNhaDatDtos = loaiNhaDatInDb.Select(Mapper.Map<LoaiNhaDat, LoaiNhaDatDto>);
                return Ok(loaiNhaDatDtos);
            }
        }

    }
}
