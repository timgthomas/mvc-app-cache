using System;
using NUnit.Framework;

namespace CacheManifestResult.Tests
{
   [TestFixture]
   public class CacheTests : TestBase
   {
      [Test]
      public void Should_add_the_specified_resource_to_the_cache()
      {
         var result = new CacheManifestResult();

         result.AddCachedResource("/index.html");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(result.Content, string.Format("CACHE MANIFEST{0}CACHE:{0}/index.html{0}", Environment.NewLine));
      }

      [Test]
      public void Should_add_the_specified_resources_to_the_cache()
      {
         var result = new CacheManifestResult();

         result.AddCachedResource("/index.html");
         result.AddCachedResource("/logo.png");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(result.Content, string.Format("CACHE MANIFEST{0}CACHE:{0}/index.html{0}/logo.png{0}", Environment.NewLine));
      }
   }
}