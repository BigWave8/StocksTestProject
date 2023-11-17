# StocksTestProject

A program that calculates 4 important parameters for the user:
- The remaining number of shares after the sale
- The cost basis per share of the sold shares
- The cost basis per share of the remaining shares after the sale
- The total profit or loss of the sale

The parameters depend on his current shares and calculation strategy. For simplicity, only the FIFO strategy is implemented.

The program is built with 3 tier architecture:
Presentation layer
Business layer
Data access layer

## Presentation layer:
- Blazor was chosen for the presentation level. There are displays on web pages that interact with the user and take data from lower levels through Controllers.
- Also, the program itself starts here, so Dependency Injection is used here for all dependencies in the solution.

## Business layer:
- The business layer contains DTOs for data transfer and user interaction.
- Also, it is here in Services that the main logic of the program takes place.
- Here the Strategy pattern is used to calculate in different ways, currently only FIFO is implemented, but the way is paved for simple implementation of other methods without changing unnecessary code.
- Validators for received objects were added, which works through FluentValidation.

## Data access layer:
- Data access layer works through Entire Framework, DBContext and Repository pattern.
- The Repository contains initial hardcoded user data (SeedData)

The project has Unit Testing, which uses NUnit together with Moq and FluentAssertions.
Tests for the existing validator and FIFO strategy are implemented, but there is also a blank for other tests.
