# Selenium-Herokuapp-Framework

Repository featuring C# .NET Core Selenium automated testing framework which has been designed to test the http://the-internet.herokuapp.com website. This website being tested against, or otherwise more concisely referred to as the system under test (SUT), has been selected for featuring a healthy selection of pages that have been deliberately designed to capture prominent and ugly functionality found on the web. The framework supports the execution of regular automated tests and Behaviour-Driven Development (BDD) tests in the Google Chrome and Mozilla Firefox web browsers.

## Framework Design

### Class Diagram

<img src="images/class-diagram.png" width="100%" height="100%">

### Page Object Model

The framework has been designed with conformity to the Page Object Model (POM), a commonly used design pattern when forming Selenium automated tests. It consists of a central object repository to model the SUT where each tested page is assigned to its own class. These page objects hold `private` properties to correspond to the many web elements of the page, and `public` methods to describe how an end user is expected to interact with a given element. This design allows for pages to be modified in isolation without concern for affecting the other components of the system.

Ultimately speaking, the POM provides a modular framework that reduces code duplication whilst also strengthening desirable system aspects such as readability, scalability, and extensibility. It should be noted that C# was [previously packaged with a PageFactory class that has since been depreciated and replaced by C# properties](https://alexanderontesting.com/2018/05/21/c-and-the-disappearing-pagefactory-my-next-steps-in-selenium-testing/). Henceforth, a custom `PageFactory.cs` class has been created to serve as the central object repository for the framework. Additionally, the Selenium WebDriver tool that is required to automate web testing is created in this repository as a customisable `IWebDriver` property that can be further configured in the `DriverConfig.cs` class.

### Inheritance

All visitable pages of the SUT inherit from the abstract `WebPage.cs` class. It consists of `protected` attributes to form a template that stores and defines the common features shared across all visitable pages. This class holds a critical read-only `IWebDriver` property that is shared to its derived pages through the use of its constructor. This design decision not only reduces the need to repeatedly create `IWebDriver` definitions in derived pages, but it also optimises test execution time by ensuring that these pages can only ever rely on a single instance of an `IWebDriver` at any given time. Lastly, the class holds a simple `NavigateToUrl()` method to standardise the methodology in which the pages are accessed via url navigation.

### Composition

`IAlertNavigation.cs` interface for pages requiring credential authentication with an authentication alert.
`IPageNavigation.cs` interface for non-authentication alert pages.

### Drivers

`Static Driver.cs`
`ChromeDriver` default
`FireFoxDriver`

## Testing

Comparison

### Regular tests

- Faster to construct
- Faster to run
- Less readable

### BDD tests

- Feature and step files
- Slower to construct
- Slower to run
- Reusability of steps
- More readable (Gherkin)

### General

`IAlert` authentication access issues
- `ChromeDriver` cannot interact with elements
- `FirefoxDriver` can `Accept()` `Dismiss()` but cannot send string information
- Bypass by directly sending credentials via url string
- `MiscellaneousTests.cs` exclusive to regular tests

## Extending the framework

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
