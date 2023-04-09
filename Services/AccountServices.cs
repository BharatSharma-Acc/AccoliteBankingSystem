using AutoMapper;
using accolite_bank_application.Models;
using accolite_bank_application.Entities;
using accolite_bank_application.Repositories;
using System.Security.Principal;
using accolite_bank_application.Constants;

/*
 * This class contains all business logic related with Account object
 */
namespace accolite_bank_application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountServices(IAccountRepository accountRepository, IMapper mapper, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            this._mapper = mapper;
            _userRepository = userRepository;
        }

        //Method is used to create new Account to be linked with UserID
        //First it will make check whether UserId is valid or not then it will insert new Account entry in Account Set in DB
        public async Task<AccountModel> CreateAccount(int userID)
        {
            var user = await _userRepository.GetUser(userID);

            AccountModel accountModel = new AccountModel();
            
            accountModel.userId = userID;

            if (user == null)
            {
                ErrorModel error = new ErrorModel(ErrorConstants.USER_NOT_FOUND_INPUTCODE,ErrorConstants.INVALID_INPUTMESSAGE, ErrorConstants.USER_NOT_FOUND_INPUTDESCRIPTION);
                accountModel.Error = error;
                return accountModel;

            }
            //accountModel.message = SuccsessConstants.ACCOUNT_CREATED_MESSAGE;
            var entity = _mapper.Map<Account>(accountModel);
            var accountEntity = await _accountRepository.CreateAccount(entity);
            

            var result = _mapper.Map<AccountModel>(accountEntity);
            result.message = SuccsessConstants.ACCOUNT_CREATED_MESSAGE; ;

            return result;
        }

        public Task<bool> DeleteAccount(int accountId)
        {
            return _accountRepository.DeleteAccount(accountId);
        }

        //Method is used to fetch account details using account ID from Local DB(In Memory)
        public async Task<AccountModel> GetAccount(int accountId)
        {
            var account = await _accountRepository.GetAccount(accountId);
            if (account == null)
            {
                return null;
            }
            var result = _mapper.Map<AccountModel>(account);
            return result;
            
        }

        //Method is used to fetch all accounts associated with User ID from Local DB(In Memory)
        public async Task<IEnumerable<AccountModel>> GetAccounts(int userID)
        {

            var accounts = await _accountRepository.GetAccounts(userID);
            return _mapper.Map<IEnumerable<AccountModel>>(accounts);

        }

        /*
	    * This method contains business logic required for Withdrawal or Deposit Transction
	    * Basic business rules covered 1) Withdrawal amount cant be greater than $10000
	    * 						        2) Withdrawal amount should not make current balance below $100
	    *                              3) User cant withdraw more than 90% of current balance in single transaction. 
	    * This method will return Transaction object which contains : Pre , Post balance, account Id, transaction Type, Message 
	    */
        public async Task<TransactionModel> UpdateAccount(int accountId, decimal amount, string transType)
        {
            TransactionModel transModel = new TransactionModel();
            var account = await _accountRepository.GetAccount(accountId);

            if(account != null)
            {
                var currBalance = account.balance;
                transModel.preBalance = currBalance;
                transModel.postBalance = currBalance;
                transModel.transType = transType;
                transModel.accountId = accountId;
                transModel.transAmount = amount;
                transModel.transDate = DateTime.Now;

                if ((UtilsConstants.TRANSTYPE_WITHDRAW.Equals(transType, StringComparison.CurrentCultureIgnoreCase)))
                {
                    if(amount > Convert.ToDecimal(UtilsConstants.MAX_WITHDRAW_LIMIT))
                    {
                        ErrorModel error = new ErrorModel(ErrorConstants.TRANS_MAXLIMIT_BREACH, ErrorConstants.INVALID_TRANS_INPUTMESSAGE, ErrorConstants.TRANS_MAXLIMIT_BREACH_MESSAGE);
                        transModel.Error = error;
                        return transModel;
                    }

                    if((account.balance - amount) < Convert.ToDecimal(UtilsConstants.MIN_BALANCE))
                    {
                        ErrorModel error = new ErrorModel(ErrorConstants.TRANS_MINBAL_BREACH, ErrorConstants.INVALID_TRANS_INPUTMESSAGE, ErrorConstants.TRANS_MINBAL_BREACH_MESSAGE);
                        transModel.Error = error;
                        return transModel;
                    }

                    if (((account.balance * 90 / 100))< amount){
                        ErrorModel error = new ErrorModel(ErrorConstants.TRANS_BALPER_BREACH, ErrorConstants.INVALID_TRANS_INPUTMESSAGE, ErrorConstants.TRANS_BALPER_BREACH_MESSAGE);
                        transModel.Error = error;
                        return transModel;
                    }
                    var postBalance = currBalance - amount;
                    account.balance = postBalance;

                    var updatedAccount = await _accountRepository.UpdateAccount(account);
                    transModel.transDate = updatedAccount.LastUpdatedDate;
                    transModel.postBalance = updatedAccount.balance;
                    transModel.message = SuccsessConstants.WITHDRAWL_MESSAGE + amount;
                }
                else{
                    var postBalance = currBalance + amount;
                    account.balance = postBalance;

                    var updatedAccount = await _accountRepository.UpdateAccount(account);
                    transModel.transDate = updatedAccount.LastUpdatedDate;
                    transModel.postBalance = updatedAccount.balance;
                    transModel.message = SuccsessConstants.DEPOSIT_MESSAGE + amount;
                }
            }
            else
            {
                transModel.transDate = DateTime.Now;
                transModel.message = ErrorConstants.INVALID_ACCOUNT;                
            }
            return transModel;
        }

    }
}