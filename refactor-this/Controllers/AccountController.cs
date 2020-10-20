using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        Account accounts = new Account();

        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                return Ok(accounts.Get(id));
            }
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
                return Ok(accounts.Get());
        }

        

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            account.Save();
            return Ok();
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            var existing = account.Get(id);
            existing.Name = account.Name;
            existing.Save();
            return Ok();
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var existing = accounts.Get(id);
            existing.Delete();
            return Ok();
        }
    }
}