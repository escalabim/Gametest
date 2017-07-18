using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTest.Data;
using System.Data.SqlClient;
using System.Data;

namespace GameTest.Model
{
    public class ActionG
    {
        /// <summary>
        /// Create a team in the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CreateTeam(string name)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "API_CreateTeam";
            com.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            return WriteBD.RunBd(com);
        }

        /// <summary>
        /// Add players in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public static bool AddPlayers(string name, string team_id)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "API_AddPlayersTeam";
            com.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            com.Parameters.Add("@team_id", SqlDbType.Int).Value = team_id;
            return WriteBD.RunBd(com);
        }

        /// <summary>
        /// Search the list of players
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public static DataSet ListPlayers(string team_id)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "API_GetListPlayers";
            com.Parameters.Add("@team_id", SqlDbType.Int).Value = team_id;
            return DataSetBD.GetDataSearch(com);
        }

        /// <summary>
        /// Search a simple list of teams
        /// </summary>
        /// <returns></returns>
        public static DataSet ListTeam()
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "API_GetListTeam";
            return DataSetBD.GetDataSearch(com);
        }

        /// <summary>
        /// Create a tournament in the database
        /// </summary>
        /// <param name="team1"></param>
        /// <param name="team2"></param>
        /// <param name="name"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        public static bool CreateTournament(string team1, string team2, string name, string rounds)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "API_CreateTournament";
            com.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            com.Parameters.Add("@team1", SqlDbType.NVarChar).Value = team1;
            com.Parameters.Add("@team2", SqlDbType.NVarChar).Value = team2;
            com.Parameters.Add("@rounds", SqlDbType.Int).Value = rounds;
            return WriteBD.RunBd(com);
        }
        /// <summary>
        /// Check tournament data
        /// </summary>
        /// <param name="tournament_id"></param>
        /// <returns></returns>
        public static DataSet CheckTournament(string tournament_id)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "CheckTournament";
            com.Parameters.Add("@tournament_id", SqlDbType.Int).Value = tournament_id;
            return DataSetBD.GetDataSearch(com);
        }


        /// <summary>
        /// Search a simple list of tournament
        /// </summary>
        /// <returns></returns>
        public static DataSet ListTournament()
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "API_GetListTournament";
            return DataSetBD.GetDataSearch(com);
        }

        /// <summary>
        /// Search a name of team
        /// </summary>
        /// <returns></returns>
        public static string GetNameTeam(int team_id)
        {
            object ob;
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "GetNameTeam";
            com.Parameters.Add("@team_id", SqlDbType.Int).Value = team_id;
            return Convert.ToString(ob = WriteBD.SelectValue(com));
        }

        /// <summary>
        /// insert game results  in the database
        /// </summary>
        /// <param name="tournament_id"></param>
        /// <param name="team1_id_versus"></param>
        /// <param name="team2_id_versus"></param>
        /// <param name="team1_points"></param>
        /// <param name="team2_points"></param>
        /// <param name="winner_team"></param>
        /// <returns></returns>
        public static bool InsertResults(int tournament_id, int team1_id_versus, int team2_id_versus, int team1_points, int team2_points, int winner_team)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "InsertResults";
            com.Parameters.Add("@tournament_id", SqlDbType.Int).Value = tournament_id;
            com.Parameters.Add("@team1_id_versus", SqlDbType.Int).Value = team1_id_versus;
            com.Parameters.Add("@team2_id_versus", SqlDbType.Int).Value = team2_id_versus;
            com.Parameters.Add("@team2_points", SqlDbType.Int).Value = team2_points;
            com.Parameters.Add("@team1_points", SqlDbType.Int).Value = team1_points;
            com.Parameters.Add("@winner_team", SqlDbType.Int).Value = winner_team;
            return WriteBD.RunBd(com);
        }
    }
}
