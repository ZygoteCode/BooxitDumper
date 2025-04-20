using System.Collections.Generic;

public class BooxitUser
{
    public string NameAndSurname { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public List<BooxitOrder> Orders { get; set; }

    public BooxitUser(string nameAndSurname, string address, string phoneNumber, List<BooxitOrder> orders)
    {
        NameAndSurname = nameAndSurname;
        Address = address;
        PhoneNumber = phoneNumber;
        Orders = orders;
    }
}