namespace CreditCardApplications
{
    public class CreditCardApplication //Wniosek o kartę kredytową
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal GrossAnnualIncome { get; set; } //Roczny dochód brutto

        public string FrequentFlyerNumber { get; set; } //Numer frequent flayer
    }
}
