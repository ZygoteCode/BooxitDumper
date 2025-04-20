using System.Collections.Generic;
using System.Drawing;

public class BooxitMerchant
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Slug { get; set; }
    public string MenuLink { get; set; }
    public string ImageLink { get; set; }
    public byte[] ImageData { get; set; }
    public Image Image { get; set; }
    public string ManifestLink { get; set; }
    public string ManifestContent { get; set; }
    public string BeautifiedManifestContent { get; set; }
    public List<BooxitOrder> BooxitOrders { get; set; }

    public BooxitMerchant(string name, string phoneNumber, string slug, string menuLink, string imageLink, byte[] imageData, Image image, string manifestLink, string manifestContent, string beautifiedManifestContent)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Slug = slug;
        MenuLink = menuLink;
        ImageLink = imageLink;
        ImageData = imageData;
        Image = image;
        ManifestLink = manifestLink;
        ManifestContent = manifestContent;
        BeautifiedManifestContent = beautifiedManifestContent;
        BooxitOrders = new List<BooxitOrder>();
    }
}