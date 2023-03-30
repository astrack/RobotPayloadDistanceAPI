using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class RobotsController : BaseApiController
    {

        // public async Task<ActionResult<int>> Closest(){
        //     Robot r1 = new Robot();
        //     return await r1.GetClosestRobotId();
        // }

        [HttpPost]
        [Route("closest")]
        public async Task<Robot> PostPayloadToGetClosestId(Payload payload){
            Robot r1 = new Robot();
            //AS:TODO: store payload in db or memory and move this call 
            return await r1.GetClosestRobotIdToPayload(payload) ;
        }

        public JsonResult ClosestRobotJsonResult(ActionResult<int> task){
            return Json(task);
        }

        

    }
}