using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRServer.data;
using SignalRServer.data.user;
using SignalRServer.Models;
using SignalRServer.Models.EntityModels;

namespace SignalRServer.api.auth
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDBService _userDBService = null;

        public UserController(IUserDBService userDBService)
        {
            _userDBService = userDBService;
        }

        //POST: api/user/login
        [HttpPost("[action]")]
        public async Task<object> Login([FromBody] User model)
        {
            object result = null;

            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                //Login
                result = await _userDBService.GetUserByEmailAsync(model.Email);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        //POST: api/user/register
        [HttpPost("[action]")]
        public async Task<object> Register([FromBody] User model)
        {
            object result = null; object resdata = null;

            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                resdata = await _userDBService.SaveItemAsync(model);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            result = new
            {
                resdata
            };

            return result;
        }
    }
}