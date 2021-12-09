namespace CreditCardApplications
{
    public enum CreditCardApplicationDecision : byte
    {
        Unknown = 0, //Wynik wniosku nie jest jeszcze znany
        AutoAccepted = 1, //Wniosek został automatycznie zaakceptowany przez system
        AutoDeclined = 2, //Wniosek został automatycznie odrzucony przez system
        ReferredToHuman = 3, //Wniosek musi zostać skierowany do człowieka
        ReferredToHumanFraudRisk = 4
    }
}
