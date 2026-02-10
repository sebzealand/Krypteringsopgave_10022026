using System.Threading.Tasks;
using Xunit;

public class UnitTests 
{
    [Fact]
    public async Task GetById_Pass()
    {
        // Given
        // Givet at der findes et objekt med id = 1
        PersonRepository repo = new PersonRepository();
        var persons = await repo.GetAllAsync()
        // When
        // Når vi kører funktionen GetById
        var person = await repo.GetById(1)

        // Then
        Assert.Equal(person.Person_id, 1)
    }
}
