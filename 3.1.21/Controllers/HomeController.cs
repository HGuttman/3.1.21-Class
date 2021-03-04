using _3._1._21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _3._1._21.Controllers
{
    public class HomeController : Controller
    {
            public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submit(string text)
        {
            var count = GetCount(text);
            var vm = new IndexViewModel { Count = count, Text = text };
            return View(vm);
        }

        private Dictionary<char, int> GetCount(string text)
        {
            Dictionary<char, int> count = new();
            foreach(char c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                count.Add(c, 0);
            }
            foreach (var c in text.ToUpper())
            {
                if (count.ContainsKey(c))
                {
                    count[c]++;
                }
                else
                {
                    count[c] = 1;
                }
            }
            return count;
        }
    }
}
