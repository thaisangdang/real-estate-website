using RealEstates.Dtos;
using RealEstates.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace RealEstates.Areas.Admin.Controllers.Api
{
    public class QuanLyTaiKhoanApiController : ApiController
    {
        private ApplicationDbContext _context;

        public QuanLyTaiKhoanApiController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TaiKhoanDto> GetTaiKhoans(string query = null)
        {
            var taiKhoans = new List<TaiKhoanDto>();
            var users = _context.Users.Include(u => u.Roles);
            foreach (var user in users)
            {
                var taiKhoan = new TaiKhoanDto();
                taiKhoan.Id = user.Id;
                taiKhoan.Email = user.Email;
                var roleId = user.Roles.First().RoleId;
                taiKhoan.Role = _context.Roles.SingleOrDefault(r => r.Id == roleId).Name;
                taiKhoans.Add(taiKhoan);
            }

            if (!string.IsNullOrWhiteSpace(query))
            {
                taiKhoans = taiKhoans.Where(m => m.Email.Contains(query)).ToList();
            }

            return taiKhoans;
        }

        public IHttpActionResult GetTaiKhoan(string id)
        {
            var taiKhoan = new TaiKhoanDto();
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            taiKhoan.Id = user.Id;
            taiKhoan.Email = user.Email;
            var roleId = user.Roles.First().RoleId;
            // error
            taiKhoan.Role = _context.Roles.SingleOrDefault(r => r.Id == roleId).Name;

            return Ok(taiKhoan);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.Administrator)]
        public IHttpActionResult UpdateTaiKhoan(string id, TaiKhoanDto taiKhoanDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newRole = _context.Roles.SingleOrDefault(r => r.Name == taiKhoanDto.Role);
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
            {
                return NotFound();
            }

            userInDb.Roles.First().RoleId = newRole.Id;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.Administrator)]
        public IHttpActionResult DeleteTaiKhoan(string id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                return NotFound();

            _context.Users.Remove(userInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
