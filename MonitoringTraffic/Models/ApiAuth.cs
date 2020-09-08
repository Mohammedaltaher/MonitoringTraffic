using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.GData.Analytics;
using Google.GData.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class ApiAuth
    {

//        {
// {
//  "error": {
//    "code": 403,
//    "message": "Apps Script API has not been used in project 856192773930 before or it is disabled. Enable it by visiting https://console.developers.google.com/apis/api/script.googleapis.com/overview?project=856192773930 then retry. If you enabled this API recently, wait a few minutes for the action to propagate to our systems and retry.",
//    "status": "PERMISSION_DENIED",
//    "details": [
//      {
//        "@type": "type.googleapis.com/google.rpc.Help",
//        "links": [
//          {
//            "description": "Google developers console API activation",
//            "url": "https://console.developers.google.com/apis/api/script.googleapis.com/overview?project=856192773930"
//          }
//        ]
//      }
//    ]
//  }
//}
//}
    //public void gety()
    //{
    //    string[] scopes = new string[] {
    //    AnalyticsService.Scope.Analytics,  // view and manage your Google Analytics data
    //    AnalyticsService.Scope.AnalyticsEdit,  // Edit and manage Google Analytics Account
    //    AnalyticsService.Scope.AnalyticsManageUsers,   // Edit and manage Google Analytics Users
    //    AnalyticsService.Scope.AnalyticsReadonly};     // View Google Analytics Data

    //    String CLIENT_ID = "6.apps.googleusercontent.com"; // found in Developer console
    //    String CLIENT_SECRET = "xxx";// found in Developer console
    //                                 // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
    //    UserCredential credential =
    //            GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
    //            {
    //                ClientId = CLIENT_ID
    //                                                           ,
    //                ClientSecret = CLIENT_SECRET
    //            }
    //                                                        , scopes
    //                                                        , Environment.UserName
    //                                                        , CancellationToken.None
    //                                                        , new FileDataStore("Daimto.GoogleAnalytics.Auth.Store")).Result;

    //    AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
    //    {
    //        HttpClientInitializer = credential,
    //        ApplicationName = "Analytics API Sample",
    //    });

    //    DataResource.GaResource.GetRequest request = service.Data.Ga.Get("ga:8903098", "2014-01-01", "2014-01-01", "ga:sessions");
    //    request.MaxResults = 1000;
    //    GaData result = request.Execute();
    //}
}
}