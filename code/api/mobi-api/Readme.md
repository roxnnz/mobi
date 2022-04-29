### Initial DB test env
Run:
`dotnet ef migrations add InitialCreate`
and 
`dotnet ef database update`

### Using test data generation APIs.

The put APIs has been created for generate test data for stores and products. 

To use the API just make put call to /generate/testdata/products and generate/testdata/stores which described in DevelopmentController.cs

