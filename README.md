# Selenium-Example-Framework

Repository featuring C# .NET Core Selenium automated testing framework which has been designed to test the http://the-internet.herokuapp.com website. This website being tested against, or otherwise more concisely referred to as the system under test (SUT), has been selected for featuring a healthy selection of pages that have been deliberately designed to capture prominent and ugly functionality found on the web. The framework supports the execution of regular automated tests and Behaviour-Driven Development (BDD) tests in the Google Chrome and Mozilla Firefox web browsers.

## Framework Design

### Class Diagram

<img src="images/class-diagram.png" width="100%" height="100%">

### Page Object Model

Page Object Model (POM) design pattern. Modular design, scalable framework, smoother maintainence. Model pages as classes controlled and managed by a central page object. Custom `PageFactory.cs` class. [Previously packaged PageFactory class depreciated in C# due to properties](https://alexanderontesting.com/2018/05/21/c-and-the-disappearing-pagefactory-my-next-steps-in-selenium-testing/) but still exists in other languages which do not support properties such as Java.

### Inheritance

All visitable pages of the SUT inherit from abstract `WebPage.cs` class. Ensures pages only ever rely a single instance of an `IWebDriver` to optimise test execution time. Also contains a `NavigateToUrl()` method to standardise page navigation across all derived pages.

## Composition

`IAlertNavigation.cs` interface for pages requiring credential authentication with an authentication alert.
`IPageNavigation.cs` interface for non-authentication alert pages.

### Drivers

`Static Driver.cs`
`ChromeDriver` default
`FireFoxDriver`

## Testing

Comparison

### Regular tests

Faster to construct
Faster to run
Less readable

### BDD tests

Feature and step files
Slower to construct
Slower to run
Reusability of steps
More readable (Gherkin)

### General

`IAlert` authentication access issues
- `ChromeDriver` cannot interact with elements
- `FirefoxDriver` can `Accept()` `Dismiss()` but cannot send string information
- Bypass by directly sending credentials via url string
- `MiscellaneousTests.cs` exclusive to regular tests

### Extending framework

POM

More pages of sut
1. Add property to `IndexPage.cs`
2. Add method to `IndexPage.cs`
3. Add IndexPage test to validate page navigation

1. Add key to `Testhost.dll.config`
2. Add property to `ConfigReader.cs`
3. Create a class to represent page
4. Inherit from `WebPage.cs` and implement either the `IPageNavigation` or `IAlertNavigation` interface
5. Add property to `PageFactory.cs` to reference created class
6. Add property assignment in constructor of `PageFactory.cs`
7. Reference class in tests using `PageFactory.newPageClass.methods()`

`Static Driver.cs` to switch between drivers
`DriverConfig.cs` to extend common driver configuration

