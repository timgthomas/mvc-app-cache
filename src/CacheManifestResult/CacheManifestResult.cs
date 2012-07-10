using System.Web.Mvc;

namespace CacheManifestResult
{
   public class CacheManifestResult : ContentResult
   {
      public override void ExecuteResult(ControllerContext context)
      {
         Content = "CACHE MANIFEST";

         ContentType = "text/cache-manifest";
      }
   }
}
