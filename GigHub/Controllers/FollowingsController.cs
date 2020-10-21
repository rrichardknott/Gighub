using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    public class FollowingDto
    {
        public string FolloweeId { get; set; }
    }

    [Authorize]
    public class FollowingsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();


        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (db.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("A Following Already Exist");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            db.Followings.Add(following);
            db.SaveChanges();

            return Ok();
        }

    }
}
