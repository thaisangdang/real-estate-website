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

    }
}
