using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTest.Data;


namespace GameTest.Model
{
    public class StartGame
    {
        public static DataTable StartGameRun(int tournament_id, int team1_id_versus, int team2_id_versus)
        {

            DataTable table = new DataTable();
            table.Columns.Add("WinningTeam", typeof(string));
            table.Columns.Add("team1_points", typeof(string));
            table.Columns.Add("team2_points", typeof(string));
            table.Columns.Add("team1_id_versus", typeof(string));
            table.Columns.Add("team2_id_versus", typeof(string));

            try
            {
                Random RN = new Random();
                int team1, team2, WinningTeam_int;
                string WinningTeam = string.Empty;
                team1 = RN.Next(1, 100);
                team2 = RN.Next(1, 100);

                if (team1 > team2)
                {
                    WinningTeam = ActionG.GetNameTeam(team1_id_versus);
                    WinningTeam_int = team1_id_versus;
                }

                else
                {
                    WinningTeam = ActionG.GetNameTeam(team2_id_versus);
                    WinningTeam_int = team2_id_versus;
                }

                ActionG.InsertResults(tournament_id, team1_id_versus, team2_id_versus, team1, team2, WinningTeam_int);
                table.Rows.Add(WinningTeam, team1, team2, ActionG.GetNameTeam(team1_id_versus), ActionG.GetNameTeam(team2_id_versus));
            }

            catch
            {
                return table;
            }

            return table;


        }

    }
}
