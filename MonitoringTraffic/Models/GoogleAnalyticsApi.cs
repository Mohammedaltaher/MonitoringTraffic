using Google.GData.Analytics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class GoogleAnalyticsApi
    {
        private readonly String ClientUserName;
        private readonly String ClientPassword;
        private readonly String TableID;
        private AnalyticsService analyticsService;

        public GoogleAnalyticsApi(string user, string password, string table)
        {
            this.ClientUserName = user;
            this.ClientPassword = password;
            this.TableID = table;
            try
            {
                // Configure GA API.
                analyticsService = new AnalyticsService("Concord12");
                // Client Login Authorization.
                analyticsService.setUserCredentials(ClientUserName, ClientPassword);
              //  var clintToken = analyticsService.Credentials.ClientToken.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        /// <summary>
        /// Get the page views for a particular page path
        /// </summary>
        /// <param name="pagePath"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isPathAbsolute">make this false if the pagePath is a regular expression</param>
        /// <returns></returns>
        public int GetPageViewsForPagePath(string pagePath, DateTime startDate, DateTime endDate, bool isPathAbsolute = true)
        {
            int output = 0;

            // GA Data Feed query uri.
            String baseUrl = "https://www.googleapis.com/analytics/v3/data/realtime";

            DataQuery query = new DataQuery(baseUrl);
            query.Ids = TableID;
            //query.Dimensions = "ga:source,ga:medium";
            query.Metrics = "ga:pageviews";
            //query.Segment = "gaid::-11";
            var filterPrefix = isPathAbsolute ? "ga:pagepath==" : "ga:pagepath=~";
            query.Filters = filterPrefix + pagePath;
            //query.Sort = "-ga:visits";
            //query.NumberToRetrieve = 5;
            query.GAStartDate = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            query.GAEndDate = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            Uri url = query.Uri;
            DataFeed feed = analyticsService.Query(query);
            output = Int32.Parse(feed.Aggregates.Metrics[0].Value);

            return output;
        }
        public int GetActiveUsers()
        {
            int output = 0;

            // GA Data Feed query uri.
            String baseUrl = "https://www.googleapis.com/analytics/v3/data/realtime";

            DataQuery query = new DataQuery(baseUrl);
            query.Ids = TableID;
            //query.Dimensions = "ga:source,ga:medium";
            query.Metrics = "rt:activeUsers";
            //query.Segment = "gaid::-11";
            //  var filterPrefix = isPathAbsolute ? "ga:pagepath==" : "ga:pagepath=~";
            // query.Filters = filterPrefix + pagePath;
            //query.Sort = "-ga:visits";
            //query.NumberToRetrieve = 5;
            //  query.GAStartDate = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            //  query.GAEndDate = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            Uri url = query.Uri;
            DataFeed feed = analyticsService.Query(query);
            output = Int32.Parse(feed.Aggregates.Metrics[0].Value);

            return output;
        }
        public Dictionary<string, int> PageViewCounts(string pagePathRegEx, DateTime startDate, DateTime endDate)
        {
            // GA Data Feed query uri.
            String baseUrl = "https://www.google.com/analytics/feeds/data";

            DataQuery query = new DataQuery(baseUrl);
            query.Ids = TableID;
            query.Dimensions = "ga:pagePath";
            query.Metrics = "ga:pageviews";
            //query.Segment = "gaid::-11";
            var filterPrefix = "ga:pagepath=~";
            query.Filters = filterPrefix + pagePathRegEx;
            //query.Sort = "-ga:visits";
            //query.NumberToRetrieve = 5;
            query.GAStartDate = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            query.GAEndDate = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            Uri url = query.Uri;
            DataFeed feed = analyticsService.Query(query);

            var returnDictionary = new Dictionary<string, int>();
            foreach (var entry in feed.Entries)
                returnDictionary.Add(((DataEntry)entry).Dimensions[0].Value, Int32.Parse(((DataEntry)entry).Metrics[0].Value));

            return returnDictionary;
        }
    }
}