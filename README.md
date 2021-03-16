# Selenium-Herokuapp-Framework

Repository featuring a C# .NET Core Selenium automated testing framework that has been designed to test the http://the-internet.herokuapp.com website. This website under test, or otherwise more generally referred to as the system under test (SUT), has been selected for featuring a healthy selection of pages that have been deliberately designed to [capture prominent and ugly functionality found on the web](https://github.com/saucelabs/the-internet). The framework supports the execution of standard automated tests and Behaviour-Driven Development (BDD) tests in the Google Chrome and Mozilla Firefox web browsers.

## Framework Design

### Class Diagram

<img src="images/class-diagram.png" width="100%" height="100%">

### Page Object Model

The framework has been designed with conformity to the Page Object Model (POM), a commonly used design pattern when forming Selenium automated tests. It consists of a central object repository to model the SUT where each tested page is mapped to its own individual page object class. These page objects then define and hold `private` properties to correspond to the many web elements of the page, and `public` methods to describe how an end user is expected to interact with a given element. This design pattern allows for page objects to be modified in isolation without concern for affecting the other components of the system.

Ultimately speaking, the POM provides a modular framework that reduces code duplication whilst simultaneously strengthening desirable system aspects for collaboration and development such as readability, reusability, scalability, and extensibility. It should be noted that [the typically packaged Selenium PageFactory class has been depreciated in C# due to being redundant when compared to C# properties](https://alexanderontesting.com/2018/05/21/c-and-the-disappearing-pagefactory-my-next-steps-in-selenium-testing/). Henceforth, a custom `PageFactory.cs` class has been created to serve as the central object repository for the framework. Additionally, the Selenium WebDriver tool that supplys the automated web testing functionality for the framework is initialised in this repository as a customisable `IWebDriver` property that can be freely configured from within the `DriverConfig.cs` class.

### Inheritance

All visitable pages of the SUT inherit from the abstract `WebPage.cs` class. It consists of `protected` attributes which forms a template that lists the common features that are shared across all visitable pages. This class holds a critical read-only `IWebDriver` property that can only be shared to its derived pages through the use of its constructor. This design decision not only reduces the need to repeatedly create `IWebDriver` field definitions for all of the derived pages, but it also optimises test execution time by ensuring that these pages can only ever rely on a single instance of an `IWebDriver` at any given time. Lastly, the class holds a simple `NavigateToUrl()` method to standardise the methodology in which the pages are accessed when directly navigating to them via their url.

### Composition

All visitable pages of the SUT implement an interface of either `IAlertNagivation.cs` or `IPageNavigation.cs`. Both interfaces hold methods which serve as wrappers for the inherited `NavigateToUrl()` method. The `IAlertNavigation` interface is applied to any visitable page whose access is blocked by an authentication alert, and the `IPageNavigation` interface is applied to all of the other visitable pages. Ideally, a single `IPageNavigation` interface should ever be used for the framework, but there is currently a Selenium issue with authentication alerts where keyboard information can not be directly passed into the authentication fields of the alert pop-up. Having identified this, the `IAlertNavigation` interface is a temporary workaround that serves to mimic page navigation behaviours for instances where a standard url string is insufficient.

### Drivers

The type of the Selenium WebDriver used in the framework can be globally controlled in the `StaticDriver.cs` class. The class holds private fields corresponding to the two currently supported types of web drivers (`ChromeDriver` for Google Chrome and `FirefoxDriver` for Mozilla FireFox) and a read-only `Type` property that determines the driver type to be executed against when running the automated tests. The `Type` property is set to use the `ChromeDriver` by default and this can be modified to instead use the `FirefoxDriver` by changing the property's assignment field. The `PageFactory.cs` class deliberately does not specify a default value for the `IWebDriver` to then be passed into the `DriverConfig.cs` class to ensure that the assignment of the `IWebDriver` can only exist and be modified from one single source.

## Testing

The framework's test suite uniquely supports the execution of standard automated tests written in NUnit and BDD tests written in SpecFlow. These have been created to aid a learning exercise which focuses on understanding the implementation differences and the advantages and disadvantages each approach bears against one another. My findings are as follows: 

### Test Suite Comparison

| Attribute       | Standard | BDD      |
|---------------- | -------- | -------- |
| Writing Speed   | Faster   | Slower   |
| Execution Speed | Faster   | Slower   |
| Readability     | Weaker   | Stronger |
| Reusability     | Weaker   | Stronger |

#### Writing Speed

This attribute assesses the time and effort required to write a given test. One of the immediate advantages standard tests have over BDD tests is that only one testing file is ever required to test a given page whereas BDD will require two for a feature and steps file respectively. Standard tests gain further strength in this attribute with their sole focus for only defining the technical implementation of a test. BDD tests are required to also describe the implementation details of a test in their feature files in addition to the technical implementation itself which they define within an appropriate steps file.

#### Execution Speed

This attribute assesses the time taken for the test suite to run its tests. Logically speaking, these should be equal given that they are testing the exact same thing in the exact same way but there is an unfortunate restriction with SpecFlow hooks which prevents this from being the case. The tests in the standard testing suite rely on a single instance of the driver for all of the tests in a given test class by using the `[OneTimeSetUp]` and `[OneTimeTearDown]` attributes. Hooks do support attributes that achieve this same effect yet their compatibility is oddly restricted to only support static methods. Consequently, the BDD test suite has been forced to rely on the `[BeforeScenario]` and `[AfterScenario]` hooks (defined in the `ScenarioHooks.cs` file) which results in a new driver instance being created and disposed of for each scenario (test) that is run, slowing down the overall execution speed of the suite.

### Readability

- Feature files
- User stories
- Gherkin

### Reusability

- Reusability of steps

### Other Notes

`IAlert` authentication access issues
- `ChromeDriver` cannot interact with elements
- `FirefoxDriver` can `Accept()` `Dismiss()` but cannot send string information
- Bypass by directly sending credentials via url string
- `MiscellaneousTests.cs` exclusive to regular tests

## Extending the Framework

More pages of sut
Navigation to page
1. Add property to `IndexPage.cs`
2. Add method to `IndexPage.cs`
3. Add IndexPage test to validate page navigation

POM page class setup
1. Add key-value pair to `Testhost.dll.config`
2. Add `static readonly string` property to `ConfigReader.cs`
3. Create a class to represent page in the Pages folder
4. Inherit from `WebPage.cs` and implement either the `IPageNavigation.cs` or `IAlertNavigation.cs` interface
5. Add property to `PageFactory.cs` to reference created class
6. Add property assignment in constructor of `PageFactory.cs` to pass driver to class
7. Reference class in tests using `PageFactory.newPageClass.methods()`

`Static Driver.cs` to switch between drivers
`DriverConfig.cs` to extend common driver configuration

Compatibility for different browsers outside of Chrome and Firefox
