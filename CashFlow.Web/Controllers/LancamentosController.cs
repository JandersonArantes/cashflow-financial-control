using CashFlow.Web.Data;
using CashFlow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Web.Controllers
{
    public class LancamentosController(AppDbContext context) : Controller
    {

        private readonly AppDbContext _context = context;

        public IActionResult Index()
        {
            var lancamentos = _context.Lancamentos.ToList();

            ViewBag.TotalReceitas = _context
                .Lancamentos
                .Where(lancamento => lancamento.Tipo == "Receita")
                .Sum(lancamento => lancamento.Valor);

            ViewBag.TotalDespesas = _context
                .Lancamentos
                .Where(lancamento => lancamento.Tipo == "Despesa")
                .Sum(lancamento => lancamento.Valor);

            ViewBag.Saldo = ViewBag.TotalReceitas - ViewBag.TotalDespesas;

            return View(lancamentos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                _context.Lancamentos.Add(lancamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lancamento);
        }

        // Por que está IAction Delete não precisa de anotação?
        // Porque ela é do tipo GET, e o padrão é GET, então não precisa ser anotada. Já a outra ação,
        // que é do tipo POST, precisa ser anotada com [HttpPost] para indicar que ela deve ser chamada
        // quando um formulário for submetido.
        // Além disso, a ação Delete é responsável por exibir a página de confirmação de exclusão,
        // enquanto a ação DeleteConfirmed é responsável por realizar a exclusão do lançamento.
        // Por isso, a ação Delete é do tipo GET e a ação DeleteConfirmed é do tipo POST.
        // E por que DeleteConfirmed não tem a anotação [HttpDelete]?
        // Porque o HTML não suporta o método DELETE, então usamos POST para simular a exclusão.
        // O HTML suporta apenas os métodos GET e POST, então para realizar operações de atualização ou exclusão,
        // é comum usar o método POST e indicar a ação específica (como DeleteConfirmed) para diferenciar das
        // outras ações de criação ou atualização.
        public IActionResult Delete(int id)
        {
            var lancamento = _context.Lancamentos.FirstOrDefault(lancamento => lancamento.Id == id);

            if (lancamento is null) return NotFound();

            return View(lancamento);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var lancamento = _context.Lancamentos.FirstOrDefault(lancamento => lancamento.Id == id);
            
            if (lancamento is null) return NotFound();
            
            _context.Lancamentos.Remove(lancamento);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }  
}
