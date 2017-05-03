using System;

namespace UDPMeasurementSender
{
    public class Measurement
    {
        public int LokaleId { get; set; }

        public int ID { get; set; }

        public DateTime Tid { get; set; }

        public int Lyd { get; set; }

        public int Lys { get; set; }

        public int Temp { get; set; }

        public Measurement(int lokaleId, int lyd, int lys, int temp)
        {
            LokaleId = lokaleId;
            Lyd = lyd;
            Lys = lys;
            Temp = temp;
            Tid = DateTime.Now;
            ID = 0;
        }

        public override string ToString()
        {
            return $"LokaleId: {LokaleId}, ID: {ID}, Tid: {Tid}, Lyd: {Lyd}, Lys: {Lys}, Temp: {Temp}";
        }
    }

    
}
