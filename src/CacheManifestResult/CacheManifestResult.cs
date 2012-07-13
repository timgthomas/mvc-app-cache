using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CacheManifestResult
{
   public class CacheManifestResult : ContentResult
   {
      private string _version;
      private readonly IList<string> _cachedResources;
      private readonly IList<string> _networkResources;

      public CacheManifestResult()
      {
         _cachedResources = new List<string>();
         _networkResources = new List<string>();
      }

      public override void ExecuteResult(ControllerContext context)
      {
         var content = new StringBuilder();

         content.AppendLine("CACHE MANIFEST");

         AppendVersion(content);
         AppendCacheResources(content);
         AppendNetworkResources(content);

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

      public void AddNetworkResource(string url)
      {
         _networkResources.Add(url);
      }

      private void AppendVersion(StringBuilder content)
      {
         if (string.IsNullOrEmpty(_version)) return;

         content.AppendLine("# " + _version);
      }

      private void AppendCacheResources(StringBuilder content)
      {
         AppendResources(content, "CACHE:", _cachedResources);
      }

      private void AppendNetworkResources(StringBuilder content)
      {
         AppendResources(content, "NETWORK:", _networkResources);
      }

      private void AppendResources(StringBuilder content, string resourceHeader, IList<string> resources)
      {
         if (resources.Count == 0) return;

         content.AppendLine(resourceHeader);

         foreach (var resource in resources)
         {
            content.AppendLine(resource);
         }
      }
   }
}
