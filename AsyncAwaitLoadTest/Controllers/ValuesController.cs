using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsycAwaitLoadTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet("/LongService")]
        public async Task<IActionResult> GetLongService(string time)
        {

            await System.Threading.Tasks.Task.Delay(5000);
            return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString() });
        }

        //public IActionResult GetLongService(string time)
        //{

        //    Thread.Sleep(5000);
        //    return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString() });
        //}

        [HttpGet("/ShortService")]
        //public async Task<IActionResult> GetShortService(string time, int? id)
        //{
        //    if (id == null)
        //    {
        //        await System.Threading.Tasks.Task.Delay(5000);
        //        return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString() });
        //    }

        //    HttpClient httpClient = new HttpClient();
        //    HttpResponseMessage result = await httpClient.GetAsync(new Uri("https://jsonplaceholder.typicode.com/comments/" + id));
        //    var content = await result.Content.ReadAsStringAsync();

        //    return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString(), content });
        //}

        public  IActionResult GetShortService(string time, int? id)
        {
            if (id == null)
            {
                Thread.Sleep(5000);
                //await System.Threading.Tasks.Task.Delay(5000);

                return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString() });
            }


            //Thread.Sleep(100);
            //await System.Threading.Tasks.Task.Delay(100);

            //return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString(),id.ToString()});


            HttpClient httpClient = new HttpClient();
            HttpResponseMessage result = httpClient.GetAsync(new Uri("https://jsonplaceholder.typicode.com/comments/" + id)).Result;
            var content = result.Content.ReadAsStringAsync().Result;

            return new ObjectResult(new string[] { time, DateTime.Now.ToLongTimeString(), content });
        }


    }
}
