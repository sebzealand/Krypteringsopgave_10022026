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
        var persons = await repo.GetAllAsync();
        // When
        // Når vi kører funktionen GetById
        var person = await repo.GetById(1);

        // Then (expected, result)
        Assert.Equal(1, person.Person_id);
    }
}
