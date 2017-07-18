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
    public class PlayersController : ApiController
    {
        public IHttpActionResult Get(string id)
        {
            DataSet ListPlayers = new DataSet();
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));

            try
            {
                ListPlayers = ActionG.ListPlayers(id);
                foreach (DataRow row in ListPlayers.Tables["table"].Rows)
                {
                    table.Rows.Add(row["name"]);
                }
            }

            catch
            {
                return BadRequest();
            }

            return Ok(table);
        }

        public IHttpActionResult Post([FromBody] ObjPlayer player)
        {
            try
            {
                if (Validation.ValidParamAddPlayer(player))
                {
                    if (ActionG.AddPlayers(player.name, player.team_id))
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
