using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;

namespace CoreBetting
{
    public partial class Service
    {
        public class ServiceBase
        {
            protected static T ExecuteRequest<T>(Func<RestResponse<T>> serviceAction)
            {
                ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
                var response = serviceAction.Invoke();
                AssertHooks.AssertStringEquals(test, Convert.ToString(HttpStatusCode.OK), Convert.ToString(response.StatusCode), "Response's Status Code was OK(200) for API.");
                return response.Data;
            }
            protected static T HostNotFoundRequest<T>(Func<RestResponse<T>> serviceAction)
            {
                ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();

                var response = serviceAction.Invoke();
                AssertHooks.AssertStringEquals(test, Convert.ToString(response.StatusCode), Convert.ToString(HttpStatusCode.NotFound), "Response's Status Code was not Not Found(404) for API.");
                return response.Data;
            }

            protected static T PreconditionFailedRequest<T>(Func<RestResponse<T>> serviceAction)
            {
                ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
                var response = serviceAction.Invoke();
                AssertHooks.AssertStringEquals(test, Convert.ToString(response.StatusCode), Convert.ToString(HttpStatusCode.PreconditionFailed), "Response's Status Code was not Not Found(404) for API.");
                return response.Data;
            }

            protected static T EntityCreatedRequest<T>(Func<RestResponse<T>> serviceAction)
            {
                ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
                var response = serviceAction.Invoke();
                AssertHooks.AssertStringEquals(test, Convert.ToString(response.StatusCode), Convert.ToString(HttpStatusCode.Created), "Response's Status Code was not OK(200) for API.");
                return response.Data;
            }

            protected static T InternalServerError<T>(Func<RestResponse<T>> serviceAction)
            {
                ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
                var response = serviceAction.Invoke();
                AssertHooks.AssertStringEquals(test, Convert.ToString(response.StatusCode), Convert.ToString(HttpStatusCode.InternalServerError), "Response's Status Code was not OK(200) for API.");
                return response.Data;
            }
        }

    }
}
