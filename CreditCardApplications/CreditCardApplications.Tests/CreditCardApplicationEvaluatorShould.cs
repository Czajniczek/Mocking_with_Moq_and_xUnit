using Xunit;

namespace CreditCardApplications.Tests
{
    public class CreditCardApplicationEvaluatorShould
    {
        [Fact]
        public void AcceptHighIncomeApplications()
        {
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = 100_000
            };

            var sut = new CreditCardApplicationEvaluator();
            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);
        }

        [Fact]
        public void ReferYoungApplications()
        {
            var application = new CreditCardApplication
            {
                Age = 19
            };

            var sut = new CreditCardApplicationEvaluator();
            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }
    }
}
