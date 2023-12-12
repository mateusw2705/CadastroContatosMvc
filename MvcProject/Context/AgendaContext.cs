using Microsoft.EntityFrameworkCore;
using MvcProject.Models;


namespace MvcProject.Context
{
    public class AgendaContext : DbContext
    {

        //constructor
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) 
        {
        
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
