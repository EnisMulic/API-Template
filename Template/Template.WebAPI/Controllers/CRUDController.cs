﻿using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Template.Services;
using Template.WebAPI.Services.Interfaces;

namespace Template.WebAPI.Controllers
{
    public class CRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        public CRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<T>> Insert(TInsert request)
        {
            var response = await _service.Insert(request);
            if(response == null)
            {
                return BadRequest();
            }

            Microsoft.AspNetCore.Http.PathString path = HttpContext.Request.Path;
            return Created(path, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(string id, [FromBody]TUpdate request)
        {
            var response = await _service.Update(id, request);
            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var response = await _service.Delete(id);

            if(response == false)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}