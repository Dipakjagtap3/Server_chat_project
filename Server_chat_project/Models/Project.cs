namespace Server_chat_project.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;

        // Navigation property for related ChatMessages
        //user can create project
        //owenship
        public int CreatorId { get; set; }
        public User Creator { get; set; } = new User();

        // Navigation property for related TaskItems

        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

        //projectmember relation
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    }
}
