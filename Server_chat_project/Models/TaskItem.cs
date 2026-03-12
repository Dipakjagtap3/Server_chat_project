namespace Server_chat_project.Models
{
    public class comment
    {
        public int TaskItemId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;

        //owenship

        public int CreatorId { get; set; }
        public User? Creator { get; set; }

        //project relation

        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        //taskassignment relation
        public ICollection<TaskAssignment>? TaskAssignments { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
