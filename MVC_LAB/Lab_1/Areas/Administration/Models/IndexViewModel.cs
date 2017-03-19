using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Areas.Administration.Models
{
    public class IndexViewModel
    {
        public ICollection<UserViewModel> UserViewModels { get; set; }
        public ICollection<CommentViewModel> CommentViewModels { get; set; }
        public ICollection<AlbumViewModel> AlbumViewModels { get; set; }
        public ICollection<PhotoViewModel> PhotoViewModels { get; set; }

        public IndexViewModel()
        {
            UserViewModels = new HashSet<UserViewModel>();
            CommentViewModels = new HashSet<CommentViewModel>();
            AlbumViewModels = new HashSet<AlbumViewModel>();
            PhotoViewModels = new HashSet<PhotoViewModel>();
        }
    }
}