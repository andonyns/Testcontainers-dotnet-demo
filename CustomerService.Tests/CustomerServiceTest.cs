namespace CustomerService.Tests;

public sealed class CustomerServiceTest
{

    // Requires a previously setup database
    private readonly string conn = "Server=localhost;Port=5432;User Id=postgres;Password=pass;Database=customer;";

    [Fact]
    public void ShouldReturnTwoCustomers()
    {
        // Given
        var customerService = new CustomerService(new DbConnectionProvider(conn));

        // When
        customerService.Create(new Customer(1, "George"));
        customerService.Create(new Customer(2, "John"));
        var customers = customerService.GetCustomers();

        // Then
        Assert.Equal(2, customers.Count());

        // Should clean data after test
    }
}