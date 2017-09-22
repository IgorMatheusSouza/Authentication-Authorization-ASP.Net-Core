using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecoveryPW.Models;
using RecoveryPW.Services;
using RecoveryPW.Models.HomeViewModels;
using Microsoft.AspNetCore.Authorization;

namespace RecoveryPW.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailSender _emailSender;

        public HomeController( IEmailSender emailSender)
        {  
            _emailSender = emailSender;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "NormalUser")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SendAnEmail()
        {
            return View();
        }

        public IActionResult Teste()
        {   

            return View();
        }

        [Authorize(Roles = "Admin2")]
        [HttpPost]
        public async Task<IActionResult> SendAnEmail(IgorSendEmail model)
        {
            
             await _emailSender.SendEmailAsync(model.Email, model.Assunto, model.Mensagem);
            return View();
        }

    }

}
