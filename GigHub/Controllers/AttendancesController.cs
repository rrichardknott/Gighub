using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    public class AttendanceDto //Dto = Data Transfer Object
    {
        public int GigId { get; set; }
    }

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (db.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("This attendance already exists.");
            }
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            db.Attendances.Add(attendance);
            db.SaveChanges();

            return Ok();
        }

    }
}
