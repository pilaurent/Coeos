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
using Microsoft.AspNetCore.Http.Extensions;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace Coeos.Controllers
{
    

    [Authorize(Roles = WC.AdminRole + "," + WC.SousTraitantRole)]
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
            ViewBag.Categories = new SelectList(_context.Categorie, "Id", "Libelle");
            return View(addInterventionViewModel);
        }

        public class JsonContent : StringContent
        {
            public JsonContent(object obj) :
                base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
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
                    Datecre = addInterventionViewModel.Intervention.Datecre,
                    CategorieId = addInterventionViewModel.Intervention.Categorie.Id
                    
                };
                _context.Add(newIntervention);
                await _context.SaveChangesAsync();

                /*HttpClient _httpClient = new HttpClient();
                using (var content = new StringContent(JsonConvert.SerializeObject("{ 'message': 'Hello World SBE France','phones' : ['+33781881184']}"), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.PostAsync("http://20.74.17.50:5000/message", content).Result;
                    if (result.Content.Equals("ok"))
                        Console.WriteLine("Envoyé !");
                    string returnValue = result.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
                }
                */

                var customObj = "{ 'message': 'Hello World SBE France','phones' : ['+33781881184']}";
                var changePassObj = JsonConvert.SerializeObject(customObj,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://20.74.17.50:5000");

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                   //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var response =
                        await httpClient.PostAsync("/message", new StringContent(changePassObj, Encoding.UTF8, "application/json")))
                    {
                        using (var content = response.Content)
                        {
                            var result = await content.ReadAsStringAsync();
                        }
                    }
                }

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
            ViewBag.CategorieId = new SelectList(_context.Categorie, "Id", "Libelle", intervention.CategorieId);
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
