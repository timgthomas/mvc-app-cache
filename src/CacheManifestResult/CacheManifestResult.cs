using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CacheManifestResult
{
   public class CacheManifestResult : ContentResult
   {
      private string _version;
      private readonly IList<string> _cachedResources;

      public CacheManifestResult()
      {
         _cachedResources = new List<string>();
      }

      public override void ExecuteResult(ControllerContext context)
      {
         var content = new StringBuilder();

         content.AppendLine("CACHE MANIFEST");

         AddVersion(content);
         AddCacheResources(content);

         Content = content.ToString();

         ContentType = "text/cache-manifest";
      }

      public void SetVersion(string version)
      {
         _version = version;
      }

      public void AddCachedResource(string url)
      {
         _cachedResources.Add(url);
      }

      private void AddVersion(StringBuilder content)
      {
         if (string.IsNullOrEmpty(_version)) return;

         content.AppendLine("# " + _version);
      }

      private void AddCacheResources(StringBuilder content)
      {
         if (_cachedResources.Count == 0) return;

         content.AppendLine("CACHE:");

         foreach (var file in _cachedResources)
         {
            content.AppendLine(file);
         }
      }
   }
}
