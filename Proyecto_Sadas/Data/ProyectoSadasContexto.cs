using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sadas.Models;

namespace Proyecto_Sadas.Data
{
    public class ProyectoSadasContexto : DbContext
    {
        public ProyectoSadasContexto (DbContextOptions<ProyectoSadasContexto> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_Sadas.Models.Persona> Persona { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.Solicitud> Solicitud { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.SolicitudPersona> SolicitudPersona { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.SolicitudArchivo> SolicitudArchivo { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.Archivo> Archivo { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.FuncionarioPermiso> FuncionarioPermiso { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.Permiso> Permiso { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.CentroEducativo> CentroEducativo { get; set; } = default!;
        public DbSet<Proyecto_Sadas.Models.Historial> Historial { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitudArchivo>().HasKey(sc => new { sc.id_archivo, sc.id_solicitud });
            modelBuilder.Entity<SolicitudPersona>().HasKey(sc => new { sc.id_persona, sc.id_solicitud });
            modelBuilder.Entity<FuncionarioPermiso>().HasKey(sc => new { sc.id_funcionario, sc.id_permiso });
            modelBuilder.Entity<SolicitudFuncionario>().HasKey(sc => new { sc.id_funcionario, sc.id_solicitud });
            modelBuilder.Entity<SolicitudAuditoria>().HasKey(sc => new { sc.id_auditoria, sc.id_solicitud });

            modelBuilder.Entity<Solicitud>()
               .HasOne(s => s.centro_Educativo)
               .WithMany(g => g.solicitudes)
               .HasForeignKey(s => s.id_centro_Educativo);

            modelBuilder.Entity<Solicitud>()
               .HasOne(s => s.historial)
               .WithMany(g => g.solicitudes)
               .HasForeignKey(s => s.id_historial);
        }
    }
}
