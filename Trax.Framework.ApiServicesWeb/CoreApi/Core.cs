using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Framework.ApiServicesWeb.RepositoryApi;
using Trax.Framework.Generic.Logger;
using Trax.Models.Generic.Api;
using Trax.Models.Generic.Api.Response;
using Trax.Models.Generic.OperationResult;

namespace Trax.Framework.ApiServicesWeb.CoreApi
{
    public class Core
    {
        private Logger _Logger;
        public Core(Logger Logger)
        {
            this._Logger = Logger;
        }
        public ClientesListResponseDTO GetListClientes()
        {
            ClientesListResponseDTO _Response = new ClientesListResponseDTO();
            Repository _Repo = new Repository();
            var _Data = _Repo.GetClientes();
            if (!_Data.Any())
            {
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                _Response.Result.AddException(new Exception("No se encontrarón resultados."));
                return _Response;
            }
            _Response.List = _Data.Select(x => new ClientesDTO()
            {
                id_cliente = x.id_cliente,
                nombre_cliente= x.nombre_cliente.Trim(),
                email_cliente= x.email_cliente.Trim(),
                telefono_cliente = x.telefono_cliente,
                fecha_registro  = x.fecha_registro  ?? default(DateTime)
            }).OrderByDescending(x => x.id_cliente).ToList();
            return _Response;
        }
    }
}
