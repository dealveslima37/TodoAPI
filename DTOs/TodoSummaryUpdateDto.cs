using System;

namespace TodoAPI.DTOs
{
    public class TodoSummaryUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}