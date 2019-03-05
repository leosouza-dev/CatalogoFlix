using System;
using System.Collections.Generic;
using System.Text;
using Catalogoflix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catalogoflix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<InteresseFilme> InteresseFilme { get; set; }
    }
}
