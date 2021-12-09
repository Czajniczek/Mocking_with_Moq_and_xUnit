using Moq;
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

            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
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

            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }

        [Fact]
        public void DeclineLowIncomeApplications()
        {
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = 19_999,
                Age = 42,
                FrequentFlyerNumber = "y"
            };

            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
            //mockValidator.Setup(x => x.IsValid("x")).Returns(true);
            //mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            //mockValidator.Setup(x => x.IsValid(It.Is<string>(number => number.StartsWith("y")))).Returns(true);
            //mockValidator.Setup(x => x.IsValid(It.IsInRange("a","z",Range.Inclusive))).Returns(true);
            //mockValidator.Setup(x => x.IsValid(It.IsIn("x", "y", "z"))).Returns(true);
            mockValidator.Setup(x => x.IsValid(It.IsRegex("[a-z]"))).Returns(true);
            
            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }

        [Fact]
        public void ReferInvalidFrequentFlyerApplications()
        {
            var application = new CreditCardApplication();

            var mockValidator = new Mock<IFrequentFlyerNumberValidator>(MockBehavior.Strict);
            //mockValidator.Setup(x => x.ServiceInformation.License.LicenseKey).Returns("OK");
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }
    }
}
