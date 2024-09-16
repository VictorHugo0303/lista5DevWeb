using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Validation;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private static List<Aluno> dadosAluno = new List<Aluno>();

        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir(Aluno dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dadosAluno.Add(new Aluno
            {
                Cpf = dados.Cpf,
                Email = dados.Email,
                Nome = dados.Nome,
                RA = dados.RA
            });

            return Ok($"Aluno(a) {dados.Nome} inserido com sucesso.");
        }
        [HttpPut]
        [Route("AtualizarPessoa")]

        public IActionResult atualizar(string cpf, Aluno dados)
        {
            var pessoaPesquisado = dadosAluno.Where(a => a.Cpf == cpf).FirstOrDefault();


            if (pessoaPesquisado is null)
                return NotFound($"Aluno com cpf {cpf} não encontrado.");

            pessoaPesquisado.Cpf = dados.Cpf;
            pessoaPesquisado.Email = dados.Email;
            pessoaPesquisado.Nome = dados.Nome;
            pessoaPesquisado.RA = dados.RA;

            return NoContent();
        }

        [HttpGet]
        [Route("BuscarPessoa")]

        public IActionResult Buscar()
        {
            return Ok(dadosAluno);
        }

        [HttpGet]
        [Route("EspecificaPessoa")]

        public IActionResult BuscarEspecifica(string Cpf)
        {
            var PessoaPesquisando = dadosAluno.Where(a => a.Cpf == Cpf).FirstOrDefault();

            if (PessoaPesquisando is null)
                return NotFound($"Aluno com cpf {Cpf} não encontrado.");

            return Ok(PessoaPesquisando);
        }

        [HttpDelete]
        [Route("DeletePessoa")]

        public IActionResult Deletar(string Cpf)
        {
            var PessoaPesquisado = dadosAluno.Where(a => a.Cpf == Cpf).FirstOrDefault();

            if (PessoaPesquisado is null)
                return NotFound($"Aluno com cpf {Cpf} não encontrado.");

            dadosAluno.Remove(PessoaPesquisado);

            return NoContent();
        }
    }
}
