using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace MvcAppCache.Tests
{
   public abstract class TestBase
   {
      protected ControllerContext GetMockContext()
      {
         var request = new Mock<HttpRequestBase>();
         request.Setup(r => r.HttpMethod).Returns("GET");

         var response = new Mock<HttpResponseBase>();
         
         var mockHttpContext = new Mock<HttpContextBase>();
         mockHttpContext.Setup(x => x.Request).Returns(request.Object);
         mockHttpContext.Setup(x => x.Response).Returns(response.Object);

         var controllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), new Mock<ControllerBase>().Object);

         return controllerContext;
      }
   }
}