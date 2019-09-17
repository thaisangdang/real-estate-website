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
    public class DuAnApiController : ApiController
    {
        private ApplicationDbContext _context;

        public DuAnApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/GetQuanHuyens/1

        public IHttpActionResult GetQuanHuyens(int tinhThanhPhoId)
        {
            var quanHuyensInDb = _context.QuanHuyens.Where(x => x.TinhThanhPhoId == tinhThanhPhoId).ToList();
            var quanHuyenDtos = quanHuyensInDb.Select(Mapper.Map<QuanHuyen, QuanHuyenDto>);

            return Ok(quanHuyenDtos);
        }

    }
}
