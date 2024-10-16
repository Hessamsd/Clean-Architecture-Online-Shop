using System.Reflection.Metadata.Ecma335;

namespace CommentManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Message { get; set; }
        public int OwnerRecordId { get; set; }
        public string OwnerName { get; set; }
        public int Type { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public string CommentDate { get; set; }
    }
}
