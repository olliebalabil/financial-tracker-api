using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerApi.Models;

namespace TrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TrackerContext _context;

        public AccountController(TrackerContext context)
        {
            _context = context;
        }

        //Get Account By Id
        [HttpGet("byId")]
        public JsonResult GetById(int id)
        {
            var result = _context.Account.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }
        //Get All
        [HttpGet("All")]
        public JsonResult GetAll()
        {
            var result = _context.Account.ToList();
            return new JsonResult(Ok(result));
        }

        //Create
        [HttpPost]
        public JsonResult Create(Account accountData)
        {

            _context.Account.Add(accountData);


            _context.SaveChanges();

            return new JsonResult(Ok(accountData));
        }


        //Edit name
        [HttpPatch("Account_Name")]
        public JsonResult EditAccountName(int Id, string newAccountName)
        {
            var accountInDb = _context.Account.Find(Id);
            if (accountInDb == null)
            {
                return new JsonResult(NotFound());
            }
            accountInDb.Account_Name = newAccountName;

            _context.SaveChanges();

            return new JsonResult(Ok(accountInDb));
        }
        //Delete Account
        [HttpDelete]
        public JsonResult DeleteAccount(int Id)
        {
            var result = _context.Account.Find(Id);
            if (result == null)
                return new JsonResult(NotFound());

            _context.Account.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());

        }
        //Update Current_Balance
        [HttpPatch]
        public JsonResult UpdateCurrentBalance(int Id)
        {
            var accountInDb = _context.Account.Find(Id);
            if (accountInDb == null)
            {
                return new JsonResult(NotFound());
            }

            
            accountInDb.Current_balance = accountInDb.Initial_balance +
    _context.Transactions.Where(t => t.account_id == Id).Sum(t => t.Amount);

            _context.SaveChanges();
            return new JsonResult(Ok(accountInDb));

        }


    }
}
