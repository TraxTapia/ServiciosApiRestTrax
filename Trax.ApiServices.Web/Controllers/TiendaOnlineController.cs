
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using System.Configuration;
using Trax.Framework.Generic.Logger;
using Trax.Framework.identity.Filters;
using Trax.Models.Generic.Api.Response;
using Trax.Framework.ApiServicesWeb.CoreApi;
using Trax.Models.Generic.OperationResult;

namespace Trax.ApiServices.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("TiendaWeb")]
    public class TiendaOnlineController : ApiController
    {
        private Logger _Logger;
        public TiendaOnlineController()
        {
            this._Logger = new Logger(System.Web.Hosting.HostingEnvironment.MapPath("~/" + Properties.Settings.Default.LogPath));
        }
        [HttpPost]
        [Route("GetListClientes")]
        //[UserInRole(Application = "MAC.API")]
        public ClientesListResponseDTO GetListClientes()
        {
            var _Response = new ClientesListResponseDTO();
            string _CurrentUserName = System.Web.HttpContext.Current.User.Identity.Name;
            try
            {
                if (!ModelState.IsValid)
                {
                    _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    _Errors.ForEach(x =>
                    {
                        if (x.Exception == null) _Response.Result.AddException(new Exception(x.ErrorMessage));
                        else _Response.Result.AddException(x.Exception);
                    });
                    return _Response;
                }
                var _Core = new Core(this._Logger);
                _Response =_Core.GetListClientes();
            }
            catch (Exception ex)
            {
                this._Logger.LogText("Error : Usuario : " + _CurrentUserName);
                this._Logger.LogError(ex);
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
            }
            return _Response;
        }
    }
}