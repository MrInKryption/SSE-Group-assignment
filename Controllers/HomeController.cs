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
    public class HomeController : Controller
    {
        private SQLiteConnection VotingDB;

        public HomeController()
        {
            VotingDB = new SQLiteConnection("Data Source=Voting.sqlite;Version=3;");
            VotingDB.Open();
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CheckLogin(string login, string password)
        {
            string sql = "SELECT P.Description FROM Accounts AS A INNER JOIN Privileges AS P ON P.Id = A.Privilege_Id WHERE A.Login_Key = '" + login + "' AND A.Password_Key = '" + password + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, VotingDB);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Json(reader["Description"].ToString());
            }
            else {
                return Json("Invalid");
            }
        }
    }
}

public class Account
{
    public int Id { get; set; }
    public int Privilege_Id { get; set; }
    public string Login_Key { get; set; }
    public string Password_Key { get; set; }
}
