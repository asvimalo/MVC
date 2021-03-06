﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Models;
using LAB_DAL.Models;
using LAB_DAL.Repo;
using WebGrease.Css.Extensions;

namespace Lab_1.HelperClasses
{
    public static class AlbumHelper
    {
        public static List<AlbumViewModel> MapAlbums(this List<AlbumViewModel> viewAlbums, List<Album> albums)
        {
            albums.ForEach(x => viewAlbums.Add(new AlbumViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Creator = UserRepo.GetUserName(x.UserId)
            }));

            return viewAlbums;
        }

        public static Album MapAlbum(this AlbumCreateViewModel viewModel)
        {
            var album = new Album
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                UserId = UserRepo.GetUserId(viewModel.Creator)
            };

            return album;
        }

        public static IEnumerable<DetailsPhotoViewModel> MapPhotos(this List<DetailsPhotoViewModel> viewComments, List<Photo> photos)
        {
            photos.ForEach(x => viewComments.Add(new DetailsPhotoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                FileName = x.FileName,
                UploadedBy = PhotoRepository.GetUserName(x.Id)
            }));

            return viewComments;
        }

        public static AlbumViewModel MapPhoto(this AlbumViewModel detailsAlbum, Album album)
        {
            detailsAlbum.Id = album.Id;
            detailsAlbum.Name = album.Name;
            detailsAlbum.Creator = album.User.Name;

            album.Photos.ToList().ForEach(x => detailsAlbum.Photos.Add(
                new DetailsPhotoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UploadedBy = x.User.Name,
                    Description = x.Description,
                    FileName = x.FileName
                }));

            return detailsAlbum;
        }
    }
}