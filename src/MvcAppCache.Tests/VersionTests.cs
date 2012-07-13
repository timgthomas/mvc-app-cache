using System;
using NUnit.Framework;

namespace MvcAppCache.Tests
{
   [TestFixture]
   public class VersionTests : TestBase
   {
      [Test]
      public void Should_version_the_manifest()
      {
         var result = new AppCacheResult();

         result.SetVersion("v1.0");

         result.ExecuteResult(GetMockContext());

         Assert.AreEqual(result.Content, string.Format("CACHE MANIFEST{0}# v1.0{0}", Environment.NewLine));
      }
   }
}
