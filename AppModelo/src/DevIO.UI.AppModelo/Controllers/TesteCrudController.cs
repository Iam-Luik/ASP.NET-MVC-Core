using DevIO.UI.AppModelo.Data;
using DevIO.UI.AppModelo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.AppModelo.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Luik",
                DataNascimento = DateTime.Now,
                Email = "castro.luik@outlook.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "castro.luik@outlook.com");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Luik") ;

            aluno.Nome = "João";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View();
        }
    }
}
