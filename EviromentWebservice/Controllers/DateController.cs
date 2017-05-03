using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EviromentWebservice.Models;

namespace EviromentWebservice.Controllers
{
    [RoutePrefix("api/date")]
    public class DateController : ApiController
    {
        private Tempdb db = new Tempdb();


        // GET: api/date/2011-02-17
        [Route("{time:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> GetDateTask(DateTime time)
        {
            var task = await Task.Run(() =>
            {
                var measurement = db.Measurements.Where(m => time.Date == DbFunctions.TruncateTime(m.Tid));
                return measurement;
            });

            if (task == null || task.Count() < 1)
            {
                return NotFound();
            }

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
