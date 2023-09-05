using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;

namespace API.Controllers
{
    public class CountryController : BaseAPIController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public CountryController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
        {
            var country = await unitofwork.Countries.GetAllAsync();
            return mapper.Map<List<CountryDto>>(country);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> Get(int id)
        {
            var country = await unitofwork.Countries.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return mapper.Map<CountryDto>(country);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Country>> Post(CountryDto countryDto)
        {
            var country = mapper.Map<Country>(countryDto);
            unitofwork.Countries.Add(country);
            await unitofwork.SaveAsync();
            if (country == null)
            {
                return BadRequest();
            }
            countryDto.Id = country.Id;
            return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return NotFound();
            }
            var country = mapper.Map<Country>(countryDto);
            unitofwork.Countries.Update(country);
            await unitofwork.SaveAsync();
            return countryDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await unitofwork.Countries.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            unitofwork.Countries.Remove(country);
            await unitofwork.SaveAsync();
            return NoContent();
        }

    }
}