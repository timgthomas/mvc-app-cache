using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CacheManifestResult
{
   public class CacheManifestResult : ContentResult
   {
      private string _version;
      private readonly IList<string> _files;

      public CacheManifestResult()
      {
         _files = new List<string>();
      }

      public override void ExecuteResult(ControllerContext context)
      {
         var content = new StringBuilder();

         content.AppendLine("CACHE MANIFEST");

         AddVersion(content);
         AddCache(content);

         Content = content.ToString();

         ContentType = "text/cache-manifest";
      }

      public void AddFile(string url)
      {
         _files.Add(url);
      }

      public void SetVersion(string version)
      {
         _version = version;
      }

      private void AddVersion(StringBuilder content)
      {
         if (string.IsNullOrEmpty(_version)) return;

         content.AppendLine("# " + _version);
      }

      private void AddCache(StringBuilder content)
      {
         if (_files.Count == 0) return;

         content.AppendLine("CACHE:");

         foreach (var file in _files)
         {
            content.AppendLine(file);
         }
      }
   }
}
