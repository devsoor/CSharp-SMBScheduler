using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
namespace massage.Models
{
    public static class QConvert
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
        public static List<PSchedule> ScheduleToQuery(Dictionary<string, Dictionary<string, bool>> frontEndPS, int practID)
        {
            List<PSchedule> queryReadyList = new List<PSchedule>();
            foreach (KeyValuePair<string, Dictionary<string, bool>> outerKVP in frontEndPS)
            {
                PSchedule thisPS = new PSchedule();
                thisPS.DayOfWeek = outerKVP.Key;
                thisPS.PractitionerId = practID;
                thisPS.Approved = false;
                foreach (KeyValuePair<string, bool> innerKVP in outerKVP.Value)
                {
                    string unParsedHour = innerKVP.Key.Substring(0,4);
                    string parsedHour = "";
                    int numHour = Int32.Parse(unParsedHour[0].ToString());
                    if (unParsedHour[0] == '1')
                    {
                        parsedHour = unParsedHour.Substring(0,2);
                    }
                    else if (unParsedHour[1] == 'p') // like 3pm, numhour is 3, needs to add 12 so it's 15
                    {
                        parsedHour = (numHour + 12).ToString();
                    }
                    else { // am, like 9am, numhour is 9 so just set it to parsedHour
                        parsedHour = numHour.ToString();
                    }
                    thisPS.GetType().GetProperty("t" + parsedHour).SetValue(thisPS, innerKVP.Value);
                }
                queryReadyList.Add(thisPS);
            }
            return queryReadyList;
        }
    }
}