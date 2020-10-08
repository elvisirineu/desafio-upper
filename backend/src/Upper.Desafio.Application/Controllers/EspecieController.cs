using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Upper.Desafio.Application.Contracts.V1;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Domain.Contracts;

namespace Upper.Desafio.Application.Controllers
{
    [AllowAnonymous]
    public class EspecieController : Controller
    {

        private readonly IEspecieService _service;
        public EspecieController(IEspecieService service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.UpperDesafio.Especie)]
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

        [HttpPost(ApiRoutes.UpperDesafio.Especie)]
        public IActionResult Create([FromBody] EspecieViewModel especie)
        {
            try
            {
                var result = _service.Incluir(especie);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut(ApiRoutes.UpperDesafio.Especie)]
        public IActionResult Update([FromBody] EspecieViewModel especie)
        {
            try
            {
                var result = _service.Alterar(especie);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(ApiRoutes.UpperDesafio.EspecieById)]
        public IActionResult ExcluirEspecie(int id)
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