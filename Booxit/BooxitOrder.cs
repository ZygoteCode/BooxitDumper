public class BooxitOrder
{
    public uint ID { get; set; }
    public string NameAndSurname { get; set; }
    public string UserPhoneNumber { get; set; }
    public string MerchantPhoneNumber { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    public string WhatsAppMessage { get; set; }
    public BooxitMerchant BooxitMerchant { get; set; }
    public BooxitUser BooxitUser { get; set; }

    public BooxitOrder(uint id, string nameAndSurname, string userPhoneNumber, string merchantPhoneNumber, string address, string notes, string whatsAppMessage, BooxitMerchant booxitMerchant, BooxitUser booxitUser)
    {
        ID = id;
        NameAndSurname = nameAndSurname;
        UserPhoneNumber = userPhoneNumber;
        MerchantPhoneNumber = merchantPhoneNumber;
        Address = address;
        Notes = notes;
        WhatsAppMessage = whatsAppMessage;
        BooxitMerchant = booxitMerchant;
        BooxitUser = booxitUser;
    }
}