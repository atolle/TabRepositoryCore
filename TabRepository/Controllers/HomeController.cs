﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabRepository.Data;
using TabRepository.Services;
using TabRepository.ViewModels;

namespace TabRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        private ApplicationDbContext _context;

        public HomeController(IEmailSender emailSender, ApplicationDbContext context)
        {
            _emailSender = emailSender;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

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

        public IActionResult Error(int code)
        {
            switch (code)
            {
                case 404:
                    ViewData["Header"] = "Page Not Found";
                    ViewData["Body"] = "We couldn't find the page you requested. Please check your URL.";
                    break;
                default:
                    ViewData["Header"] = "Error Occurred";
                    ViewData["Body"] = "An error has occurred. Please try your request again in a few minutes.";
                    break;
            }
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult TermsOfService()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult GetTermsOfService()
        {
            return PartialView("_TermsOfService");
        }

        public IActionResult GetPrivacyPolicy()
        {
            return PartialView("_PrivacyPolicy");
        }

        [HttpGet]
        [Authorize]
        public IActionResult SendBugReport()
        {
            BugReportFormViewModel viewModel = new BugReportFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProcessBugReport(BugReportFormViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserId = User.GetUserId();

                    var userInDb = _context.Users.Where(u => u.Id == currentUserId).FirstOrDefault();

                    if (userInDb == null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }

                    if (viewModel.Image != null)
                    {
                        // Limit file size to 1 MB
                        if (viewModel.Image.Length > 1000000)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Image size limit is 1 MB");
                        }
                    }

                    BugReport bugReport = new BugReport
                    (
                        viewModel.Description,
                        viewModel.Errors,
                        viewModel.Page,
                        viewModel.Browser,
                        viewModel.DeviceType,
                        viewModel.Image,
                        userInDb.UserName,
                        userInDb.Email
                    );

                    if (viewModel.Image == null)
                    {
                        await _emailSender.SendEmailAsync("support@tabcollab.com", "Bug Report", bugReport.ToString());
                    }
                    else
                    {
                        await _emailSender.SendEmailAsyncWithAttachment("support@tabcollab.com", "Bug Report", bugReport.ToString(), viewModel.Image);
                    }

                    return PartialView("_BugReportConfirmation");
                }

                // If we got here there were errors in the modelstate                
                var modelErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)).ToList();

                return Json(new { error = string.Join("<br />", modelErrors) });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

    public class BugReport
    {
        private string _description;
        private string _errors;
        private string _page;
        private string _browser;
        private string _deviceType;
        private IFormFile _image;
        private string _username;
        private string _email;

        public BugReport(string description, string errors, string page, string browser, string deviceType, IFormFile image, string username, string email)
        {
            _description = description;
            _errors = errors;
            _page = page;
            _browser = browser;
            _deviceType = deviceType;
            _image = image;
            _username = username;
            _email = email;
        }

        public override string ToString()
        {
            return $@"
                <p>Bug Report</p>
                <br />
                <p>Username: {_username}</p>
                <p>Email: {_email}</p>
                <br />
                <p>Description: {_description}</p>
                <p>Error: {_errors}</p>
                <p>Page: {_page}</p>
                <p>Browser: {_browser}</p>
                <p>Device Type: {_deviceType}</p>";
        }
    }
}
