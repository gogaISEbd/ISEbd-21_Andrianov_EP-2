using Microsoft.EntityFrameworkCore;
using CarRepairShopDatabaseImplement.Models;

namespace CarRepairShopDatabaseImplement
{
    public class CarRepairDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TPD3UTK;Initial Catalog= CarRepairDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<repair> Repair { set; get; }

        public virtual DbSet<RepairComponent> RepairComponent { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
    }
}

