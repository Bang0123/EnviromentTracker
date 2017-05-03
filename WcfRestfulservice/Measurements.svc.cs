using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace WcfRestfulservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Measurements" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Measurements.svc or Measurements.svc.cs at the Solution Explorer and start debugging.
    public class Measurements : IMeasurements
    {
        private Tempdb db = new Tempdb();


        public async Task<IQueryable<Measurement>> GetDateTask(string time)
        {
            DateTime date;
            try
            {
                if (!Regex.IsMatch(time, "\\d{4}-\\d{2}-\\d{2}"))
                {
                    return null;
                }
                date = DateTime.Parse(time);
            }
            catch (Exception)
            {
                return null;
            }


            var task = await Task.Run(() =>
            {
                var measurement = db.Measurements.Where(m => date.Date == DbFunctions.TruncateTime(m.Tid));
                return measurement;
            });

            if (task == null || task.Count() < 1)
            {
                return null;
            }
            return task;
        }

        public IQueryable<Measurement> GetMeasurements()
        {
            return db.Measurements;
        }

        public Measurement GetMeasurement(string id)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return null;
            }

            return measurement;
        }

        public Measurement DeleteMeasurement(string id)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return null;
            }

            db.Measurements.Remove(measurement);
            db.SaveChanges();

            return measurement;
        }

        public Measurement AddMeasurement(Measurement measurement)
        {
            try
            {
                db.Measurements.Add(measurement);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return measurement;
        }

        public Measurement UpdateMeasurement(Measurement measurement)
        {
            db.Entry(measurement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(measurement.ID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return measurement;
        }
        private bool MeasurementExists(int id)
        {
            return db.Measurements.Count(e => e.ID == id) > 0;
        }


    }
}
