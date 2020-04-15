using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.TimeConverters;
using BerlinClock.IoC;
using Autofac;

namespace BerlinClock.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter _berlinClock;
        private string _theTime;

        [BeforeScenario]
        public void Initiate()
        {
            var container = IoCContainer.RegisterDependencies();
            _berlinClock = container.Resolve<ITimeConverter>();
        }

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, _berlinClock.ConvertTime(_theTime));
        }

    }
}
