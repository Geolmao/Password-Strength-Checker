using Microsoft.AspNetCore.Mvc;
using System;
using PasswordCheckerWeb.Helpers;
using PasswordCheckerWeb.Models;

namespace PasswordCheckerWeb.Controllers
{
    public class PassController : Controller
    {   
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Password cannot be empty";
                return View("Index");
            }
            Checker check = new Checker();
            int score = check.ScoreCalc(password);
            string strength = "";
            List<string> tips = new List<string>();
            if (!Utils.PassLength(password))
            {
                tips.Add("- Make password longer(at least 8 characters)");
            }
            if (!Utils.Digits(password))
            {
                tips.Add("- Add at least one digit");
            }
            if (!Utils.Special(password))
            {
                tips.Add("- Add at least one special character");
            }
            if (!Utils.LowerCase(password) || !Utils.UpperCase(password))
            {
                tips.Add("- Use both lowercase and uppercase letters");
            }
            if (Utils.IsCommon(password))
            {
                tips.Add("- You used a common password(easly crackable)");
            }
            if (Utils.IsSeq(password))
            {
                tips.Add("- Avoid using keyboard sequences(ex: qwerty,1234 etc.)");
            }
            if (Utils.IsCommon(password) || score <= 3)
                {
                    strength = "weak";
                }
                else if (score == 4)
                {
                    strength = "medium";
                }
                else if (score == 5)
                {
                    strength = "strong";
                }
            ViewBag.strength = strength;
            ViewBag.score = score;
            ViewBag.tips = tips;
            return View("Index");
        }

    }
}
