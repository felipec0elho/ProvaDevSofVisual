using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FolhaPagamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private List<Funcionario> funcionarios = new List<Funcionario>();

        // Endpoint POST: api/funcionario/cadastrar
        [HttpPost("cadastrar")]
        public IActionResult CadastrarFuncionario([FromBody] FuncionarioInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoFuncionario = new Funcionario
            {
                Nome = inputModel.Nome,
                CPF = inputModel.CPF
            };

            funcionarios.Add(novoFuncionario);

            return CreatedAtAction(nameof(ListarFuncionarios), new { id = novoFuncionario.CPF }, novoFuncionario);
        }

        // Endpoint GET: api/funcionario/listar
        [HttpGet("listar")]
        public IActionResult ListarFuncionarios()
        {
            return Ok(funcionarios);
        }
    }
}
