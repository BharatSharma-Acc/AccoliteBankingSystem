# accolite-bank-application
Creating New C# Project

Accolite Bank Application performs basic banking operations including Create Account, Fetch Account, Withdraw/Deposit Balance etc using  [ASP.net Core ], C#, .Net 6
RESTful web service application with [Docker](https://www.docker.com/)

Installed:   
[git](https://www.digitalocean.com/community/tutorials/how-to-contribute-to-open-source-getting-started-with-git)  
[Visual Studio](https://visualstudio.microsoft.com/downloads/)

#### Steps To setup project

1)  Clone source code from git
```
git clone https://github.com/BharatSharma-Acc/AccoliteBankingSystem .

Note :  Unit Test cases project can be cloned from below path :
        https://github.com/BharatSharma-Acc/accolite-bank-application-Tests.git
        In case Test cases project is not imported than download entire application from google drive link as below :

        https://drive.google.com/drive/folders/1Y8Xbk7QD-oZBFT2B6DsV5YVFPetdz9BM

2) Import project solution in Visual Studio
3) Run using Visual studio.
4) Test application
```
	Hit URL https://localhost:7102/swagger/index.html in any browser (This URL will automatically open when application starts in Visual studio)
```
	response should be:
```
	UI should open with multiple operations like account and user

#### Tech Stack Used

1) Dot net 6.0
2) Asp.net Core
3) Visual Studio 2022
4. XUnit for unit test cases
5. Entity Framework

#### Application business Points to Highlight.
1) Two users with UserIds - 10000, 10001  and two Accounts with Account Ids: 50000, 50001 are created bydefault at application load time.
2) In order to create new bank account, either existing userId can be used or new User can be created using user "POST" method, than Account will be created.
3) All new bank account accounts are created with account Type "Saving" and zero available balance.
4) USerID and accountId will be autogenerated.
5) For newly created account, In case user needs to "Withdraw" money, he needs to first deposit money in the account so that minimum balance is greater than $100.
6) When Account is deleted, it can't be retreived. Also, non-zero balance account can also be deleted.
7) Once application is stopped, all data will be lost.

#### Scope of Technical Improvements
1) Swagger comments can be added
2) Further enhancements in Exception handling mechanism.
3) Authentication and authorization can be implemented.
4) More unit cases can be added for repository layer.
5) Concept of transactions can be introduced. We can separate Withdraw and Deposit transactions.



