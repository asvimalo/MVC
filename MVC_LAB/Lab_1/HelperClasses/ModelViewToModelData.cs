using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Models;
using LAB_DAL.Models;

namespace Lab_1.HelperClasses
{
    public static class ModelViewToModelData
    {
        public static Photo ReturnPhotoModelData(PhotoViewModel pic)
        {
            var photo = new Photo();
            photo.PhotoID = pic.PhotoID;
            photo.Name = pic.Name;
            photo.Path = pic.Path;
            photo.UserID = pic.UserID;
            photo.Description = pic.Description;
            photo.UploadedDate = pic.UploadedDate;
            photo.DateChanged = pic.DateChanged;
            photo.AlbumID = pic.AlbumID;
            return photo;
        }
        public static PhotoViewModel ReturnPhotoModelView(Photo pic)
        {
            var photo = new PhotoViewModel();
            photo.PhotoID = pic.PhotoID;
            photo.Name = pic.Name;
            photo.Path = pic.Path;
            photo.UserID = pic.UserID;
            photo.Description = pic.Description;
            photo.UploadedDate = pic.UploadedDate;
            photo.DateChanged = pic.DateChanged;
            photo.AlbumID = pic.AlbumID;
            return photo;
        }
    }
}