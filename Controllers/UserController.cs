
using accolite_bank_application.Entities;
using accolite_bank_application.Models;
using accolite_bank_application.Models.RequestModels;
using accolite_bank_application.Services;
using Microsoft.AspNetCore.Mvc;

namespace accolite_bank_application.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        /*
        * CreateUser method is used to create new user with username given as Request Parameter
        * This method will return newly created User[s userid.
        */
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateUser(UserRequestModel userModel)
        {
            
            if (userModel == null)
            {
                return BadRequest();
            }

            String userName = userModel.userName;
            if (userName == null)
            {
                return BadRequest();
            }

            var response = await _userServices.CreateUser(userName);

            if(response != null)
            {
                response.message = "New User created with UserId : " + response.userID;
            }

            return Ok(response);
            
        }

        /*
        * getUser is mapping method executed when user/{userID} URL is being called
        * This will fetch user details corresponding to given userID
        * This method will return User details along with HttpStatus
        * In case given user Id is invalid, it will show message in User Object in json
        */
        [HttpGet]
        [Route("{userID}")]
        public async Task<IActionResult> GetUser(int userID)
        {

            if (string.IsNullOrEmpty(userID.ToString()))
            {

                return BadRequest();
            }

            var response = await _userServices.GetUser(userID);

            if(response != null)
            {
                response.message = "User Information Fetched Successfully";
            }
            else
            {
                UserModel userModel = new UserModel();
                userModel.message = "User Not Found";
                response = userModel;
            }

            return Ok(response);
        }

       
    }




}
