namespace DotNetCorePostgres.Models
{
    public class Bar
    {
        public int BarId { get; set; }
        public string Name { get; set; }

        public int FooId { get; set; }
        public Foo Foo { get; set; }
    }
}