using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext    //Ci permette di fare chiamate col database usando C#
    {
        public DataContext(DbContextOptions options) : base(options)    //Costruttore
        {
        }

        public DbSet<Activity> Activities { get; set; }     //Quando creiamo un oggetto Activity viene automaticamente registrato nel database con cio' che e' stato definito nella classe Activity nel Domain, e' una tabella nel DataBase

    }
}