using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
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


        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = db.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = db.Genres.ToList();
                return View("Create", viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                //DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            db.Gigs.Add(gig);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}