using System;
using PasswordCheckerWeb.Helpers;

namespace PasswordCheckerWeb.Models;

public class Checker
{
    public int ScoreCalc(string pass)
    {
        int score = 0;

        if (Utils.PassLength(pass))
        {
            score++;
        }

        if (Utils.LowerCase(pass))
        {
            score++;
        }

        if (Utils.UpperCase(pass))
        {
            score++;
        }
        if (Utils.Digits(pass))
        {
            score++;
        }
        if (Utils.Special(pass))
        {
            score++;
        }
        if (Utils.IsSeq(pass))
        {
            score--;
        }
        return score;
    }
}