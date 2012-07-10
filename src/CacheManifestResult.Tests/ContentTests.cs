using NUnit.Framework;

namespace CacheManifestResult.Tests
{
   [TestFixture]
   public class ContentTests : TestBase
   {
      [Test]
      public void Should_begin_with_the_correct_string()
      {
         var result = new CacheManifestResult();
         result.ExecuteResult(GetMockContext());

         Assert.IsTrue(result.Content.StartsWith("CACHE MANIFEST"));
      }
   }
}
