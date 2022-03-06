﻿using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Create()
        {
            ManagerAndClubsAndNations x = new ManagerAndClubsAndNations();
            x.Nations = DataService.GetNations();
            x.Clubs = DataService.GetClubs();
            return View(x);
        }
        public RedirectToActionResult Add(string first_name, string last_name,  int nationalityId, int clubId, int age, int rating, bool isReal)
        {
            DataService.AddManager(first_name, last_name, age , nationalityId, clubId, rating, isReal);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Index()
        {
            List<Club> clubs = DataService.GetClubs();
            List<Nation> nations = DataService.GetNations();
            List<Manager> managers = new List<Manager>(DataService.GetManagers());
            managers.ForEach(x =>
            {
                x.Club = clubs.FirstOrDefault(y => y.Id == x.ClubId);
                x.Nation = nations.FirstOrDefault(y => y.Id == x.NationalityId);
            });

            return View(managers);
        }
        public IActionResult Details(int id)
        {
            List<Club> clubs = DataService.GetClubs();
            List<Nation> nations = DataService.GetNations();
            Manager manager = DataService.GetManagers().FirstOrDefault(x => x.Id == id);
            manager.Club = clubs.FirstOrDefault(y => y.Id == manager.ClubId);
            manager.Nation = nations.FirstOrDefault(y => y.Id == manager.NationalityId);

            return View(manager);
        }

        public IActionResult Delete(int id)
        {
            Manager manager = DataService.GetManagers().FirstOrDefault(y => y.Id == id);
            return View(manager);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (password == "password")
            {
                DataService.DeleteManager(id);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Edit(int id)
        {
            ManagerAndClubsAndNations x = new ManagerAndClubsAndNations();

            x.manager = DataService.GetManagers().FirstOrDefault(y => y.Id == id);
            x.Clubs = DataService.GetClubs();
            x.Nations = DataService.GetNations();

            return View(x);
        }

        public RedirectToActionResult ConfirmEdit(int id, string first_name, string last_name, int nationalityId, int clubId, int age, int rating, bool isReal,string password)
        {
            if (password == "password") {
                DataService.EditManager(id, first_name, last_name, nationalityId, clubId, age, rating, isReal);
            }
            return RedirectToAction(actionName: "Index");
        }
    }
}
