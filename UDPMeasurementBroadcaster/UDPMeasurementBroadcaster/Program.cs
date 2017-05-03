using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPMeasurementSender
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1"); //
            //UdpClient udpSender = new UdpClient("192.168.6.138", 8080); //

            NameGenerator generator = new NameGenerator();

            while (true)
            {
                Measurement measurement = generator.randomname(201);
                Measurement measurement2 = generator.randomname(203);

               //Byte[] sendBytes = Encoding.ASCII.GetBytes(measurment);
                try
                {
                    Task.Run(async () => await ApiClient.Post("http://eviromentwebservice.azurewebsites.net/", "api/measurements", measurement));
                    Task.Run(async () => await ApiClient.Post("http://eviromentwebservice.azurewebsites.net/", "api/measurements", measurement2));
                    //udpSender.Send(sendBytes, sendBytes.Length);//,RemoteIpEndPoint);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine("measurement: " + measurement);
                Console.WriteLine("measurement2: " + measurement2);
                Thread.Sleep(TimeSpan.FromMinutes(10));
               
                
            }

        }
    }

}


