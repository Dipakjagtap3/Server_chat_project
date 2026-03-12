namespace Server_chat_project.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        //user can create a multiple projects
        public ICollection<Project> Projects { get; set; } = new List<Project>();

        //projectmember relation
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

        //user can create a multiple task
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

        //taskassignment relation
        public ICollection<TaskAssignment> taskAssignments { get; set; } = new List<TaskAssignment>();

        //comments
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
