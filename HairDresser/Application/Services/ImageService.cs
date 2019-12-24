using Application.DTOs;
using AutoMapper;
using Infrastructure.DbContexts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ImageService
    {
        public ImageService()
        {

        }
        public static ImageDto ResolveToImage(string imageData)
        {
            ImageDto image = new ImageDto();
            if (string.IsNullOrEmpty(imageData))
            {
                image.Header = null;
                image.Source = null;
            }
            else
            {
                int headerLength = imageData.IndexOf(',') + 1;
                image.Header = imageData.Substring(0, headerLength);
                image.Source = Convert.FromBase64String(imageData.Substring(headerLength));
            }
            return image;
        }

        public static string ConcatenateToString(Image image)
        {
            string imageSource = null;
            if(image.Source != null)
            {
                imageSource = image.Header + Convert.ToBase64String(image.Source);
            }
            return imageSource;
        }
    }
}
