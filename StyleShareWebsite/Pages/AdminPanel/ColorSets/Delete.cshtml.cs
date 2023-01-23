﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StyleShareWebsite.Data;
using StyleShareWebsite.Models;

namespace StyleShareWebsite.Pages.AdminPanel.ColorSets
{
    public class DeleteModel : PageModel
    {
        private readonly StyleShareWebsite.Data.ApplicationDbContext _context;

        public DeleteModel(StyleShareWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ColorSet ColorSet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ColorSets == null)
            {
                return NotFound();
            }

            var colorset = await _context.ColorSets.FirstOrDefaultAsync(m => m.Id == id);

            if (colorset == null)
            {
                return NotFound();
            }
            else 
            {
                ColorSet = colorset;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ColorSets == null)
            {
                return NotFound();
            }
            var colorset = await _context.ColorSets.FindAsync(id);

            if (colorset != null)
            {
                ColorSet = colorset;
                _context.ColorSets.Remove(ColorSet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
