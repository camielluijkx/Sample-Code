namespace LISTING_2_31_Protected_class
{
    class BankAccount
    {
        protected class Address
        {
            public string FirstLine;
            public string Postcode;
        }

        protected decimal accountBalance = 0;
    }

    class OverdraftAccount : BankAccount
    {
        decimal overdraftLimit = 100;

        Address GuarantorAddress;
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}