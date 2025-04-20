using Microsoft.VisualBasic;
using System;

public class Program
{
    private static BooxitMerchantManager _booxitMerchantManager;

    public static void Main()
    {
        _booxitMerchantManager = new BooxitMerchantManager();

        

        Console.ReadLine();
    }

    public static void ProcessOrder(uint orderNumber)
    {
        string webResponseContent = NetworkUtils.GetHttpData($"https://booxit.it/order/success?order={orderNumber}").ToUtf8String();
        string[] splitted = Strings.Split(webResponseContent, "<meta name=\"application-name\" content=\"");
        string applicationName = splitted[1].Split('\"')[0];

        splitted = Strings.Split(webResponseContent, "/menu'\"");
        splitted = Strings.Split(splitted[0], "; location.href='");
        string menuLink = splitted[1] + "/menu/";

        splitted = Strings.Split(webResponseContent, "_thumbnail.jpg\">");
        splitted = Strings.Split(splitted[0], "<link rel=\"icon\" type=\"image/png\" href=\"https://");
        string imageLink = "https://" + splitted[1] + "_thumbnail.jpg";

        splitted = Strings.Split(menuLink, "https://booxit.it/app/");
        splitted = Strings.Split(splitted[1], "/menu/");
        string slug = splitted[0];

        if (!_booxitMerchantManager.IsBooxitMerchantExisting(applicationName))
        {
            string manifestLink = $"https://booxit.it/app/{slug}/manifest.json";
            string manifestContent = NetworkUtils.GetHttpData(manifestLink).ToUtf8String();
            byte[] imageData = NetworkUtils.GetHttpData(imageLink);

            BooxitMerchant booxitMerchant = new BooxitMerchant
            (
                applicationName,
                "",
                slug,
                menuLink,
                imageLink,
                imageData,
                imageData.ToImage(),
                manifestLink,
                manifestContent,
                manifestContent.BeautifyJSON()
            );

            _booxitMerchantManager.AddBooxitMerchant(booxitMerchant);
            Console.WriteLine("fatto!");
        }
    }

    public static string GetWhatsAppMessage(uint orderNumber)
    {
        string webResponseContent = NetworkUtils.GetHttpData($"https://booxit.it/order/success?order={orderNumber}&whatsapp=yes").ToUtf8String();
        string[] splitted = Strings.Split(webResponseContent, "<meta http-equiv=\"refresh\" content=\"0;url='");
        splitted = Strings.Split(splitted[1], "'\" />");

        string entireUrl = splitted[0];
        splitted = Strings.Split(entireUrl, "https://api.whatsapp.com/send?phone=");
        splitted = Strings.Split(splitted[1], "&amp;");
        string receiverPhoneNumber = splitted[0];

        entireUrl = entireUrl.Replace($"https://api.whatsapp.com/send?phone={receiverPhoneNumber}&amp;text=", "");

        string unescapedDataString = Uri.UnescapeDataString(entireUrl).Replace("+", " ");
        string filteredString = unescapedDataString.Filter().Replace("&quot;", "\"");

        return filteredString;
    }
}