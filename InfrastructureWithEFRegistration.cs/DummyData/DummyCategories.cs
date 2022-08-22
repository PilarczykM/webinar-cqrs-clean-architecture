using Domain.Entities;

namespace InfrastructureWithEFRegistration.cs.DummyData;

public class DummyCategories
{
    public static List<Category> Get()
    {
        Category c1 = new()
        {
            CategoryId = DummySeed.Csharp,
            Name = "CSharp",
            DisplayName = "C#"
        };

        Category c2 = new()
        {
            CategoryId = DummySeed.Aspnet,
            Name = "aspnet",
            DisplayName = "ASP.NET"
        };

        Category c3 = new()
        {
            CategoryId = DummySeed.WindowsTricks,
            Name = "triki-z-windows",
            DisplayName = "Triki z Windows"
        };

        Category c4 = new()
        {
            CategoryId = DummySeed.Docker,
            Name = "docker",
            DisplayName = "Docker"
        };

        Category c5 = new()
        {
            CategoryId = DummySeed.Philosophy,
            Name = "filozofia",
            DisplayName = "Filozofia"
        };


        List<Category> p = new()
        {
            c1,
            c3,
            c2,
            c4,
            c5
        };

        return p;
    }
}
