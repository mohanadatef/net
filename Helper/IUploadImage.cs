using KhadimiEssa.Models.ImageViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Helper
{
    public interface IUploadImage
    {
        string Upload(IFormFile Photo, int FileName);
        Tuple<List<string>, string> ListResizeImage(List<IFormFile> Photos, int FileName);
        List<string> UploadListImages(List<IFormFile> Photos, int FileName);
        List<ResizeImagesViewModel> NewUploadBaseAndResizeImages(List<IFormFile> Photos, int FileName);

        Task<List<ResizeImagesViewModel>> NewUploadBaseAndResizeImages_WithWaterMark(List<IFormFile> Photos, int FileName, string BranchName = "");

    }
}
