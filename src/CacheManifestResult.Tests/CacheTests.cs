using System;
using NUnit.Framework;

namespace CacheManifestResult.Tests
{
   [TestFixture]
   public class CacheTests : TestBase
   {
      [Test]
      public void Should_add_the_specified_file_to_the_cache()
      {
         var result = new CacheManifestResult();

         result.AddFile("/index.html");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(result.Content, string.Format("CACHE MANIFEST{0}CACHE:{0}/index.html{0}", Environment.NewLine));
      }

      [Test]
      public void Should_add_the_specified_files_to_the_cache()
      {
         var result = new CacheManifestResult();

         result.AddFile("/index.html");
         result.AddFile("/logo.png");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(result.Content, string.Format("CACHE MANIFEST{0}CACHE:{0}/index.html{0}/logo.png{0}", Environment.NewLine));
      }
   }
}