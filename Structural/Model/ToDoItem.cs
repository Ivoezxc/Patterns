public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = ""; // Assign a non-null default value
    public bool IsCompleted { get; set; }
}
