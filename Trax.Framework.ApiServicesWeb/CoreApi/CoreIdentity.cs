using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trax.Framework.ApiServicesWeb.RepositoryApi;
using Trax.Framework.Generic.Logger;
using Trax.Models.ApiServicesWeb.Enum;
using Trax.Models.ApiServicesWeb.Users;
using Trax.Models.Generic.OperationResult;

namespace Trax.Framework.ApiServicesWeb.CoreApi
{
    public class CoreIdentity
    {
        private Logger _Logger;
        public CoreIdentity(Logger Logger)
        {
            this._Logger = Logger;
        }
        public async Task<OperationResult> ResgisterAplications(string NameAplicaions)
        {
            OperationResult _Response = new OperationResult();
            RepositoryAppIdentity _Repo = new RepositoryAppIdentity();
            Aplications _SaveData = new Aplications()
            {
                Name = NameAplicaions,
                Visible = Estatus.Activo
            };

            _Repo.AddUsers(_SaveData);
            return await Task.FromResult( _Response);
        }
    }
}
