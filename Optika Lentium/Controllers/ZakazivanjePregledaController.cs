using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Data;
using Optika_Lentium.Models;

namespace Optika_Lentium.Controllers
{
    [Authorize]
    public class ZakazivanjePregledaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZakazivanjePregledaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZakazivanjePregleda
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZakazivanjePregleda.ToListAsync());
        }
        public async Task<IActionResult> Uspjesnozakazivanje()
        {
            return View(await _context.ZakazivanjePregleda.ToListAsync());
        }

        // GET: ZakazivanjePregleda/Details/5
        [Authorize(Roles = "Administrator, Radnik")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakazivanjePregleda = await _context.ZakazivanjePregleda
                .FirstOrDefaultAsync(m => m.pregledId == id);
            if (zakazivanjePregleda == null)
            {
                return NotFound();
            }

            return View(zakazivanjePregleda);
        }

        // GET: ZakazivanjePregleda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZakazivanjePregleda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("imePrezime,email,brojTelefona,nacinKontakta,danPregleda,vrijemePregleda")] ZakazivanjePregleda zakazivanjePregleda)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the number of users in the AspNetUsers table
                int userCount = await _context.Users.CountAsync();
                int maxPregledId = _context.ZakazivanjePregleda.Max(p => p.pregledId);
                // Increment pregledId based on the user count
                zakazivanjePregleda.pregledId = maxPregledId + 1;

                _context.Add(zakazivanjePregleda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zakazivanjePregleda);
        }

        // GET: ZakazivanjePregleda/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakazivanjePregleda = await _context.ZakazivanjePregleda.FindAsync(id);
            if (zakazivanjePregleda == null)
            {
                return NotFound();
            }
            return View(zakazivanjePregleda);
        }

        // POST: ZakazivanjePregleda/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pregledId,imePrezime,email,brojTelefona,nacinKontakta,danPregleda,vrijemePregleda")] ZakazivanjePregleda zakazivanjePregleda)
        {
            if (id != zakazivanjePregleda.pregledId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zakazivanjePregleda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZakazivanjePregledaExists(zakazivanjePregleda.pregledId))
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
            return View(zakazivanjePregleda);
        }

        // GET: ZakazivanjePregleda/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakazivanjePregleda = await _context.ZakazivanjePregleda
                .FirstOrDefaultAsync(m => m.pregledId == id);
            if (zakazivanjePregleda == null)
            {
                return NotFound();
            }

            return View(zakazivanjePregleda);
        }

        // POST: ZakazivanjePregleda/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zakazivanjePregleda = await _context.ZakazivanjePregleda.FindAsync(id);
            if (zakazivanjePregleda != null)
            {
                _context.ZakazivanjePregleda.Remove(zakazivanjePregleda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZakazivanjePregledaExists(int id)
        {
            return _context.ZakazivanjePregleda.Any(e => e.pregledId == id);
        }
    }
}
