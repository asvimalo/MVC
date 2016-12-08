using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Models;

namespace Lab_1.EF
{
    public class Gallery : IEnumerable<Photo>
    {
        public List<Photo> listOfPhotos { get; set; }

        public Gallery()
        {
            listOfPhotos = new List<Photo>();
            listOfPhotos.Add(new Photo {
                PhotoID = new Guid(),
                Name = "art_4.jpg",
                Path = $"~/Images/art_4.jpg",
                Description = "My Hand",
                UploadedDate = DateTime.Now

            });
            listOfPhotos.Add(new Photo
            {
                PhotoID = new Guid(),
                Name = "artistic-images-1.jpg",
                Path = $"~/Images/artistic-images-1.jpg",
                Description = "My Pencils",
                UploadedDate = DateTime.Now

            });
            listOfPhotos.Add(new Photo
            {
                PhotoID = new Guid(),
                Name = "artistic-lips_2.jpg",
                Path = $"~/Images/artistic-lips_2.jpg",
                Description = "Kiss",
                UploadedDate = DateTime.Now

            });
            listOfPhotos.Add(new Photo
            {
                PhotoID = new Guid(),
                Name = "Holi_colours_3.jpg",
                Path = $"~/Images/Holi_colours_3.jpg",
                Description = "Market",
                UploadedDate = DateTime.Now

            });
        }

        public IEnumerator<Photo> GetEnumerator()
        {
            return listOfPhotos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public List<Photo> GetAll()
        {
            return listOfPhotos;
        }
        public void Add(Photo photo)
        {
            listOfPhotos.Add(photo);
        }
    }
}