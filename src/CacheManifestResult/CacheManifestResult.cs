using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CacheManifestResult
{
   public class CacheManifestResult : ContentResult
   {
      private IList<string> _files;

      public CacheManifestResult()
      {
         _files = new List<string>();
      }

      public override void ExecuteResult(ControllerContext context)
      {
         var content = new StringBuilder();

         content.AppendLine("CACHE MANIFEST");

         AddCache(content);

         Content = content.ToString();

         ContentType = "text/cache-manifest";
      }

      public void AddFile(string url)
      {
         _files.Add(url);
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
