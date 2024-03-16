using Itmo.ObjectOrientedProgramming.Lab5.Contracts.BankAccount.OperationResult;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users.LoginResult;
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Success = Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users.LoginResult.Success;

namespace Presentation.Controllers;

public class HomeController : Controller
{
    private IUserService _userService;

    public HomeController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult Login(int id, string password)
    {
        LoginResult result = _userService.Login(id, password);

        if (result is NotFound)
        {
            return View("User Not Found");
        }

        if (result is not Success)
        {
            return View("WrongPassword");
        }

        if (_userService.UserManager.User != null && _userService.UserManager.User.Role is UserRole.Admin)
        {
            return View("Admin");
        }

        return View("Accounts", _userService.UserManager.BankAccounts);
    }

    [HttpPost]
    public IActionResult Accounts(int money, string action, int accountId)
    {
        if (action == "Withdraw")
        {
            OperationResult result = _userService.WithdrawMoney(accountId, money);
            if (result is Failure)
            {
                return View("Fail", result.Message);
            }
        }

        if (action == "Deposit")
        {
            OperationResult result = _userService.DepositMoney(accountId, money);
            if (result is Failure)
            {
                View("Fail", result.Message);
            }
        }

        if (action == "History")
        {
            IEnumerable<BankTransaction> result = _userService.GetHistory(accountId);
            return View("History", result);
        }

        return View("Accounts", _userService.GetUserAccounts().OrderBy(x => x.Id));
    }

    public ViewResult History()
    {
        return View("Accounts", _userService.GetUserAccounts().OrderBy(x => x.Id));
    }

    public ViewResult Admin(int userId)
    {
        OperationResult result = _userService.CreateAccount(userId);

        return result is Failure ? View("User Not Found") : View();
    }
}