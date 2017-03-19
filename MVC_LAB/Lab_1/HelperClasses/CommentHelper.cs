using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_DAL.Models;
using Lab_1.Models;
using LAB_DAL.Repo;

namespace Lab_1.HelperClasses
{
    public static class CommentHelper
    {
        public static Comment MapComment(this CommentViewModel viewComment)
        {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                PhotoId = viewComment.PhotoId,
                Date = DateTime.UtcNow,
                Text = viewComment.Comment,
                UserId = UserRepo.GetUserId(viewComment.Commenter)
            };

            return comment;
        }
    }
}