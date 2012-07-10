using System;
using NUnit.Framework;

namespace CacheManifestResult.Tests
{
   [TestFixture]
   public class VersionTests : TestBase
   {
      [Test]
      public void Should_version_the_manifest()
      {
         var result = new CacheManifestResult();

         result.SetVersion("v1.0");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(result.Content, string.Format("CACHE MANIFEST{0}# v1.0{0}", Environment.NewLine));
      }
   }
}
