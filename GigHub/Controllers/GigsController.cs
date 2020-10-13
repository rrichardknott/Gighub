using GigHub.Models;
using GigHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        //public GigsController()
        //{
        //    db = new ApplicationDbContext();
        //}

        // GET: Gigs
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = db.Genres.ToList()
            };
            return View(viewModel);
        }

    }
}