using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DemoIBank.Models;

namespace DemoIBank.Controllers
{
    public class BankAccountsController : ApiController
    {
        BankAccount[] bankAccounts = new BankAccount[]
{
            new BankAccount { Id=1, Name = "First Person", Balance=100.40, AccountNumber = 101},
            new BankAccount { Id=2, Name = "Second Person", Balance=600.40 ,AccountNumber=102},
            new BankAccount { Id=3, Name = "Third Person", Balance=8900.40, AccountNumber = 103 }


};

        public IEnumerable<BankAccount> GetAllBankAccounts()
        {

            return bankAccounts;
        }

        public BankAccount GetBankAccountById(int id)
        {

            var bankAccount = bankAccounts.FirstOrDefault((p) => p.Id == id);
            if (bankAccount == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            return bankAccount;
        }

        public IEnumerable<BankAccount> GetBankAccountByName(string name)
        {

            return bankAccounts.Where((p) => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));

        }
        /*
        private BankAccountContext db = new BankAccountContext();

        // GET: api/BankAccounts
        public IQueryable<BankAccount> GetBankAccounts()
        {
            return db.BankAccounts;
        }

        // GET: api/BankAccounts/5
        [ResponseType(typeof(BankAccount))]
        public IHttpActionResult GetBankAccount(int id)
        {
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return Ok(bankAccount);
        }

        // PUT: api/BankAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBankAccount(int id, BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankAccount.Id)
            {
                return BadRequest();
            }

            db.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BankAccounts
        [ResponseType(typeof(BankAccount))]
        public IHttpActionResult PostBankAccount(BankAccount bankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BankAccounts.Add(bankAccount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bankAccount.Id }, bankAccount);
        }

        // DELETE: api/BankAccounts/5
        [ResponseType(typeof(BankAccount))]
        public IHttpActionResult DeleteBankAccount(int id)
        {
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            db.BankAccounts.Remove(bankAccount);
            db.SaveChanges();

            return Ok(bankAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankAccountExists(int id)
        {
            return db.BankAccounts.Count(e => e.Id == id) > 0;
        }*/
    }
}