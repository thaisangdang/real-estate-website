using RealEstates.Models;
using RealEstates.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    [AllowAnonymous]
    public class DoanhNghiepController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public DoanhNghiepController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: DoanhNghiep
        public ActionResult Index()
        {
            var viewModel = new DanhSachDoanhNghiepViewModel
            {
                DoanhNghiepBDSs = _context.DoanhNghiepBDSs.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var doanhNghiep = _context.DoanhNghiepBDSs.SingleOrDefault(x => x.Id == id);
            return View(doanhNghiep);
        }
    }
}