using Microsoft.AspNetCore.Mvc;
using RemoteDoorbell.Attributes;
using RemoteDoorbell.Model;
using System.Collections.Generic;
using System.Linq;

namespace RemoteDoorbell.Controllers
{
    [Auth]
    [ApiController]
    [Route("[controller]")]
    public class RingController : Controller
    {
        readonly DoorbellContext _db;

        public RingController(DoorbellContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult RingTheDoorbell()
        {
            _db.RingEntries.Add(new RingEntry());
            _db.SaveChanges();

            return Accepted();
        }
        
        [HttpGet]
        public ActionResult<RingEntry[]> GetRingEntries()
        {
            List<RingEntry> ringEntries = _db.RingEntries.ToList();

            return Ok(ringEntries);
        }
    }
}
