﻿using BulbaCourses.Web.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Web.Controllers
{

    public class ChangePassword
    {
        public string Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordConfirm { get; set; }
    }
    [RoutePrefix("api/admin")]
    //[Authorize(Roles = "Admin")]
    public class UserAdminController : ApiController
    {
        private readonly BulbaUserManager _userManager;

        public UserAdminController(BulbaUserManager userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            //string id = string.Empty;
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                //var result = await _courseService.GetCourseByIdAsync(id);
                return user == null ? NotFound() : (IHttpActionResult)Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            string id = string.Empty;
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var user = await _userManager.Users.ToListAsync();
                //var result = await _courseService.GetCourseByIdAsync(id);
                return user == null ? NotFound() : (IHttpActionResult)Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost, Route("{id}")]
        public async Task<IHttpActionResult> ChangePassword([FromBody]ChangePassword user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!user.NewPassword.Equals(user.NewPasswordConfirm))
                return BadRequest("New password different");
            var result = await _userManager.ChangePasswordAsync(user.Id, user.OldPassword, user.NewPassword);
            if (result.Succeeded)
                return (IHttpActionResult)Ok(result);
            return result.Succeeded ? (IHttpActionResult)Ok(result) : BadRequest();

        }
    }
}
