using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDocker.DAL;

namespace WebDocker.Pages
{
    public class IndexModel : PageModel
    {
        MySqlDbContext context;
        public List<User> Users { get; set; }

        public IndexModel(MySqlDbContext context)
        {
            this.context = context;
          //  context.Database.EnsureCreated();
        }

        public async Task OnGet()
        {
            Users = await context.Users.ToListAsync();
        }
    }
}
