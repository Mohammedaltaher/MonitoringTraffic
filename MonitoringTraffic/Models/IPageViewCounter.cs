using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    //public interface IPageViewCounter
    //{
    //    int GetPageViewCount(string relativeUrl, DateTime startDate, DateTime endDate, bool isPathAbsolute = true);
    //    int GetActiveUsers();
    //    Dictionary<string, int> PageViewCounts(string pagePathRegEx, DateTime startDate, DateTime endDate);
    //}

    public class GooglePageViewCounter 
    {
        private string GoogleUserName
        {
            get
            {
                return "mohammedaltaher1254@gmail.com"; //ConfigurationManager.AppSettings["googleUserName"];
            }
        }

        private string GooglePassword
        {
            get
            {
                return "moh12548787";  //ConfigurationManager.AppSettings["googlePassword"];
            }
        }

        private string GoogleAnalyticsTableName
        {
            get
            {
                return "228149325"; //ConfigurationManager.AppSettings["googleAnalyticsTableName"];
            }
        }

        public object Logger { get; private set; }

        private GoogleAnalyticsApi analytics;

        public GooglePageViewCounter()
        {
            analytics = new GoogleAnalyticsApi(GoogleUserName, GooglePassword, GoogleAnalyticsTableName);
        }

        #region IPageViewCounter Members

        public int GetPageViewCount(string relativeUrl, DateTime startDate, DateTime endDate, bool isPathAbsolute = true)
        {
            int output = 0;
            try
            {
                output = analytics.GetPageViewsForPagePath(relativeUrl, startDate, endDate, isPathAbsolute);
            }
            catch (Exception ex)
            {
              //  Logger.Error(ex);
            }

            return output;
        }
        public int GetActiveUsers()
        {
            int output = 0;
            try
            {
                output = analytics.GetActiveUsers();
            }
            catch (Exception ex)
            {
                //  Logger.Error(ex);
            }

            return output;
        }
        public Dictionary<string, int> PageViewCounts(string pagePathRegEx, DateTime startDate, DateTime endDate)
        {
            var input = analytics.PageViewCounts(pagePathRegEx, startDate, endDate);
            var output = new Dictionary<string, int>();

            foreach (var item in input)
            {
                if (item.Key.Contains('&'))
                {
                    string[] key = item.Key.Split(new char[] { '?', '&' });
                    string newKey = key[0] + "?" + key.FirstOrDefault(k => k.StartsWith("p="));

                    if (output.ContainsKey(newKey))
                        output[newKey] += item.Value;
                    else
                        output[newKey] = item.Value;
                }
                else
                    output.Add(item.Key, item.Value);
            }
            return output;
        }

        #endregion
    }
}