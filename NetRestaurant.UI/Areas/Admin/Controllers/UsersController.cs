﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Core.Entities;
using NetRestaurant.Infrastructure.Repositories;
using NetRestaurant.UI.ViewModels;

namespace NetRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAll());
        }

        public async Task<IActionResult> Edit(Int64 id = 0)
        {
            var user = await _userRepository.Get(id);
            var userVM = new UserVM();

            if (user == null)
                return View(userVM);

            userVM = _mapper.Map<User, UserVM>(user);

            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserVM userVM)
        {
            var user = _mapper.Map<UserVM, User>(userVM);

            try
            {
                if (user.Id == 0)
                    await _userRepository.Create(user);
                else
                    await _userRepository.Update(user);

                TempData["Success"] = "The operation occurred successfully";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "The operation has failed";
                return View(userVM);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var isDeleted = await _userRepository.Delete(id);

                if (isDeleted)
                    TempData["Success"] = "The user was deleted successfully";
                else
                    TempData["Error"] = "An error ocorred with the operation";

            }
            catch (Exception ex)
            {
                TempData["Error"] = "The operation has failed";
            }

            return RedirectToAction(nameof(Index));

        }
    }
}