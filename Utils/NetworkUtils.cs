using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

public class NetworkUtils
{
    public static byte[] ReadResponseStream(Stream input)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }

    public static string TakeHostFromURI(string uri)
    {
        if (uri.StartsWith("http://"))
        {
            uri = uri.Substring("http://".Length);
        }

        if (uri.StartsWith("https://"))
        {
            uri = uri.Substring("https://".Length);
        }

        if (uri.StartsWith("www."))
        {
            uri = uri.Substring("www.".Length);
        }

        if (uri.Contains("/"))
        {
            return uri.Split('/')[0];
        }
        else if (uri.Contains("?"))
        {
            return uri.Split('?')[0];
        }
        else if (uri.Contains("&"))
        {
            return uri.Split('&')[0];
        }

        return uri;
    }

    public static byte[] GetHttpData(string uri)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
        FieldInfo fieldInfo = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

        CustomWebHeaderCollection customWebHeaderCollection = new CustomWebHeaderCollection(new Dictionary<string, string>
        {
            ["Host"] = TakeHostFromURI(uri)
        });

        httpWebRequest.Proxy = null;
        httpWebRequest.UseDefaultCredentials = false;
        httpWebRequest.AllowAutoRedirect = false;
        httpWebRequest.Timeout = 70000;
        httpWebRequest.Method = "GET";
        fieldInfo.SetValue(httpWebRequest, customWebHeaderCollection);

        WebResponse webResponse = httpWebRequest.GetResponse();
        byte[] webResponseData = ReadResponseStream(webResponse.GetResponseStream());

        webResponse.Close();
        webResponse.Dispose();

        return webResponseData;
    }
}