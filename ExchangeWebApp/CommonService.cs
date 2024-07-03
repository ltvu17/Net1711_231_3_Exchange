﻿using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace ExchangeWebApp
{
    public interface ICommonService
    {
        public Task<string> UploadAnImage(IFormFile file, string pathFolder, string nameOfImg);
        public Task<string> UploadAVideo(IFormFile file, string pathFolder, string nameOfImg);

    }
    public class CommonService : ICommonService
    {
        private Cloudinary _cloudinary;
        private string _cloudName;
        private string _apiKey;
        private string apiSecret;
        private readonly IConfiguration _configuration;

        public CommonService(IConfiguration configuration)
        {
            _configuration = configuration;
            _cloudName = _configuration["CloudinarySettings:CloudName"];
            _apiKey = _configuration["CloudinarySettings:ApiKey"];
            apiSecret = _configuration["CloudinarySettings:ApiSecret"];
        }
        public async Task<string> UploadAnImage(IFormFile file, string pathFolder, string nameOfImg)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file uploaded.");
            }

            if (!file.ContentType.ToLower().StartsWith("image/"))
            {
                throw new Exception("File is not a image!");
            }
            var account = new Account(_cloudName, _apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);

            var uploadParameters = new ImageUploadParams();

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                uploadParameters.File = new FileDescription(file.FileName, new MemoryStream(memoryStream.ToArray()));
            }

            uploadParameters.Folder = pathFolder;
            uploadParameters.PublicId = nameOfImg;
            var result = await _cloudinary.UploadAsync(uploadParameters);

            if (result.Error != null)
            {
                throw new Exception(result.Error.Message);
            }

            return result.SecureUrl.ToString();
        }

        public async Task<string> UploadAVideo(IFormFile file, string pathFolder, string nameOfImg)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file uploaded!");
            }

            if (!file.ContentType.ToLower().StartsWith("video/"))
            {
                throw new Exception("File is not a video!");
            }

            var account = new CloudinaryDotNet.Account(_cloudName, _apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);

            var uploadParams = new VideoUploadParams();
            uploadParams.Folder = pathFolder;
            uploadParams.PublicId = nameOfImg;
            using (var stream = file.OpenReadStream())
            {
                uploadParams.File = new FileDescription(file.FileName, stream);
                var uploadResult = _cloudinary.Upload(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}
