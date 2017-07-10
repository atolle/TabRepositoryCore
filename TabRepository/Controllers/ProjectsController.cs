﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TabRepository;
using TabRepository.Data;
using TabRepository.Models;
using TabRespository.Models;
using TabRespository.ViewModels;

namespace TabRespository.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;      
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new ProjectFormViewModel();

            return View("ProjectForm", viewModel);
        }

        // POST: Projects
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProjectFormViewModel viewModel)
        {
            if (!ModelState.IsValid)    // If not valid, set the view model to current customer
            {                           // initialize membershiptypes and pass it back to same view
                return View("ProjectForm", viewModel);
            }

            if (viewModel.Id == 0)  // We are creating a new project
            {
                // Saving properties for new Project
                Project project = new Project()
                {
                    UserId = User.GetUserId(),
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };

                _context.Projects.Add(project);
            }

            _context.SaveChanges();

            return RedirectToAction("Main", "Projects");
        }

        // POST: Projects
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxSave(ProjectFormViewModel viewModel)
        {
            if (!ModelState.IsValid)    // If not valid, set the view model to current customer
            {                           // initialize membershiptypes and pass it back to same view
                // Need to return JSON failure to form
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); 
            }

            try
            {
                if (viewModel.Id == 0)  // We are creating a new project
                {
                    // Saving properties for new Project
                    Project project = new Project()
                    {
                        UserId = User.GetUserId(),
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                    };

                    _context.Projects.Add(project);

                    _context.SaveChanges();

                    return RedirectToAction("GetEmptyTabVersionsTable", "TabVersions", new { id = project.Id });
                    //return RedirectToAction("GetEmptyTabVersionsTable", "TabVersions");//, project);
                    //return GetEmptyTabVersionsTable(project);
                    //return PartialView("_EmptyTabVersionsTable");
                }
                else
                {
                    // Handle edit of project
                }

                return RedirectToAction("GetEmptyTabVersionsTable", "TabVersions");
            }
            catch
            {
                // Need to return JSON failure to form
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }    
        }

        public ActionResult Delete(int id)
        {
            string currentUserId = User.GetUserId();

            var projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id && p.UserId == currentUserId);

            // If current user does not have access to project or project does not exist
            if (projectInDb == null)
                return NotFound();

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();

            return RedirectToAction("Main", "Projects");
        }

        // GET: Projects
        public ViewResult Index()
        {
            string currentUserId = User.GetUserId();

            // Return a list of all Projects belonging to the current user
            var projects = _context.Projects.Where(p => p.UserId == currentUserId).ToList();

            return View(projects);
        }

        public ApplicationUser GetCurrentUser()
        {
            string currentUserId = User.GetUserId();

            return _context.Users.FirstOrDefault(u => u.Id == currentUserId);
        }

        public ViewResult Main()
        {
            string currentUserId = User.GetUserId();

            // Return a list of all Projects belonging to the current user
            var projects = _context.Projects
                .Include(p => p.Tabs)
                .Where(p => p.UserId == currentUserId).ToList();

            return View(projects);
        }

        //// Needed for tab playback - should probably move to a different controller
        //public ActionResult DefaultSoundFont()
        //{
        //    string filename = "default.sf2";
        //    string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Content/" + filename;
        //    byte[] filedata = System.IO.File.ReadAllBytes(filepath);
        //    string contentType = MimeMapping.GetMimeMapping(filepath);

        //    var cd = new System.Net.Mime.ContentDisposition
        //    {
        //        FileName = filename,
        //        Inline = true,
        //    };

        //    return File(filedata, contentType);
        //}

        // GET: Project form
        [HttpGet]
        public ActionResult GetProjectFormPartialView()
        {
            var viewModel = new ProjectFormViewModel();

            return PartialView("_ProjectForm", viewModel);
        }

    }
}