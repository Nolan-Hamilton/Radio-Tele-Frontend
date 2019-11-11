using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RTAstronomicalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkyViewController : ControllerBase
    {
        private readonly ILogger<SkyViewController> _logger;
        public SkyViewController(ILogger<SkyViewController> logger)
        {
            _logger = logger;
        }

        public static String GenerateImage(int year, int month, int day, int hour, int minute, float longitude, float laditude, int altitude, float targetRA, float targetDec)
        {
            int WIDTH = 720;
            int HEIGHT = 180;
            DrawSky.Easel easel = new DrawSky.Easel(new System.Drawing.Size(WIDTH, HEIGHT));
            easel.dt = new DateTime(year, month, day, hour, minute, 0);
            easel.longitude = longitude;
            easel.latitude = laditude;
            easel.altitude = altitude;
            easel.targetRA = targetRA;
            easel.targetDec = targetDec;
            easel.coordinates = false;
            easel.MakeNewEasel();

            String filename = "skyview-" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + (int)longitude + "-" + (int)laditude + "-" + altitude + "-" + (int)targetRA + "-" + (int)targetDec + ".png";

            Image image = easel.sky;

            image.Save("../images/" + filename, ImageFormat.Png);

            return filename;
        }

        public SkyView Get()
        {
            SkyView view = new SkyView();
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            float longitude = -76.704564F;
            float laditude = 40.024409F;
            int altitude = 390;
            float targetRA = 0.0F;
            float targetDec = 0.0F;
            view.filepath = GenerateImage(year, month, day, hour, minute, longitude, laditude, altitude, targetRA, targetDec);
            return view;
        }

        [HttpGet]
        public String Get(int year, int month, int day, int hour, int minute, float targetRA, float targetDec, float longitude, float latitude, int altitude)
        {
            Console.WriteLine("altitude: " + altitude);
            SkyView view = new SkyView();
            // float longitude = -76.704564F;
            // float laditude = 40.024409F;
            view.filepath = GenerateImage(year, month, day, hour, minute, longitude, latitude, altitude, targetRA, targetDec);
            return view.filepath;
        }
    }
}