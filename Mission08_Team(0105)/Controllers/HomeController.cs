using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_Team_0105_.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team_0105_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TaskDBContext _taskDBContext { get; set; }
        public HomeController(ILogger<HomeController> logger, TaskDBContext taskDBContext)
        {
            _logger = logger;
            _taskDBContext = taskDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Tasks = _taskDBContext.Categories.ToList();

            return View();
        }

        //Post on base form
        [HttpPost]

        public IActionResult AddTask(TaskModel task)
        {

            if (ModelState.IsValid)
            {
                _taskDBContext.Add(task);
                _taskDBContext.SaveChanges();
                return View("ViewTasks");
            }
            else
            {
                return View(task);
            }
        }


        //Edit
        [HttpGet]
        public IActionResult Edit(int TaskId)
        {
            ViewBag.Tasks = _taskDBContext.Categories.ToList();


            var task = _taskDBContext.Tasks.Single(task => task.TaskId == TaskId);
            //Send them to base form
            return View("AddTask",task);
        }

        [HttpPost]

        public IActionResult Edit(TaskModel task)
        {

            _taskDBContext.Update(task);
            _taskDBContext.SaveChanges();
            return RedirectToAction("ViewTasks");


        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var task = _taskDBContext.Tasks.Single(task => task.TaskId == TaskId);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskModel task)
        {
            _taskDBContext.Tasks.Remove(task);
            _taskDBContext.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

        public IActionResult ViewTasks()
        {
            var tasks = _taskDBContext.Tasks.Include(x => x.Category)
                .OrderBy(task => task.DueDate)
                .ToList();

            return View(tasks);
        }
    }
}
