using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Trax.Framework.ApiServicesWeb.CoreApi;
using Trax.Framework.Generic.Logger;
using Trax.Framework.identity.Filters;
using Trax.Models.Generic.OperationResult;
using static System.Net.Mime.MediaTypeNames;

namespace Trax.ApiServices.Web.Controllers
{
   
    [RoutePrefix("Users")]
    [Authorize]
    public class UsersConfigurationsController : ApiController
    {
        private readonly Logger _logger;
        public UsersConfigurationsController()
        {
            this._logger = new Logger(System.Web.Hosting.HostingEnvironment.MapPath("~/" + Properties.Settings.Default.LogPath));
        }
        [HttpPost]
        [Route("RegisterAplications")]
        [UserInRole(Application = "ApiServices.Web")]
        public async Task<OperationResult> ResgisterAplications([FromBody]string NameAplication)
        {
            OperationResult _Response = new OperationResult();
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
                var _Core = new CoreIdentity(this._logger);
                _Response = await _Core.ResgisterAplications(NameAplication);
            }
            catch (Exception ex)
            {
                this._logger.LogText(System.Web.HttpContext.Current.User.Identity.Name);
                this._logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }
    }
}