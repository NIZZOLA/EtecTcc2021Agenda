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
    public class PlanoController : ControllerExtended
    {
        private readonly TCCAgendaContext _context;
        private string nomeController = "Planos";

        public PlanoController(TCCAgendaContext context)
        {
            _context = context;
        }

        // GET: Plano
        public async Task<IActionResult> Index()
        {
            base.CriaViewBags("Index", this.nomeController);
            return View(await _context.Planos.ToListAsync());
        }

        

        // GET: Plano/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            CriaViewBags("Details", this.nomeController);
            if (id == null)
            {
                return NotFound();
            }

            var planoModel = await _context.Planos
                .FirstOrDefaultAsync(m => m.PlanoId == id);
            if (planoModel == null)
            {
                return NotFound();
            }

            return View(planoModel);
        }

        // GET: Plano/Create
        public IActionResult Create()
        {
            CriaViewBags("Create", this.nomeController);
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanoId,Descricao,ValorMensal,LimiteDeUsuario,Ativo")] PlanoModel planoModel)
        {
            CriaViewBags("Create", this.nomeController);
            if (ModelState.IsValid)
            {
                planoModel.PlanoId = Guid.NewGuid();
                _context.Add(planoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoModel);
        }

        // GET: Plano/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            CriaViewBags("Edit", this.nomeController);
            if (id == null)
            {
                return NotFound();
            }

            var planoModel = await _context.Planos.FindAsync(id);
            if (planoModel == null)
            {
                return NotFound();
            }
            return View(planoModel);
        }

        // POST: Plano/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PlanoId,Descricao,ValorMensal,LimiteDeUsuario,Ativo")] PlanoModel planoModel)
        {
            CriaViewBags("Edit", this.nomeController);
            if (id != planoModel.PlanoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoModelExists(planoModel.PlanoId))
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
            return View(planoModel);
        }

        // GET: Plano/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            CriaViewBags("Delete", this.nomeController);
            if (id == null)
            {
                return NotFound();
            }

            var planoModel = await _context.Planos
                .FirstOrDefaultAsync(m => m.PlanoId == id);
            if (planoModel == null)
            {
                return NotFound();
            }

            return View(planoModel);
        }

        // POST: Plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            CriaViewBags("Delete", this.nomeController);

            var planoModel = await _context.Planos.FindAsync(id);
            _context.Planos.Remove(planoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoModelExists(Guid id)
        {
            return _context.Planos.Any(e => e.PlanoId == id);
        }
    }
}
