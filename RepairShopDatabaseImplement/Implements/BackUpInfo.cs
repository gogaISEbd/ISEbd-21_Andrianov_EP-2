using System;
using CarRepairShopContracts.StoragesContracts;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShopDatabaseImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public Assembly GetAssembly() => typeof(BackUpInfo).Assembly;

        public List<PropertyInfo> GetFullList()
        {
            using var context = new CarRepairDatabase();
            var type = context.GetType();
            return type.GetProperties().Where(x => x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
        }

        public List<T> GetList<T>() where T : class, new()
        {
            using var context = new CarRepairDatabase();
            return context.Set<T>().ToList();
        }
    }
}
