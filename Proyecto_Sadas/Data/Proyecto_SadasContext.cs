using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sadas.Models;

namespace Proyecto_Sadas.Data
{
    public class Proyecto_SadasContext : DbContext
    {
        public Proyecto_SadasContext (DbContextOptions<Proyecto_SadasContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_Sadas.Models.Persona> Persona { get; set; } = default!;
    }
}
