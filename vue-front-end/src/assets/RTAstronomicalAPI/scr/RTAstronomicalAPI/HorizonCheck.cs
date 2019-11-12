using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTAstronomicalAPI
{
    public class HorizonCheck
    {
        public HorizonCheck()
        {
            visible = false;
            azimuth = 0;
            elevation = 0;
        }
        public bool visible { get; set; }

        public float azimuth { get; set; }
        public float elevation { get; set; }
    }
}
