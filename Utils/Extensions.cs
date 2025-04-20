using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.IO;
using System.Text;

public static class Extensions
{
    private static char[] _characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"£$%&/()=?^'ì\\|èé[{+*}]à°#òç@ù§-_:.,;<>\n\r\t €".ToCharArray();

    public static string ToUtf8String(this byte[] data)
    {
        return Encoding.UTF8.GetString(data);
    }

    public static Image ToImage(this byte[] data)
    {
        using (MemoryStream memoryStream = new MemoryStream(data))
        {
            return Image.FromStream(memoryStream);
        }
    }

    public static string Filter(this string str)
    {
        string result = "";

        foreach (char c in str)
        {
            foreach (char s in _characters)
            {
                if (c.Equals(s))
                {
                    result += s;
                    break;
                }
            }
        }

        return result;
    }

    public static string BeautifyJSON(this string str)
    {
        return JToken.Parse(str).ToString(Formatting.Indented);
    }
}