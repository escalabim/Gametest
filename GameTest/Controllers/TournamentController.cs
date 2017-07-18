using GameTest.Model;
using GameTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace GameTest.Controllers
{
    public class TournamentController : ApiController
    {
        public IHttpActionResult Post([FromBody] ObjTournament tournament)
        {
            try
            {
                if (Validation.ValidParamCreateTournament(tournament))
                {
                    if (ActionG.CreateTournament(tournament.team1, tournament.team2, tournament.name, tournament.rounds))
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
