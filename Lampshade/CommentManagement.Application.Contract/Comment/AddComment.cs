﻿namespace CommentManagement.Application.Contracts.Comment
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string WebSite { get; set; }
        public int OwnerRecordId { get; set; }
        public int type { get; set; }
        public int ParentId { get; set; }


    }
}