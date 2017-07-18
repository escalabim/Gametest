using GameTest.Model;
using GameTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameTest.Controllers
{
    public class PlayController : ApiController
    {
        public IHttpActionResult GET(string id)
        {
            DataSet CheckTournamentData = new DataSet();
            CheckTournamentData = ActionG.CheckTournament(id);
            DataTable table = new DataTable();        

            try
            {
                foreach (DataRow row in CheckTournamentData.Tables["table"].Rows)
                {
                    table = StartGame.StartGameRun(Convert.ToInt32(row["tournament_id"]), Convert.ToInt32(row["team1_id_versus"]), Convert.ToInt32(row["team2_id_versus"]));
                }

                return Ok(table);

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
