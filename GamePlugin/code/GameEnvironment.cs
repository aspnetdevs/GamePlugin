using System;
using System.Net;
using System.ServiceModel;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GamePlugin
{
    public static class GameEnvironment
    {
        public static string gameId;
        public static string userId;
        public static int currentMoveNumber = 0;
        public static void SetDefaultProperties()
        {
            gameId = GetQueryStringItemValue("gameId", HtmlPage.Document.DocumentUri.Query);
            userId = GetQueryStringItemValue("userId", HtmlPage.Document.DocumentUri.Query);
        }

        private static string GetQueryStringItemValue(string queryStringItemName, string queryString)
        {
            int itemIndex = queryString.IndexOf(queryStringItemName);
            if (itemIndex != -1)
            {
                queryString = queryString.Substring(itemIndex);
                queryString = queryString.Substring(queryString.IndexOf("=") + 1);
                if (queryString.IndexOf("&") != -1)
                    return queryString.Substring(0, queryString.IndexOf("&"));
                else
                    return queryString;
            }
            else
                throw new Exception("Элемент с таким именем не найден");
        }

        public static double GetAngleBetweenPoints(Point startPoint, Point endPoint)
        {
            double xDiff = endPoint.X - startPoint.X;
            double yDiff = endPoint.Y - startPoint.Y;
            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
        }
        public static double GetLengthBetweenPoints(Point startPoint, Point endPoint)
        {
            double xDiff = endPoint.X - startPoint.X;
            double yDiff = endPoint.Y - startPoint.Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
    }
}
