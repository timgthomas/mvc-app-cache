using System;
using NUnit.Framework;

namespace MvcAppCache.Tests
{
   [TestFixture]
   public class NetworkTests : TestBase
   {
      [Test]
      public void Should_add_the_specified_network_resource_to_the_manifest()
      {
         var result = new AppCacheResult();

         result.AddNetworkResource("/index.html");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(string.Format("CACHE MANIFEST{0}NETWORK:{0}/index.html{0}", Environment.NewLine), result.Content);
      }

      [Test]
      public void Should_add_the_specified_network_resources_to_the_manifest()
      {
         var result = new AppCacheResult();

         result.AddNetworkResource("/index.html");
         result.AddNetworkResource("/logo.png");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(string.Format("CACHE MANIFEST{0}NETWORK:{0}/index.html{0}/logo.png{0}", Environment.NewLine), result.Content);
      }
   }
}