﻿using NUnit.Framework;

namespace CacheManifestResult.Tests
{
   [TestFixture]
   public class ResultTests : TestBase
   {
      [Test]
      public void Should_return_the_correct_content_type()
      {
         var result = new CacheManifestResult();
         result.ExecuteResult(GetMockContext());

         Assert.AreEqual("text/cache-manifest", result.ContentType);
      }
   }
}
