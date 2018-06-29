using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatBot.Models;
using DALforChatBot.Repositories;
using ModelEntities.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Web;

namespace ChatBot.Controllers
{
    public class HomeController : Controller
    {
        //public static List<Jsons> listJsons = new List<Jsons>();
        public static ListJ listJ = new ListJ();
        ChatBotUnitOfWork _unit;

        public HomeController(ChatBotUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult RefUsers()
        {
            return PartialView("Users", listJ);
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxTest(Jsons jo)
        {
            if (jo.GetProv())
            {
                listJ.listJ.Add(jo);
            }
            else
            {
                jo.GoToBD(_unit);
            }
            return Json(listJ.listJ);
        }

        [HttpPost]
        public JsonResult GetAnswer(Jsons jo)
        {
            //отправка в БД и МЛ
            foreach(Jsons j in listJ.listJ)
            {
                if(j.Number == jo.Number)
                {
                    listJ.listJ.Remove(j);
                    break;
                }
            }
            jo.GoToBD(_unit);
            return Json(jo);
        }
        
        public IActionResult Index()
        {
            return View(listJ); 
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
