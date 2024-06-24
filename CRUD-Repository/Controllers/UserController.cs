using CRUD_Repository.Models;
using CRUD_Repository.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Repository.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository user)
        {
            userRepository = user;
        }

        public async Task<IActionResult> Index()
        {
            var data = await userRepository.GetAllUsers();
            return View(data);
        }



        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await userRepository.AddUser(user);

            if (user.UserId == 0)
            {
                TempData["mess"] = "Record Not Saved";
            }
            else
            {
                TempData["mess"] = "Record Saved.. User Id : " + user.UserId;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            User usr = new User();
            if ((id == 0) || (id == null))
            {
                return BadRequest();
            }
            usr = await userRepository.GetUserById(id);
            if (usr == null)
            {
                return NotFound();
            }
            return View(usr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            bool status = await userRepository.UpdateUser(user);

            if (status == false)
            {
                TempData["mess"] = "Record Not Updated";
            }
            else
            {
                TempData["mess"] = "Record Updated.. User Id : " + user.UserId;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            bool status = await userRepository.DeleteUser(id);
            if (status == false)
            {
                TempData["mess"] = "Record Not Deleted";
            }
            else
            {
                TempData["mess"] = "Record Delete.. User Id : " + id;
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Detail(int id)
        {
            User usr = new User();

            if (id == 0)
                return BadRequest();

            usr = await userRepository.GetUserById(id);

            if (usr == null)
                return NotFound();

            return View(usr);

        }


    }
}
