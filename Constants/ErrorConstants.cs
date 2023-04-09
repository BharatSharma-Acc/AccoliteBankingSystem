namespace accolite_bank_application.Constants
{
    public static class ErrorConstants
    {

        public const int USER_NOT_FOUND_INPUTCODE = 4001;
        public const string USER_NOT_FOUND_INPUTDESCRIPTION = "UserID is not valid, Please enter valid userID";
        public const string INVALID_INPUTMESSAGE = "Invalid Input";


        public const int TRANS_MAXLIMIT_BREACH = 4002;
        public const string TRANS_MAXLIMIT_BREACH_MESSAGE = "Invalid Transaction: Withdrawl amount is greater than $"+UtilsConstants.MAX_WITHDRAW_LIMIT;
        public const string INVALID_TRANS_INPUTMESSAGE = "Invalid Transaction";

        public const int TRANS_MINBAL_BREACH = 4003;
        public const string TRANS_MINBAL_BREACH_MESSAGE = "Invalid Transaction : Withdrawl amount will make available balance below mandatory limit of $" + UtilsConstants.MIN_BALANCE;

        public const int TRANS_BALPER_BREACH = 4004;
        public const string TRANS_BALPER_BREACH_MESSAGE = "Invalid Transaction : Withdrawl amount is greater than 90% of current Balance";


        public const string ACCOUNT_NOT_FOUND_MESSAGE = "Account Not Found!!";
        public const string INVALID_ACCOUNT = "Invalid Account";
        public const string NO_ACCOUNT_WITH_USER_MESSAGE = "No Account associated with UserId: ";

        public const string ACCOUNTID_IS_MANDATORY = "AccountId is mandatory field!!";
        public const string AMOUNT_IS_MANDATORY = "Amount is mandatory field";

        public const string INVALID_TRANSTYPE = "Transtype is not valid : Valid types are Withdraw or Deposit";

    }
}
