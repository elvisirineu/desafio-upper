using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Upper.Desafio.Application.Contracts.V1;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Service.Domain.Contracts;

namespace Upper.Desafio.Application.Controllers
{
    [AllowAnonymous]
    public class ArvoreController : Controller
    {
        private readonly IArvoreService _service;

        public ArvoreController(IArvoreService service)
        {
            _service = service;
        }
        [HttpGet(ApiRoutes.UpperDesafio.Arvore)]
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

        [HttpPost(ApiRoutes.UpperDesafio.Arvore)]
        public IActionResult Create([FromBody] ArvoreViewModel arvore)
        {
            try
            {
                var result = _service.Incluir(arvore);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut(ApiRoutes.UpperDesafio.Arvore)]
        public IActionResult Update([FromBody] ArvoreViewModel arvore)
        {
            try
            {
                var result = _service.Alterar(arvore);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(ApiRoutes.UpperDesafio.ArvoreById)]
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