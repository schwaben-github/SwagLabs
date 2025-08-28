# Run SpecFlow tests and generate LivingDoc report

dotnet test

# Find the test execution JSON (SpecFlow default output)
$testExecution = Get-ChildItem -Recurse -Filter TestExecution.json | Select-Object -First 1

if ($testExecution -eq $null) {
    Write-Host "TestExecution.json not found. Make sure your tests ran and SpecFlow is configured."
    exit 1
}

# Find the test assembly (DLL)
$dll = Get-ChildItem -Recurse -Filter SwagLabsTestAutomation.dll | Where-Object { $_.FullName -like '*bin*' } | Select-Object -First 1

if ($dll -eq $null) {
    Write-Host "Test assembly DLL not found. Build and test your project first."
    exit 1
}

# Generate LivingDoc HTML report
livingdoc test-assembly $dll.FullName -t $testExecution.FullName

Write-Host "LivingDoc report generated."
