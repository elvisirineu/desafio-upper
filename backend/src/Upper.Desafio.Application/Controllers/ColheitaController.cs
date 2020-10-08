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
    public class ColheitaController : Controller
    {

        private readonly IColheitaService _service;
        public ColheitaController(IColheitaService service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.UpperDesafio.Colheita)]
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

        [HttpPost(ApiRoutes.UpperDesafio.Colheita)]
        public IActionResult Create([FromBody] ColheitaViewModel colheita)
        {
            try
            {
                var result = _service.Incluir(colheita);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut(ApiRoutes.UpperDesafio.Colheita)]
        public IActionResult Update([FromBody] ColheitaViewModel colheita)
        {
            try
            {
                var result = _service.Alterar(colheita);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(ApiRoutes.UpperDesafio.ColheitaById)]
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

        [HttpGet(ApiRoutes.UpperDesafio.ColheitaById)]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _service.FindByKey(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.UpperDesafio.ColheitaByArvoreId)]
        public IActionResult GetByArvoreId(int arvoreId)
        {
            try
            {
                var result = _service.GetByArvoreId(arvoreId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.UpperDesafio.ColheitaByGrupoId)]
        public IActionResult GetByGrupoId(int grupoId)
        {
            try
            {
                var result = _service.GetByGrupoId(grupoId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.UpperDesafio.ColheitaByPeriodo)]
        public IActionResult GetByPeriodo(string periodo)
        {
            try
            {
                var result = _service.GetByPeriodo(periodo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}