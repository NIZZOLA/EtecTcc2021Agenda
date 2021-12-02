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
    public class AgendaController : Controller
    {
        private readonly TCCAgendaContext _context;

        public AgendaController(TCCAgendaContext context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            var tCCAgendaContext = _context.Agendas.Include(a => a.Prestador).Include(a => a.TipoDeServico).Include(a => a.Usuario);
            return View(await tCCAgendaContext.ToListAsync());
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaModel = await _context.Agendas
                .Include(a => a.Prestador)
                .Include(a => a.TipoDeServico)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agendaModel == null)
            {
                return NotFound();
            }

            return View(agendaModel);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            ViewData["PrestadorId"] = new SelectList(_context.Set<PrestadorModel>(), "PrestadorId", "PrestadorId");
            ViewData["TipoDeServicoId"] = new SelectList(_context.Set<TipoDeServicoModel>(), "TipoDeServicoId", "TipoDeServicoId");
            ViewData["UsuarioId"] = new SelectList(_context.Set<UsuarioModel>(), "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendaId,UsuarioId,PrestadorId,DataHoraAgendada,DataHoraTermino,TipoDeServicoId,ValorCobrado,Realizado,CanceladoUsuario,CanceladoPrestador,MotivoDoCancelamento,DataHoraDoCancelamento")] AgendaModel agendaModel)
        {
            if (ModelState.IsValid)
            {
                agendaModel.AgendaId = Guid.NewGuid();
                _context.Add(agendaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrestadorId"] = new SelectList(_context.Set<PrestadorModel>(), "PrestadorId", "PrestadorId", agendaModel.PrestadorId);
            ViewData["TipoDeServicoId"] = new SelectList(_context.Set<TipoDeServicoModel>(), "TipoDeServicoId", "TipoDeServicoId", agendaModel.TipoDeServicoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<UsuarioModel>(), "UsuarioId", "UsuarioId", agendaModel.UsuarioId);
            return View(agendaModel);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaModel = await _context.Agendas.FindAsync(id);
            if (agendaModel == null)
            {
                return NotFound();
            }
            ViewData["PrestadorId"] = new SelectList(_context.Set<PrestadorModel>(), "PrestadorId", "PrestadorId", agendaModel.PrestadorId);
            ViewData["TipoDeServicoId"] = new SelectList(_context.Set<TipoDeServicoModel>(), "TipoDeServicoId", "TipoDeServicoId", agendaModel.TipoDeServicoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<UsuarioModel>(), "UsuarioId", "UsuarioId", agendaModel.UsuarioId);
            return View(agendaModel);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AgendaId,UsuarioId,PrestadorId,DataHoraAgendada,DataHoraTermino,TipoDeServicoId,ValorCobrado,Realizado,CanceladoUsuario,CanceladoPrestador,MotivoDoCancelamento,DataHoraDoCancelamento")] AgendaModel agendaModel)
        {
            if (id != agendaModel.AgendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaModelExists(agendaModel.AgendaId))
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
            ViewData["PrestadorId"] = new SelectList(_context.Set<PrestadorModel>(), "PrestadorId", "PrestadorId", agendaModel.PrestadorId);
            ViewData["TipoDeServicoId"] = new SelectList(_context.Set<TipoDeServicoModel>(), "TipoDeServicoId", "TipoDeServicoId", agendaModel.TipoDeServicoId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<UsuarioModel>(), "UsuarioId", "UsuarioId", agendaModel.UsuarioId);
            return View(agendaModel);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaModel = await _context.Agendas
                .Include(a => a.Prestador)
                .Include(a => a.TipoDeServico)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agendaModel == null)
            {
                return NotFound();
            }

            return View(agendaModel);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var agendaModel = await _context.Agendas.FindAsync(id);
            _context.Agendas.Remove(agendaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaModelExists(Guid id)
        {
            return _context.Agendas.Any(e => e.AgendaId == id);
        }
    }
}
