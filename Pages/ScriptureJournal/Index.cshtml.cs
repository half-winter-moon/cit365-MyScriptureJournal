using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_ScriptureJournal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureJournalNote { get; set; }
        
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of notes.
            IQueryable<string> bookQuery = from m in _context.Journal
                                    orderby m.Book
                                    select m.Book;
            var scriptures = from m in _context.Journal
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ScriptureJournalNote))
            {
                scriptures = scriptures.Where(x => x.Notes.Contains(ScriptureJournalNote));
            }
  
            Books = new SelectList(await bookQuery.ToListAsync());

            Journal = await scriptures.ToListAsync();
        }
        
        // public async Task OnGetAsync()
        // {
        //     var scriptures = from m in _context.Journal
        //          select m;
        //     if (_context.Journal != null)
        //     {
        //         Journal = await _context.Journal.ToListAsync();
        //     }
        // }
    }
}
