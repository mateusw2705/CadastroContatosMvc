using Microsoft.AspNetCore.Mvc;
using MvcProject.Context;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar() 
        {
          return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            //verifica se o modelo esta valido 
            if(ModelState.IsValid)
            {
                //adiciona um novo contato
               _context.Add(contato);
               _context.SaveChanges();
               return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            //verifica se o modelo esta valido 
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);
            //verifica se o modelo esta valido 
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);
            //verifica se o modelo esta valido 
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);

        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);
            _context.Remove(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
