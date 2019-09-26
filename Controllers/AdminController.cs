using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using VotingWebApp.Models;

namespace VotingWebApp.Controllers
{
    public class AdminController : Controller
    {
        private SQLiteConnection VotingDB;

        public AdminController()
        {
            VotingDB = new SQLiteConnection("Data Source=Voting.sqlite;Version=3;");
            VotingDB.Open();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
