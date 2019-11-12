using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RTAstronomicalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        /*
        [HttpGet]
        public String Get()
        {
            return "Hello, World!";
        }
        */

        [HttpGet("{potato}")]
        public String Get(String potato, String s)
        {
            return potato + "," + s;
        }
       
        [HttpGet]
        public int Adder(int a, int b)
        {
            return a + b;
        }
    } 
}