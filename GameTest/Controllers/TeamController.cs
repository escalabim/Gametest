using GameTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameTest.Model;

namespace GameTest.Controllers
{
    public class TeamController : ApiController
    {
        public IHttpActionResult Post([FromBody] ObjTeam team)
        {
            try
            {
                if (Validation.ValidParamTeamCreate(team))
                {
                    if (ActionG.CreateTeam(team.name))
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
