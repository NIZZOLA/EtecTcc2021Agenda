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
    public class PrestadorController : Controller
    {
        private readonly TCCAgendaContext _context;

        public PrestadorController(TCCAgendaContext context)
        {
            _context = context;
        }

        // GET: Prestador
        public async Task<IActionResult> Index()
        {
            var tCCAgendaContext = _context.Prestadores.Include(p => p.Empresa);
            return View(await tCCAgendaContext.ToListAsync());
        }

        // GET: Prestador/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestadorModel = await _context.Prestadores
                .Include(p => p.Empresa)
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            if (prestadorModel == null)
            {
                return NotFound();
            }

            return View(prestadorModel);
        }

        // GET: Prestador/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome");
            return View();
        }

        // POST: Prestador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestadorId,EmpresaId,Admin,Nome,Email,Senha,Telefone,Cep,Cidade,Estado,Endereco,Bairro,Bloqueado")] PrestadorModel prestadorModel)
        {
            if (ModelState.IsValid)
            {
                prestadorModel.PrestadorId = Guid.NewGuid();
                _context.Add(prestadorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome", prestadorModel.EmpresaId);
            return View(prestadorModel);
        }

        // GET: Prestador/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestadorModel = await _context.Prestadores.FindAsync(id);
            if (prestadorModel == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome", prestadorModel.EmpresaId);
            return View(prestadorModel);
        }

        // POST: Prestador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PrestadorId,EmpresaId,Admin,Nome,Email,Senha,Telefone,Cep,Cidade,Estado,Endereco,Bairro,Bloqueado")] PrestadorModel prestadorModel)
        {
            if (id != prestadorModel.PrestadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestadorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestadorModelExists(prestadorModel.PrestadorId))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "EmpresaId", "Nome", prestadorModel.EmpresaId);
            return View(prestadorModel);
        }

        // GET: Prestador/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestadorModel = await _context.Prestadores
                .Include(p => p.Empresa)
                .FirstOrDefaultAsync(m => m.PrestadorId == id);
            if (prestadorModel == null)
            {
                return NotFound();
            }

            return View(prestadorModel);
        }

        // POST: Prestador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prestadorModel = await _context.Prestadores.FindAsync(id);
            _context.Prestadores.Remove(prestadorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestadorModelExists(Guid id)
        {
            return _context.Prestadores.Any(e => e.PrestadorId == id);
        }
    }
}
