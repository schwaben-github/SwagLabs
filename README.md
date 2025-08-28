# Testing Swag Labs site with SpecFlow and Selenium WebDriver

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)  ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)  ![Selenium](https://img.shields.io/badge/-selenium-%43B02A?style=for-the-badge&logo=selenium&logoColor=white)  ![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

---

### SwagLabsTestAutomation

This repository contains UI automation tests for the Swag Labs site using SpecFlow, Selenium WebDriver, and NUnit on .NET 8.

### Project Structure

```
SwagLabsTestAutomation/
├── Drivers/
│   └── WebDriverContext.cs         # WebDriver setup and teardown
├── Features/
│   └── Login.feature               # Gherkin feature file(s)
│   └── Products.feature            # Gherkin feature file(s)
├── Pages/
│   ├── BasePage.cs                # Page Object for foundational methods
│   └── LoginPage.cs               # Page Object for Login page
│   └── Products Page.cs           # Page Object for Products page
├── StepDefinitions/
│   ├── LoginSteps.cs              # Step definitions for Login feature
│   └── ProductsSteps.cs           # Step definitions for products feature
├── Hooks.cs                       # SpecFlow hooks for scenario setup/teardown
├── SwagLabsTestAutomation.csproj
└── ...
```

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Chrome browser](https://www.google.com/chrome/) (latest version recommended)
- ChromeDriver is managed automatically via NuGet

### How to Run the Tests

1. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

2. **Build the project:**
   ```sh
   dotnet build
   ```

3. **Run the tests:**
   ```sh
   dotnet test
   ```
This will launch Chrome, maximize the window, and execute the SpecFlow scenarios.


### ...or simply use the Visual Studio Test Explorer and hotkeys

1. Open the solution in Visual Studio

2. Restore NuGet packages (right-click on the solution in Solution Explorer > Restore NuGet Packages)

3. Build the solution (`Ctrl + Shift + B`)

4. Open the Test Explorer (Test > Windows > Test Explorer) and select the test you want to run and click on "Run" button


### Notes
- The tests use SpecFlow with NUnit and Selenium WebDriver.
- The browser window is maximized automatically at the start of the scenario.
- All WebDriver setup and disposal is handled in `WebDriverContext` and `Hooks.cs`.
- Feature files are located in the `Features/` directory and step definitions in `Steps/`.
- Page Objects are in the `Pages/` directory.


### Troubleshooting
- Ensure your Chrome browser is up to date to match the ChromeDriver version.
- If you encounter issues with element selectors, check the HTML structure and update the Page Object selectors accordingly.
- For headless execution, you can modify `WebDriverContext` to add ChromeOptions with headless mode.

---

## SpecFlow LivingDoc HTML Report

### How to Generate the LivingDoc HTML Report

1. **Run your tests:**
```sh
dotnet test
```

This will generate a test execution JSON file (usually in the `TestResults` folder).

2. **Install the LivingDoc CLI tool (if not already installed):**
```sh
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

Or update it:

```sh
dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI
```

3. **Generate the HTML report:**

```sh
livingdoc test-assembly bin\Debug\net8.0\SwagLabsTestAutomation.dll -t bin\Debug\net8.0\TestExecution.json -o LivingDoc.html
```

This will create a `LivingDoc.html` file in your current directory.


### What is LivingDoc?
- LivingDoc is a rich HTML report for SpecFlow projects.
- It shows feature files, scenarios, step results, and execution details in a user-friendly format.

### Notes
- You must run your tests first so that the execution data is available.
- The generated `LivingDoc.html` can be opened in any browser and shared with your team.
- For more options, see the [SpecFlow LivingDoc documentation](https://docs.specflow.org/projects/livingdoc/en/latest/).

---

## PhotoGalleryTestAutomation

### Automated LivingDoc Generation

This project uses SpecFlow with .NET 8 and generates LivingDoc documentation for your BDD scenarios.

### How to Run Tests and Generate LivingDoc

1. **Run the provided script:**
   - Use the `run-tests-with-livingdoc.bat` script in the root directory to run your tests and automatically generate the LivingDoc HTML report.
   - The script will:
     - Run all tests in the `SwagLabsTestAutomation` project.
     - Generate `TestExecution.json` (required for LivingDoc).
     - Create/update `LivingDoc.html` in the `SwagLabsTestAutomation` directory.

   **Usage:**
   ```cmd
   run-tests-with-livingdoc.bat
   ```

2. **View the documentation:**
   - Open `SwagLabsTestAutomation\LivingDoc.html` in your browser to see the latest LivingDoc report.

### Requirements
- .NET 8 SDK
- LivingDoc CLI installed globally:
  ```cmd
  dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
  ```
- Chrome browser (for Selenium tests)

### Notes
- The LivingDoc will not be generated automatically by `dotnet test` alone. Always use the provided script for full automation.
- If you add or change features, simply re-run the script to update the documentation.

---

Feel free to contribute or open issues for improvements!
