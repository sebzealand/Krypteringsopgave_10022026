
PersonRepository repo = new PersonRepository("data/flat_file_db.json");

var persons = await repo.GetAllAsync();

foreach (var p in persons)
{
    Console.WriteLine(p.first_name);
}
