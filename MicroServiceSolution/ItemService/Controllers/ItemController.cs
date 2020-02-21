using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItemService.Models;
using ItemService.Repositories;

namespace ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IITemRepository _repo;
        public ItemController(IITemRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetItems")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch(Exception ex)
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
        [Route("AddItem")]
        public IActionResult POST(Items item)
        {
            try
            {
                _repo.AddItems(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateItem")]
        public IActionResult PUT(Items item)
        {
            try
            {
                _repo.UpdateItem(item);
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
                _repo.DeleteItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}