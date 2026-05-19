namespace _01_code_first;

internal class Role
{
    public int Id { get; set; }
    public string Title { get; set; }

    public override string ToString()
    {
        return $"id: {Id}, title: {Title}";
    }
}
