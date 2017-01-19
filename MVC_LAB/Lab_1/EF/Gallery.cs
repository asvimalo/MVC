using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Models;

namespace Lab_1.EF
{
    public class Gallery : IEnumerable<PhotoViewModel>
    {
        public List<PhotoViewModel> listOfPhotos { get; set; }

        public Gallery()
        {
            listOfPhotos = new List<PhotoViewModel>();
            listOfPhotos.Add(new PhotoViewModel
            {
                PhotoID = new Guid(),
                Name = "art_4.jpg",
                Path = $"~/Images/art_4.jpg",
                Description = "My Hand",
                UploadedDate = DateTime.Now

            });
            listOfPhotos.Add(new PhotoViewModel
            {
                PhotoID = new Guid(),
                Name = "artistic-images-1.jpg",
                Path = $"~/Images/artistic-images-1.jpg",
                Description = "My Pencils",
                UploadedDate = DateTime.Now

            });
            listOfPhotos.Add(new PhotoViewModel
            {
                PhotoID = new Guid(),
                Name = "artistic-lips_2.jpg",
                Path = $"~/Images/artistic-lips_2.jpg",
                Description = "Kiss",
                UploadedDate = DateTime.Now

            });
            listOfPhotos.Add(new PhotoViewModel
            {
                PhotoID = new Guid(),
                Name = "Holi_colours_3.jpg",
                Path = $"~/Images/Holi_colours_3.jpg",
                Description = "Market",
                UploadedDate = DateTime.Now

            });
        }

        public IEnumerator<PhotoViewModel> GetEnumerator()
        {
            return listOfPhotos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public List<PhotoViewModel> GetAll()
        {
            return listOfPhotos;
        }
        public void Add(PhotoViewModel photo)
        {
            listOfPhotos.Add(photo);
        }
    }
}