
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
using Trax.Models.Generic.Api.Request.TiendaWeb;

namespace Trax.ApiServices.Web.Controllers
{

    [RoutePrefix("TiendaWeb")]
    [Authorize]
    public class TiendaOnlineController : ApiController
    {
        private Logger _Logger;
        public TiendaOnlineController()
        {
            this._Logger = new Logger(System.Web.Hosting.HostingEnvironment.MapPath("~/" + Properties.Settings.Default.LogPath));
        }
        [HttpPost]
        [Route("GetListClientes")]
        //[UserInRole(Application = "API.Services")]
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

        [HttpPost]
        [Route("SaveCategory")]
        [UserInRole(Application = "ApiServices.Web")]
        public OperationResult SaveCategory([FromBody]string CategoryName)
        {
            var _Response = new OperationResult();
            string _CurrentUserName = System.Web.HttpContext.Current.User.Identity.Name;
            try
            {
                if (!ModelState.IsValid)
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    _Errors.ForEach(x =>
                    {
                        if (x.Exception == null) _Response.AddException(new Exception(x.ErrorMessage));
                        else _Response.AddException(x.Exception);
                    });
                    return _Response;
                }
                var _Core = new Core(this._Logger);
                _Response = _Core.SaveCategory(CategoryName);
            }
            catch (Exception ex)
            {
                this._Logger.LogText("Error : Usuario : " + _CurrentUserName);
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }
        [HttpPost]
        [Route("SaveProduct")]
        [UserInRole(Application = "ApiServices.Web")]
        public OperationResult SaveProduct(SaveProductRequestDTO _Request)
        {
            var _Response = new OperationResult();
            string _CurrentUserName = System.Web.HttpContext.Current.User.Identity.Name;
            try
            {
                if (!ModelState.IsValid)
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.BAD_REQUEST);
                    var _Errors = ModelState.Values.SelectMany(x => x.Errors).ToList();
                    _Errors.ForEach(x =>
                    {
                        if (x.Exception == null) _Response.AddException(new Exception(x.ErrorMessage));
                        else _Response.AddException(x.Exception);
                    });
                    return _Response;
                }
                var _Core = new Core(this._Logger);
                _Response = _Core.SaveProduct(_Request);
            }
            catch (Exception ex)
            {
                this._Logger.LogText("Error : Usuario : " + _CurrentUserName);
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }
    }
}