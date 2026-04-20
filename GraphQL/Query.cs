using System.Text.Json;
using System.Text.Json.Serialization;

public class Query
{
    public List<Book> Books(string nameContains="")
    {
        string filename = "Database/books.json";
        string jsonString = File.ReadAllText(filename);
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        });
        return books.Where(b => b.Name.IndexOf(nameContains, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }
}

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(b => b.PublishDate)
            .Type<StringType>()
            .ResolveWith<Resolvers>(r => r.GetFormattedDate(default!));
    }
}
