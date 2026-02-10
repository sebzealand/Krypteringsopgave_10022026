
PersonRepository repo = new PersonRepository();

var persons = await repo.GetAllAsync();

foreach (var p in persons)
{
    Console.WriteLine(p.First_name);
}

var person = new Person();
person.First_name = "John";
person.Last_name = "Doe";
person.Address = "Somewhere";
person.Street_number = "123";
person.Password = "Test";
person.Enabled = true;

var person2 = await repo.CreatePerson(person);

var getperson = await repo.GetById(2);

Console.WriteLine(getperson.First_name);  





