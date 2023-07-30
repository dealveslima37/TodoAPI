using System;
using System.Text.Json.Serialization;

namespace TodoAPI.DTOs
{
    public class TodoSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}