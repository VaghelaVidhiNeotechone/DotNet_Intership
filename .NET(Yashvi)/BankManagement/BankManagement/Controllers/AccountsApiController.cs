using BankManagement.Models;
using BankManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsApiController : ControllerBase
    {
        private readonly IAccountRepository _repo;

        public AccountsApiController(IAccountRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var accounts = _repo.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var account = _repo.GetById(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Add(account);
            _repo.Save();
            return CreatedAtAction(nameof(GetById), new { id = account.ID }, account);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Account account)
        {
            if (id != account.ID)
                return BadRequest();

            _repo.Update(account);
            _repo.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return NoContent();
        }
    }
}
