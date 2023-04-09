using accolite_bank_application.Entities;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;
using accolite_bank_application.Services;
using System.Net;
using accolite_bank_application.Models;
using accolite_bank_application.Models.RequestModels;
using accolite_bank_application.Constants;

namespace accolite_bank_application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            this._accountServices = accountServices;
        }

        /*
        * CreateAccount method is used to create new Account of user with userID given in URL
        * This method will return newly created Account details.
        * In case given userID is invalid, it will show error message
        */
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAccount(AccountRequestModel accountModel)
        {
            if(accountModel == null)
            {
                return BadRequest();
            }

            int userID = accountModel.userId;

            if (string.IsNullOrEmpty(userID.ToString()))
            {
                return BadRequest();
            }

            var response = await _accountServices.CreateAccount(userID);

            return Ok(response);
        }

        /*
        * GetAccounts is Mapping method executed when account/list/{userId} URL is being called
        * This will fetch list of accounts associated with given userID
        */
        /// <summary>
        /// GetAccounts is Mapping method executed when account/list/{userId} URL is being called
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Fetch user</returns>
        [HttpGet]
        [Route("list/{userID}")]
        public async Task<IActionResult> GetAccounts(int userID)
        {

            if (string.IsNullOrEmpty(userID.ToString()))
            {

                return BadRequest();
            }

            var accounts = await _accountServices.GetAccounts(userID);
            if (accounts.Count() !=0)
            {

                return Ok(accounts);
            }
            else
            {
                return Ok(ErrorConstants.NO_ACCOUNT_WITH_USER_MESSAGE + userID);
                
            }


        }


        /*
        * GetAccount is mapping method executed when account/{accountId} URL is being called
        * This will fetch account details corresponding to given accountId
        * This method will return Account object
        * In case given account Id is invalid, it will show error message
        */
        [HttpGet]
        [Route("{accountId}")]
        public async Task<IActionResult> GetAccount(int accountId)
        {

            if (string.IsNullOrEmpty(accountId.ToString()))
            {

                return BadRequest();
            }

            var accounts = await _accountServices.GetAccount(accountId);
            if (accounts != null)
            {

                return Ok(accounts);
            }
            else
            {
                var message = ErrorConstants.ACCOUNT_NOT_FOUND_MESSAGE;
                return Ok(message);
            }
        }

        /*
        * deleteAccount method is used to delete account with accountId given in URL
        * This method will return message showing account deleted or not
        */
        [HttpDelete]
        [Route("{accountId}")]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            if (string.IsNullOrEmpty(accountId.ToString()))
            {
                return BadRequest();
            }
            
            var response = await _accountServices.DeleteAccount(accountId);
            if (response)
            {
                return Ok(SuccsessConstants.ACCOUNT_DELETED_MESSAGE + accountId);
            }
            else
            {
                return Ok(ErrorConstants.ACCOUNT_NOT_FOUND_MESSAGE);
            }
            
        }

        /*
        * updateAccount method is used to perform Withdraw or Deposit in given account
        * This method will return Transaction detail containing pre,post balance, transaction type 
        * In case transaction fails due to business rules, it will show HTTP status as 200 with exact error message in transaction body
        */
        [HttpPatch]
        
        public async Task<IActionResult> UpdateAccount(int accountId, decimal amount, string transType)
        {
            if (string.IsNullOrEmpty(accountId.ToString()))
            {
                return BadRequest(ErrorConstants.ACCOUNTID_IS_MANDATORY);
            }
            if(string.IsNullOrEmpty(amount.ToString()))
            {
                return BadRequest(ErrorConstants.AMOUNT_IS_MANDATORY);
            }
            if (transType.Equals("") || !((UtilsConstants.TRANSTYPE_WITHDRAW.Equals(transType, StringComparison.CurrentCultureIgnoreCase))  || (UtilsConstants.TRANSTYPE_DEPOSIT.Equals(transType, StringComparison.CurrentCultureIgnoreCase))))
            {
                return BadRequest(ErrorConstants.INVALID_TRANSTYPE);
            }

            var response = await _accountServices.UpdateAccount(accountId, amount, transType);
            
            return Ok(response);
        }
    }
}