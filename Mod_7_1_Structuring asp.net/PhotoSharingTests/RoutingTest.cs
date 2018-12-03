using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoSharingApplication;
using PhotoSharingTests.Doubles;

namespace PhotoSharingTests
{
    [TestClass]
    public class RoutingTest
    {
        [TestMethod]
        public void Test_Default_Route_ControllerOnly()
        {
            var context = new FakeHttpContextForRouting(requestUrl: "~/ControllerName");

            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(context);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("ControllerName", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }

        [TestMethod]
        public void Test_Photo_Route_With_PhotoID()
        {
            var context = new FakeHttpContextForRouting(requestUrl: "~/photo/2");

            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(context);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("Display", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        }

        //https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/blob/53e7b87d7ec25714da600088f023d368223466b6/Instructions/20486C/20486C_MOD07_LAK.md

        [TestMethod]
        public void Test_Photo_Title_Route()
        {
            var context = new FakeHttpContextForRouting(requestUrl: "~/photo/title/my%20tille");

            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(context);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("DisplayByTitle", routeData.Values["action"]);
            Assert.AreEqual("my%20title", routeData.Values["title"]);
        }
    }
}
