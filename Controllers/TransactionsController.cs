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
  public class TransactionsController : ControllerBase
  {
    private readonly TrackerContext _context;

    public TransactionsController(TrackerContext context)
    {
      _context = context;
    }

    //Get All
    [HttpGet("AllByAccountId")]
    public JsonResult GetAll(int account_id)
    {
      var result = _context.Transactions.Where(t => t.account_id == account_id).ToList();
      return new JsonResult(Ok(result));
    }

    //Create Transaction
    [HttpPost]
    public JsonResult CreateTransaction(Transaction newTransaction)
    {

      _context.Transactions.Add(newTransaction);


      _context.SaveChanges();

      return new JsonResult(Ok(newTransaction));
    }
    //Edit Transaction
    [HttpPatch]
    public JsonResult EditTransaction(Transaction transactionData)
    {
      var transactionInDb = _context.Transactions.Find(transactionData.Id);
      if (transactionInDb == null)
      {
        return new JsonResult(NotFound());
      }
      transactionInDb.Reference = transactionData.Reference;
      transactionInDb.Amount = transactionData.Amount;
      transactionInDb.Category = transactionData.Category;

      _context.SaveChanges();

      return new JsonResult(Ok(transactionInDb));
    }

    //Delete Transaction
    [HttpDelete]
    public JsonResult DeleteTransaction(int Id)
    {
      var result = _context.Transactions.Find(Id);
      if (result == null)
        return new JsonResult(NotFound());

      _context.Transactions.Remove(result);
      _context.SaveChanges();
      return new JsonResult(NoContent());

    }





  }
}
