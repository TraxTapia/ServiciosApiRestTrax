using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Models.ApiServicesWeb.TiendaContextBD;

namespace Trax.Framework.ApiServicesWeb.RepositoryApi
{
    public class Repository
    {
        public Repository()
        {

        }
        public void AddTienda<T>(T Register) where T : class
        {
            using (TiendaBdContext _ISSDbContext = new TiendaBdContext())
            {
                _ISSDbContext.Set<T>().Add(Register);
                _ISSDbContext.SaveChanges();
            }
        }
        public void AddRangeTienda<T>(List<T> List) where T : class
        {
            using (TiendaBdContext _Context = new TiendaBdContext())
            {
                _Context.Set<T>().AddRange(List);
                _Context.SaveChanges();
            }
        }
        public void UpdateTienda<T>(T Register) where T : class
        {
            using (TiendaBdContext _ISSDbContext = new TiendaBdContext())
            {
                _ISSDbContext.Entry(Register).State = System.Data.Entity.EntityState.Modified;

                _ISSDbContext.SaveChanges();
            }
        }
        public void RemoveTienda<T>(T Register) where T : class
        {
            using (TiendaBdContext _Context = new TiendaBdContext())
            {
                _Context.Set<T>().Attach(Register);
                _Context.Set<T>().Remove(Register);
                _Context.SaveChanges();
            }
        }

        public List<Clientes> GetClientes ()
        {
            using (TiendaBdContext _Context =  new TiendaBdContext())
            {
                return _Context.Clientes.AsNoTracking().ToList();
            }
        } 
    }
}
