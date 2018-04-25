using MyWebAPI.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyWebAPI.Controllers
{
    public class HomeController : Controller
    {   
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public ViewResult Index(CustomerInput customerInput)
        {
            
            EventLog myNewLog = new EventLog
            {
                Log = customerInput.JournalName
            };

            //Выборка за необходимый период
            var entries = myNewLog.Entries.Cast<EventLogEntry>().Where(x => x.TimeWritten.Date >= customerInput.FirstDate && x.TimeWritten.Date <= customerInput.SecondDate);

            //Подсчет событий каждого типа
            var result = entries
                .GroupBy(x => x.EntryType)
                              .Select(x => new { TypeOfEvent = x.Key, Count = x.Count() });
            foreach (var item in result)
            {
                Response.Write(item);
            }

            if (ModelState.IsValid)
            {
                //Перенаправление пользователя на страницу с результатами
                return View("ResultView", customerInput);
            }

            else
            {
                return View();
            }

        }
    }
}