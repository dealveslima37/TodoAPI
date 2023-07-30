using System;

namespace TodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Todo(string title, bool done, DateTime createdAt)
        {
            Title = title;
            Done = done;
            CreatedAt = createdAt;
        }
    }
}