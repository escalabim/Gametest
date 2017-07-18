using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameTest.Model;

namespace GameTest.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            string content = LoadListTeam();
            ViewBag.SelectTeamHtml = content;
            ViewBag.SelectTeam1Html = content;
            ViewBag.SelectTeam2Html = content;
            ViewBag.SelectTeamPlayersHtml = content;
            LoadListTournament();
        }

        // ========================================================
        // Actions
        //=========================================================

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListPlayers()
        {


            return View();
        }

        public ActionResult Team()
        {
            LoadListTeamComplete();
            return View();
        }

        // ========================================================
        // Loads a list of teams
        //=========================================================

        private string LoadListTeam()
        {
            DataSet ListTeam = new DataSet();
            ListTeam = ActionG.ListTeam();
            string ElementRow = string.Empty;

            foreach (DataRow row in ListTeam.Tables["table"].Rows)
            {
                ElementRow += string.Format("<option value=\"{0}\" >{1}</option>", row["team_id"], row["name"]);
            }
            return ElementRow;

        }

        // ========================================================
        // Loads a list of teams complete page
        //=========================================================

        private void LoadListTeamComplete()
        {
            DataSet ListTeam = new DataSet();
            ListTeam = ActionG.ListTeam();
            string ElementRow = string.Empty;

            foreach (DataRow row in ListTeam.Tables["table"].Rows)
            {
                //ElementRow += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", row["name"], 0, 0, 0);
                ElementRow += string.Format("<tr><td>{0}</td>", row["name"]);
                ViewBag.ListTeamHtml = ElementRow;
            }
        }

        // ========================================================
        // Loads a list complete of tournament
        //=========================================================

        private void LoadListTournament()
        {
            DataSet ListTournament = new DataSet();
            ListTournament = ActionG.ListTournament();
            string ElementRow = string.Empty;

            foreach (DataRow row in ListTournament.Tables["table"].Rows)
            {
                ElementRow += string.Format("<option value=\"{0}\" >{1}</option>", row["tournament_id"], row["name"]);
                ViewBag.ListTournamentHtml = ElementRow;
            }
        }

    }
}