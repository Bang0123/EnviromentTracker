using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPMeasurementSender
{
    class NameGenerator
    {
        private static Random rng = new Random();
        public Measurement randomname(int lokalenr)
        {
            Measurement tempMeasurement = new Measurement(lokalenr, rng.Next(56,80), rng.Next(400, 500), rng.Next(18, 24));
            return tempMeasurement;
        }
    }
}

