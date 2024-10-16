using _0_Framework.Domain;


namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string WebSite { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public int OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public int ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }


        public Comment(string name, string email,string website, string message, int ownerRecordId, int type,int parentid)
        {
            Name = name;
            Email = email;
            WebSite = website;
            Message = message;
            OwnerRecordId = ownerRecordId;
            Type = type;
            ParentId = parentid;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
