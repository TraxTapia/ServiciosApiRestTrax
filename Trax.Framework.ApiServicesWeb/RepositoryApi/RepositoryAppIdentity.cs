using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trax.Models.ApiServicesWeb.TiendaContextBD;
using Trax.Models.ApiServicesWeb.Users;

namespace Trax.Framework.ApiServicesWeb.RepositoryApi
{
    public class RepositoryAppIdentity
    {
        public RepositoryAppIdentity()
        {

        }
        public void AddUsers<T>(T Register) where T : class
        {
            using (UsersContext _ISSDbContext = new UsersContext())
            {
                _ISSDbContext.Set<T>().Add(Register);
                _ISSDbContext.SaveChanges();
            }
        }
        public void AddRangeUsers<T>(List<T> List) where T : class
        {
            using (UsersContext _Context = new UsersContext())
            {
                _Context.Set<T>().AddRange(List);
                _Context.SaveChanges();
            }
        }
        public void UpdateUsers<T>(T Register) where T : class
        {
            using (UsersContext _ISSDbContext = new UsersContext())
            {
                _ISSDbContext.Entry(Register).State = System.Data.Entity.EntityState.Modified;

                _ISSDbContext.SaveChanges();
            }
        }
        public void RemoveUsers<T>(T Register) where T : class
        {
            using (UsersContext _Context = new UsersContext())
            {
                _Context.Set<T>().Attach(Register);
                _Context.Set<T>().Remove(Register);
                _Context.SaveChanges();
            }
        }
    }
}
