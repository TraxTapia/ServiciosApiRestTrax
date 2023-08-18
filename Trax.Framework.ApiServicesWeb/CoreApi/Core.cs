using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Trax.Framework.ApiServicesWeb.RepositoryApi;
using Trax.Framework.Generic.Logger;
using Trax.Models.ApiServicesWeb.Enum;
//using Trax.Models.ApiServicesWeb.TiendaContextBD;
using Trax.Models.ApiServicesWeb.TiendaWeb;
using Trax.Models.Generic.Api;
using Trax.Models.Generic.Api.Request.TiendaWeb;
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

        public OperationResult SaveCategory(string CategoryName)
        {
            OperationResult _Response = new OperationResult();
            Repository _Repo = new Repository();
            Categoria _SaveData = new Categoria()
            {
                Categoria1 =  CategoryName,
                Activo = Estatus.Activo
            };
            _Repo.AddTiendaWeb(_SaveData);
            return _Response;
        }
        public OperationResult SaveProduct(SaveProductRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            Repository _Repo = new Repository();
            Productos _SaveData = new Productos()
            {
                Codigo = GenerarCodigoPersonalizado(),
                Nombre = _Request.Nombre.Trim(),
                Descripcion = _Request.Descripcion.Trim(),
                Precio = _Request.Precio,
                IdCategoria = _Request.IdCategoria,
                Stock = _Request.Stock,
                Activo = Estatus.Activo

            };
            _Repo.AddTiendaWeb(_SaveData);
            return _Response;
        }

       

        static string GenerarCodigoPersonalizado()
        {
            Random random = new Random();
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int longitudCodigo = 5;
            char[] codigo = new char[longitudCodigo];

            for (int i = 0; i < longitudCodigo; i++)
            {
                codigo[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }

            string prefijo = "PRODU"; // Agrega el prefijo aquí
            return prefijo + new string(codigo);
        }



    }
}
