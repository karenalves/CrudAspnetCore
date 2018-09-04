using System;
using System.Collections.Generic;
using System.Text;
using CrudAspnetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudAspnetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
