using AutoMapper;
using RealEstates.Dtos;
using RealEstates.Models;
using System.Linq;
using System.Web.Http;

namespace RealEstates.Controllers.Api
{
    public class NhaDatApiController : ApiController
    {
        private ApplicationDbContext _context;

        public NhaDatApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/GetNhaDats/1
        public IHttpActionResult GetNhaDats(int duAnId)
        {
            var nhaDatsInDb = _context.NhaDats.Where(x => (x.DuAnId == duAnId)
                && (_context.PhanCongSales.FirstOrDefault(y => y.NhaDatId == x.Id) == null))
                .ToList();
            var nhaDatDtos = nhaDatsInDb.Select(Mapper.Map<NhaDat, NhaDatDto>);
            return Ok(nhaDatDtos);
        }
    }
}