using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameTest.Models
{
    public class Validation
    {
        /// <summary>
        /// Checks number of characters in the parameter (post create team )
        /// </summary>
        /// <param name="name_team"></param>
        /// <returns></returns>
        public static bool ValidParamTeamCreate(ObjTeam team)
        {
            bool ok = true;

            if (team.name.Length > 50)
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Checks number of characters in the parameter ( post create player)
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ValidParamAddPlayer(ObjPlayer player)
        {
            bool ok = true;

            if (player.name.Length > 50)
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Checks number of characters in the parameter ( post create Tournament)
        /// </summary>
        /// <param name="Tournament"></param>
        /// <returns></returns>
        public static bool ValidParamCreateTournament(ObjTournament Tournament)
        {
            bool ok = true;

            if (Tournament.name.Length > 50 || Tournament.team1.Length > 50 || Tournament.team2.Length> 50)
            {
                ok = false;
            }

            return ok;
        }

    }
}