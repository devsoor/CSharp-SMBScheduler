using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
namespace massage.Models
{
    public static class Convert
    {
        public static Dictionary<string, Dictionary<string, bool>> ScheduleFromQuery(List<PSchedule> PSs) // this function takes a PSchedule query from the database and converts it to an easily readable/parseable dictionary of dictionaries for the front end to work with
        {
            Dictionary<string, Dictionary<string, bool>> formattedSchedule = new Dictionary<string, Dictionary<string, bool>>();
            foreach (PSchedule ps in PSs)
            {
                Dictionary<string, bool> thisPDict = new Dictionary<string, bool>();
                for (int h=6; h<=18; h++)
                {
                    string firstHourDec = "";
                    string secondHourDec = "";
                    int firstT = 0;
                    int secondT = 0;
                    if (h <= 11)
                    {
                        firstHourDec = "am";
                        secondHourDec = "am";
                        firstT = h;
                        secondT = h+1;
                    }
                    if (h == 11)
                    {
                        secondHourDec = "pm";
                    }
                    if (h >= 12)
                    {
                        firstHourDec = "pm";
                        secondHourDec = "pm";
                        firstT = h-12;
                        secondT = h-11;
                    }
                    if (h == 12)
                    {
                        firstT = h;
                    }
                    int t = h;
                    if (t > 12)
                    {
                        t -= 12;
                    }
                    bool thisVal = (bool)ps.GetType().GetProperty("t" + h).GetValue(ps);
                    thisPDict.Add($"{firstT}{firstHourDec} - {secondT}{secondHourDec}", thisVal);
                }
                formattedSchedule.Add(ps.DayOfWeek, thisPDict);
            }
            return formattedSchedule;
        }
    }
}