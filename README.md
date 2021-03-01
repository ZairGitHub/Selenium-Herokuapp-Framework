# Selenium-Example-Framework

## Introduction

System under test

## Design

All pages inherit from `WebPage.cs`
Page structure (common methods and contract implementation)

### POM

Page Object Model
PageFactory class depreciated
`PageFactory.cs`

### Class Diagram

### Drivers

`Static Driver.cs`
`ChromeDriver` default
`FireFoxDriver`

## Testing

Comparison

### NUnit tests

Faster to construct
Faster to run
Less readable

### SpecFlow

Feature files
Slower to construct
Slower to run
Reusability of steps
More readable

### General

`IAlert` authentication access issues
- `ChromeDriver` cannot interact with elements
- `FirefoxDriver` can `Accept()` `Dismiss()` but cannot send string information
- Bypass by directly sending credentials via url string

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

