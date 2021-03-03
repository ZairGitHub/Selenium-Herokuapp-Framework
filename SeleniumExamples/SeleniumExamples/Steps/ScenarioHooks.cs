using BoDi;
using TechTalk.SpecFlow;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer _container;

        public ScenarioHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _container.RegisterInstanceAs(new PageFactory(StaticDriver.Type));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _container.Resolve<PageFactory>().CloseDriver();
        }
    }
}
