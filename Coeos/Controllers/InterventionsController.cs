using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coeos.Data;
using Coeos.Models;
using Coeos.Models.ViewsModels;
using Microsoft.AspNetCore.Authorization;

namespace Coeos.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class InterventionsController : Controller
    {
        private readonly CoeosContext _context;

        public InterventionsController(CoeosContext context)
        {
            _context = context;
        }

        // GET: Interventions
        public async Task<IActionResult> Index(string searchString)
        {
            var interventions = from m in _context.Intervention
                                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                interventions = interventions.Where(s => s.Description.Contains(searchString));
            }
            //var coeosContext = _context.Intervention;
            return View(await interventions.ToListAsync());
        }

        // GET: Interventions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<AgentIntervention> items = _context
                .AgentInterventions
                .Include(item => item.Agent)
                .Where(ai => ai.InterventionID == id)
                .ToList();

            Intervention intervention = _context.Intervention.Single(i => i.Id == id);

            ViewInterventionViewModel interventionModel = new ViewInterventionViewModel
            {
                Intervention = intervention,
                Items = items
            };

            return View(interventionModel);
        }

        public IActionResult AddItem(int id)
        {
            Intervention intervention = _context.Intervention.Single(i => i.Id == id);
            List<Agent> agents = _context.Agent.ToList();
            return View(new AddInterventionItemViewModel(intervention,agents));
        }

        [HttpPost]
        public IActionResult AddItem(AddInterventionItemViewModel addInterventionItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var agentId = addInterventionItemViewModel.AgentID;
                var interventionID = addInterventionItemViewModel.InterventionID;

                IList<AgentIntervention> existingItems = _context.AgentInterventions
                    .Where(ai => ai.AgentID == agentId)
                    .Where(ai => ai.InterventionID == interventionID).ToList();

                if (existingItems.Count == 0)
                {
                    AgentIntervention interventionItem = new AgentIntervention
                    {
                        Agent = _context.Agent.Single(a => a.Id == agentId),
                        Intervention = _context.Intervention.Single(i => i.Id == interventionID)
                    };

                    _context.AgentInterventions.Add(interventionItem);
                    _context.SaveChanges();
                }
                return Redirect(string.Format("/Interventions/Details/{0}", addInterventionItemViewModel.InterventionID));
            }
            return View(addInterventionItemViewModel);
        }


        // GET: Interventions/Create
        public IActionResult Create()
        {
            //ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Id");
            AddInterventionViewModel addInterventionViewModel = new AddInterventionViewModel();

            return View(addInterventionViewModel);
        }

        // POST: Interventions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddInterventionViewModel addInterventionViewModel)
        {
            if (ModelState.IsValid)
            {
                Intervention newIntervention = new Intervention
                {
                    Libelle = addInterventionViewModel.Intervention.Libelle,
                    Lieux = addInterventionViewModel.Intervention.Lieux,
                    Description = addInterventionViewModel.Intervention.Description,
                    Dateintervention = addInterventionViewModel.Intervention.Dateintervention,
                    Encours = addInterventionViewModel.Intervention.Encours,
                    Fin = addInterventionViewModel.Intervention.Fin,
                    Photos = addInterventionViewModel.Intervention.Photos,
                    Datecre = addInterventionViewModel.Intervention.Datecre
                };
                _context.Add(newIntervention);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addInterventionViewModel);
        }

        // GET: Interventions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervention = await _context.Intervention.FindAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }
            return View(intervention);
        }

        // POST: Interventions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Libelle,Description,CategorieId,Dateintervention,Encours,Fin,Escalade,Datecre")] Intervention intervention)
        {
            if (id != intervention.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intervention);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterventionExists(intervention.Id))
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
            return View(intervention);
        }

        // GET: Interventions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervention = await _context.Intervention
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intervention == null)
            {
                return NotFound();
            }

            return View(intervention);
        }

        // POST: Interventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intervention = await _context.Intervention.FindAsync(id);
            _context.Intervention.Remove(intervention);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterventionExists(int id)
        {
            return _context.Intervention.Any(e => e.Id == id);
        }
    }
}
