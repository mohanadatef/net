﻿using KhadimiEssa.Controllers;
using KhadimiEssa.Data;
using KhadimiEssa.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Areas.Identity.Pages.Account
{
    public class EditUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationDbUser> _signInManager;
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _environment;
        private readonly IUploadImage _uploadImage;
        public EditUserModel(SignInManager<ApplicationDbUser> signInManager, UserManager<ApplicationDbUser> userManager, ILogger<RegisterModel> logger, IWebHostEnvironment environment, ApplicationDbContext context, IUploadImage uploadImage)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _environment = environment;
            _context = context;
            _uploadImage = uploadImage;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Required(ErrorMessage = "من فضلك ادخل البريد الالكترونى")]
            [EmailAddress(ErrorMessage = "يجب ادخال بريد الكترونى صحيح")]
            [Display(Name = "Email")]
            public string Email { get; set; }
            public string Id { get; set; }
            [Display(Name = "Img")]
            public IFormFile Img { get; set; }

            public string PhotoPath { get; set; }

            //[Required(ErrorMessage = "من فضلك ادخل  العنوان")]
            //[Display(Name = "Address")]
            //public string Address { get; set; }

            public string FullName { get; set; }

        }

        public IActionResult OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {



                var userEmail = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == Input.Email && u.Id != Input.Id);
                var foundedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Input.Id);

                if (userEmail != null)
                {
                    ModelState.AddModelError("Email", "البريد الالكتروني مسجل من قبل");
                }

                string uniqueFileName = null;


                if (Input.Img != null)
                {
                    uniqueFileName = _uploadImage.Upload(Input.Img, (int)FileName.Users);
                    //ProcessUploadedFile(_environment, Input.Img, FoldersName.Users.ToString());
                    Input.PhotoPath = uniqueFileName;

                    foundedUser.ImgProfile = uniqueFileName;
                }

                else
                {
                    foundedUser.ImgProfile = foundedUser.ImgProfile;
                }

                foundedUser.Email = Input.Email;
                foundedUser.UserName = Input.Email;


                var result = await _userManager.UpdateAsync(foundedUser);

                await _context.SaveChangesAsync();

                if (result.Succeeded)
                {
                    return LocalRedirect("/Home/Index");


                }




            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}