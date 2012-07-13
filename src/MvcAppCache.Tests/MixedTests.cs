using System;
using NUnit.Framework;

namespace MvcAppCache.Tests
{
   [TestFixture]
   public class MixedTests : TestBase
   {
      [Test]
      public void Should_add_the_specified_mixed_resources_to_the_manifest()
      {
         var result = new AppCacheResult();

         result.AddCachedResource("/index.html");
         result.AddCachedResource("/logo.png");

         result.AddNetworkResource("/style.css");
         result.AddNetworkResource("/app.js");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(string.Format("CACHE MANIFEST{0}CACHE:{0}/index.html{0}/logo.png{0}NETWORK:{0}/style.css{0}/app.js{0}", Environment.NewLine), result.Content);
      }
   }
}