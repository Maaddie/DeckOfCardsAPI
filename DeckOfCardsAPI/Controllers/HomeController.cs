using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        DeckOfCardsDAL doc = new DeckOfCardsDAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateDeck()
        {
            DeckOfCards d = doc.CreateDeck();
            return View(d);
        }
        
        public IActionResult Results()
        {
            
           return View();
        }

       
        public IActionResult CardsDrawn(string id)
        {
            DrawnCards cards = new DrawnCards();
            cards = doc.DrawCards(id);

            return View(cards);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
