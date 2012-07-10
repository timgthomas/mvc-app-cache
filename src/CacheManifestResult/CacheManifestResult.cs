using System.Web.Mvc;

namespace CacheManifestResult
{
   public class CacheManifestResult : ContentResult
   {
      public override void ExecuteResult(ControllerContext context)
      {
         ContentType = "text/cache-manifest";
      }
   }
}
