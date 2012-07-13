using NUnit.Framework;

namespace MvcAppCache.Tests
{
   [TestFixture]
   public class ContentTests : TestBase
   {
      [Test]
      public void Should_begin_with_the_correct_string()
      {
         var result = new AppCacheResult();
         result.ExecuteResult(GetMockContext());

         Assert.IsTrue(result.Content.StartsWith("CACHE MANIFEST"));
      }
   }
}
