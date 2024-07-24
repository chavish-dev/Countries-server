using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCountries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountries _countriesStore;
        public CountriesController(ICountries countriesStore)
        {
            _countriesStore = countriesStore;
        }

        [HttpGet]
        public async Task<IActionResult> getAsiaCountries()
        {
         var res= await _countriesStore.getAsiaCountries();
            if (res == null)
                return BadRequest();
            return Ok(res);
        }
    }
}
