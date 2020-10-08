using System;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Upper.Desafio.Application.Contracts.V1;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Domain.Contracts;
namespace Upper.Desafio.Application.Controllers
{
    [AllowAnonymous]
    public class GrupoController : Controller
    {

        private readonly IGrupoService _service;
        public GrupoController(IGrupoService service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.UpperDesafio.Grupo)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.UpperDesafio.Grupo)]
        public IActionResult Create([FromBody] GrupoViewModel grupo)
        {
            try
            {
                var result = _service.Incluir(grupo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut(ApiRoutes.UpperDesafio.Grupo)]
        public IActionResult Update([FromBody] GrupoViewModel grupo)
        {
            try
            {
                var result = _service.Alterar(grupo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(ApiRoutes.UpperDesafio.GrupoById)]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Excluir(id);
                return Ok(null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}