using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            _unitOfWork = unitOfWork;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<IReadOnlyList<Customer>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(customer);
            await _unitOfWork.Commit();
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await _repository.AddAsync(customer);
            await _unitOfWork.Commit();
            return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var customer = await _repository.GetByIdAsync(id); 
            if (customer == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(customer);
            await _unitOfWork.Commit();
            return customer;
        }
    }
}
