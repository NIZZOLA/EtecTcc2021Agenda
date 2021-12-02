using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCC.Agenda.Data;
using TCC.Agenda.Models;

namespace TCC.Agenda.Controllers
{
    public class TipoDeServicoController : Controller
    {
        private readonly TCCAgendaContext _context;

        public TipoDeServicoController(TCCAgendaContext context)
        {
            _context = context;
        }

        // GET: TipoDeServico
        public async Task<IActionResult> Index()
        {
            var tCCAgendaContext = _context.TipoDeServicos.Include(t => t.Empresa);
            return View(await tCCAgendaContext.ToListAsync());
        }

        // GET: TipoDeServico/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeServicoModel = await _context.TipoDeServicos
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(m => m.TipoDeServicoId == id);
            if (tipoDeServicoModel == null)
            {
                return NotFound();
            }

            return View(tipoDeServicoModel);
        }

        // GET: TipoDeServico/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome");
            return View();
        }

        // POST: TipoDeServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDeServicoId,Nome,Detalhes,DuracaoMinutos,ValorCobrado,Ativo,EmpresaId")] TipoDeServicoModel tipoDeServicoModel)
        {
            if (ModelState.IsValid)
            {
                tipoDeServicoModel.TipoDeServicoId = Guid.NewGuid();
                _context.Add(tipoDeServicoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome", tipoDeServicoModel.EmpresaId);
            return View(tipoDeServicoModel);
        }

        // GET: TipoDeServico/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeServicoModel = await _context.TipoDeServicos.FindAsync(id);
            if (tipoDeServicoModel == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome", tipoDeServicoModel.EmpresaId);
            return View(tipoDeServicoModel);
        }

        // POST: TipoDeServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TipoDeServicoId,Nome,Detalhes,DuracaoMinutos,ValorCobrado,Ativo,EmpresaId")] TipoDeServicoModel tipoDeServicoModel)
        {
            if (id != tipoDeServicoModel.TipoDeServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeServicoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeServicoModelExists(tipoDeServicoModel.TipoDeServicoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome", tipoDeServicoModel.EmpresaId);
            return View(tipoDeServicoModel);
        }

        // GET: TipoDeServico/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeServicoModel = await _context.TipoDeServicos
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(m => m.TipoDeServicoId == id);
            if (tipoDeServicoModel == null)
            {
                return NotFound();
            }

            return View(tipoDeServicoModel);
        }

        // POST: TipoDeServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoDeServicoModel = await _context.TipoDeServicos.FindAsync(id);
            _context.TipoDeServicos.Remove(tipoDeServicoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeServicoModelExists(Guid id)
        {
            return _context.TipoDeServicos.Any(e => e.TipoDeServicoId == id);
        }
    }
}
