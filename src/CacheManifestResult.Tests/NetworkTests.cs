using System;
using NUnit.Framework;

namespace CacheManifestResult.Tests
{
   [TestFixture]
   public class NetworkTests : TestBase
   {
      [Test]
      public void Should_add_the_specified_resource_to_the_network_section()
      {
         var result = new CacheManifestResult();

         result.AddNetworkResource("/index.html");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(string.Format("CACHE MANIFEST{0}NETWORK:{0}/index.html{0}", Environment.NewLine), result.Content);
      }

      [Test]
      public void Should_add_the_specified_resources_to_the_network_section()
      {
         var result = new CacheManifestResult();

         result.AddNetworkResource("/index.html");
         result.AddNetworkResource("/logo.png");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(string.Format("CACHE MANIFEST{0}NETWORK:{0}/index.html{0}/logo.png{0}", Environment.NewLine), result.Content);
      }
   }
}