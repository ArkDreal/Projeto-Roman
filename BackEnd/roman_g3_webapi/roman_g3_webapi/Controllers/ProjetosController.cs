using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using roman_g3_webapi.Domains;
using roman_g3_webapi.Interface;
using roman_g3_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman_g3_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IProjetosRepository _projetoRepository { get; set; }

        public ProjetosController()
        {
            _projetoRepository = new ProjetosRepository();
        }

        [Authorize(Roles = "2, 1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
   
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_projetoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Projeto novoEvento)
        {
            try
            {
                _projetoRepository.Cadastrar(novoEvento);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
