using NUnit.Framework;
using pkatu_pipeline_assignment;
using pkatu_pipeline_assignment.Services;

namespace pkatu_pipeline_assignment_tests
{
    public class Tests
    {
        private CalcService _calcService;

        [SetUp]
        public void Setup()
        {
           
            _calcService = new CalcService();
        }

        [Test]
        public void Test1()
        {
            // Call the method
            double result = _calcService.GetSquareRoot(150);

            // Assert that the method returns the expected number
            Assert.That(result, Is.EqualTo(12.24744871391589), "The method did not return the expected number.");
        }
    }
}