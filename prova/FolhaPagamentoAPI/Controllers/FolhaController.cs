using Microsoft.AspNetCore.Mvc;
using System;

namespace FolhaPagamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolhaController : ControllerBase
    {
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal salario = inputModel.Valor * inputModel.Quantidade;

            decimal aliquota = CalcularAliquota(salario);

            var novaFolhaPagamento = new FolhaPagamento
            {
                Valor = inputModel.Valor,
                Quantidade = inputModel.Quantidade,
                Mes = inputModel.Mes,
                Ano = inputModel.Ano,
                FuncionarioId = inputModel.FuncionarioId,
                Salario = salario,
                AliquotaDeduzir = aliquota
            };


            return Ok(novaFolhaPagamento);
        }

        private decimal CalcularAliquota(decimal salario)
        {
            if (salario >= 1903.99M && salario <= 2826.65M)
            {
                return 7.5M;
            }
            else if (salario >= 2826.66M && salario <= 3751.05M)
            {
                return 15.0M;
            }
            else if (salario >= 3751.06M && salario <= 4664.68M)
            {
                return 22.5M;
            }
            else
            {
                return 27.5M;
            }
        }
    }
}
