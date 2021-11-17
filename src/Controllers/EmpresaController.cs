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
    public class EmpresaController : Controller
    {
        private readonly TCCAgendaContext _context;

        public EmpresaController(TCCAgendaContext context)
        {
            _context = context;
        }

        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            var tCCAgendaContext = _context.Empresas.Include(e => e.Plano);
            return View(await tCCAgendaContext.ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaModel = await _context.Empresas
                .Include(e => e.Plano)
                .FirstOrDefaultAsync(m => m.EmpresaId == id);
            if (empresaModel == null)
            {
                return NotFound();
            }

            return View(empresaModel);
        }

        // GET: Empresa/Create
        public IActionResult Create()
        {
            ViewData["PlanoId"] = new SelectList(_context.Set<PlanoModel>(), "PlanoId", "PlanoId");
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaId,Nome,PessoaFisica,CpfCnpj,Rua,Numero,Bairro,Cidade,Estado,Cep,PlanoId,DataCadastro,DataInativacao")] EmpresaModel empresaModel)
        {
            if (ModelState.IsValid)
            {
                empresaModel.EmpresaId = Guid.NewGuid();
                _context.Add(empresaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanoId"] = new SelectList(_context.Set<PlanoModel>(), "PlanoId", "PlanoId", empresaModel.PlanoId);
            return View(empresaModel);
        }

        // GET: Empresa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaModel = await _context.Empresas.FindAsync(id);
            if (empresaModel == null)
            {
                return NotFound();
            }
            ViewData["PlanoId"] = new SelectList(_context.Set<PlanoModel>(), "PlanoId", "PlanoId", empresaModel.PlanoId);
            return View(empresaModel);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmpresaId,Nome,PessoaFisica,CpfCnpj,Rua,Numero,Bairro,Cidade,Estado,Cep,PlanoId,DataCadastro,DataInativacao")] EmpresaModel empresaModel)
        {
            if (id != empresaModel.EmpresaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaModelExists(empresaModel.EmpresaId))
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
            ViewData["PlanoId"] = new SelectList(_context.Set<PlanoModel>(), "PlanoId", "PlanoId", empresaModel.PlanoId);
            return View(empresaModel);
        }

        // GET: Empresa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaModel = await _context.Empresas
                .Include(e => e.Plano)
                .FirstOrDefaultAsync(m => m.EmpresaId == id);
            if (empresaModel == null)
            {
                return NotFound();
            }

            return View(empresaModel);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var empresaModel = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaModelExists(Guid id)
        {
            return _context.Empresas.Any(e => e.EmpresaId == id);
        }
    }
}
