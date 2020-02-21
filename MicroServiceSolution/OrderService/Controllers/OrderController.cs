using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetOrders")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAllOrders());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddOrder")]
        public IActionResult POST(Orders order)
        {
            try
            {
                _repo.AddOrders(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public IActionResult PUT(Orders order)
        {
            try
            {
                _repo.UpdateOrders(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _repo.DeleteOrders
                    (id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}