using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using KalikoCMS.Mvc.Framework;
using Web.Business.Services;
using Web.Models.Pages;

//namespace Web.Controllers.Pages
//{
    //public class GoogleFotosPageController : PageController<GoogleFotosPage>
    //{
    //    public class ArticlePageController : PageController<ArticlePage>
    //    {
    //        public override ActionResult Index(ArticlePage currentPage)
    //        {
    //            return View(currentPage);
    //        }

    //        public async Task IndexAsync(CancellationToken cancellationToken)
    //        {
    //            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
    //                AuthorizeAsync(cancellationToken);

    //            if (result.Credential != null)
    //            {
    //                var service = new DriveService(new BaseClientService.Initializer
    //                {
    //                    HttpClientInitializer = result.Credential,
    //                    ApplicationName = "ASP.NET MVC Sample"
    //                });

    //                // YOUR CODE SHOULD BE HERE..
    //                // SAMPLE CODE:
    //                var list = await service.Files.List().ExecuteAsync();
    //                ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();

    //                return View();
    //            }
    //            else
    //            {
    //                return new RedirectResult(result.RedirectUri);
    //            }
    //        }


    //    }
    //}



  
//    }
//}