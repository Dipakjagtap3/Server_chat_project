namespace Server_chat_project.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        //user can create a multiple projects
        public ICollection<Project>? Projects { get; set; }

        //projectmember relation
        public ICollection<ProjectMember>? ProjectMembers { get; set; }

        //user can create a multiple task
        public ICollection<comment>? TaskItems { get; set; }

        //taskassignment relation
        public ICollection<TaskAssignment>? taskAssignments { get; set; }

        //comments
        public ICollection<Comment>? Comments { get; set; }

        //userroles

        public ICollection<UserRole>? UserRoles { get; set; }


    }
}
