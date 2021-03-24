using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wohnverwaltung.Data;
using Wohnverwaltung.Models;

namespace Wohnverwaltung.Controllers
{
    public class WohnungController : Controller
    {
        private readonly WohnungsContext _context;

        public WohnungController(WohnungsContext context)
        {
            _context = context;
        }

        // GET: Wohnung
        public async Task<IActionResult> Index(bool? ShowAll)
        {
            ViewBag.BoolShowAll = ShowAll.HasValue && ShowAll.Value ? false : true;
            return View(await _context.Wohnungen.ToListAsync());
        }

        // GET: Wohnung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wohnung/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Bezeichnung,Straße,PLZ,Ort,IstInaktiv")] Wohnung wohnung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wohnung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wohnung);
        }

        // GET: Wohnung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wohnung = await _context.Wohnungen.FindAsync(id);
            if (wohnung == null)
            {
                return NotFound();
            }
            return View(wohnung);
        }

        // POST: Wohnung/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Bezeichnung,Straße,PLZ,Ort,IstInaktiv")] Wohnung wohnung)
        {
            if (id != wohnung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wohnung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WohnungExists(wohnung.ID))
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
            return View(wohnung);
        }


        private bool WohnungExists(int id)
        {
            return _context.Wohnungen.Any(e => e.ID == id);
        }
    }
}
