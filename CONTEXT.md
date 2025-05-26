# CONTEXT.md for BenBrougher.Tech.AsyncLinq

## Build/Test Commands
- Build project: `dotnet build`
- Run all tests: `dotnet test`
- Run specific test: `dotnet test --filter "FullyQualifiedName=BenBrougher.Tech.AsyncLinq.Tests.ExtensionsTests.SelectAsyncTest"`
- Pack for NuGet: `dotnet pack`

## Code Style Guidelines
- **Formatting**: Braces on new lines, 4-space indentation
- **Nullability**: Enable nullable reference types (`<Nullable>enable</Nullable>`)
- **Naming**: PascalCase for public members, camelCase for parameters
- **Error Handling**: Throw ArgumentNullException for null parameters
- **Returns**: Use ToArray() for IEnumerable returns to ensure immediate evaluation
- **Types**: Use explicit types when possible
- **Extensions**: Follow LINQ-like pattern for extension methods
- **Tests**: Use MSTest with descriptive test names and proper assertions