using System;
using System.Collections.Generic;
using Autobarn.Data;
using Autobarn.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autobarn.Website.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase {
        // GET: api/<CarsController>
        private readonly ICarDatabase _db;
        public CarsController(ICarDatabase db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Car> Get() {
            return _db.Cars;
        }
        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var car = _db.FindCar(id);
            var content = car;
            if (car == default)
            {
                return  NotFound();
            }

            var json  = new { links = new { self = new { href= $"/api/car/{car.Registration}"} , carModel = new { href = $"/api/carmodel/{car.CarModel.Code}" }}, item = car  };
            return  Ok(json) ;
        }
        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }
        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }
        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}