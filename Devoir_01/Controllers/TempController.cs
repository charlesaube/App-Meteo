using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devoir_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Devoir_01.Controllers
{
    public class TempController : Controller
    {

        List<Temperature> temperatures;
        DateTime today;

        public TempController()
        {
            this.today = DateTime.Now;
            this.temperatures = Temperature.Init();
        }

        public IActionResult Index()
        {
            Temperature todayTemp = temperatures.Where(t => t.Date.Year == this.today.Year 
            && t.Date.Month == this.today.Month && t.Date.Day == this.today.Day).Single();

            return View(todayTemp);
        }

        public IActionResult Previsions(int n)
        {
            List<Temperature> selected = temperatures.Where(t => t.Date.DayOfYear > this.today.DayOfYear && t.Date.DayOfYear <= this.today.DayOfYear + n).ToList();
            return View(selected);
        }

        public IActionResult Stats(int mois)
        {
            if (mois < 1)
                mois = today.Date.Month;

            List<Temperature> tempFromMonth = temperatures.Where(t => t.Date.Month == mois).ToList();
            string maxTempFromMonth = tempFromMonth.Max(t => t.MaxTemp).ToString();
            string minTempFromMonth = tempFromMonth.Min(t => t.MinTemp).ToString();
            string averageTempFromMonth =Convert.ToInt32(tempFromMonth.Average(t => t.Temp)).ToString();
            
            ViewBag.maxTemp = maxTempFromMonth;
            ViewBag.minTemp = minTempFromMonth;
            ViewBag.averageTemp = averageTempFromMonth;
            ViewBag.months = new List<SelectListItem> {
                        new SelectListItem { Value = "1", Text = "Janvier" },
                        new SelectListItem { Value = "2", Text = "Février" },
                        new SelectListItem { Value = "3", Text = "Mars" },
                        new SelectListItem { Value = "4", Text = "Avril" },
                        new SelectListItem { Value = "5", Text = "Mai" },
                        new SelectListItem { Value = "6", Text = "Juin" },
                        new SelectListItem { Value = "7", Text = "Juillet" },
                        new SelectListItem { Value = "8", Text = "Août" },
                        new SelectListItem { Value = "9", Text = "Septembre" },
                        new SelectListItem { Value = "10", Text = "Octobre" },
                        new SelectListItem { Value = "11", Text = "Novembre" },
                        new SelectListItem { Value = "12", Text = "Décembre" },
            };
            return View(tempFromMonth);
        }
    }
}
