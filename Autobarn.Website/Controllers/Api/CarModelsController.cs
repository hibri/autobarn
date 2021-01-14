using System;
using System.Collections.Generic;
using System.Linq;
using Autobarn.Data;
using Autobarn.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autobarn.Website.Controllers.Api {
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase {
        private readonly ICarDatabase db;
        public CarModelController(ICarDatabase db) {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<CarModel> Get() {
            return db.Models;
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id) {
            var carModel = db.Models.SingleOrDefault(m => m.Code.Equals(id, StringComparison.InvariantCultureIgnoreCase));
            if (carModel == default) return NotFound("Sorry, no such car model!");
            return Ok(carModel);
        }
    }
}