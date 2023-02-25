using KhadimiEssa.Models.ImageViewModel;
using LazZiya.ImageResize;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Helper
{
    public class UploadImage : IUploadImage
    {

        private readonly IWebHostEnvironment HostingEnvironment;

        public UploadImage(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        List<PathImageViewModel> ListPath = new List<PathImageViewModel>
        {
            new PathImageViewModel{Id= 5 ,FileName="Product" ,PathImg= BaisUrlProduct },
            new PathImageViewModel{Id= 1 ,FileName="Category" ,PathImg= BaisUrlCategory },
            new PathImageViewModel{Id= 7 ,FileName="IntroSite" ,PathImg= BaisUrlIntroSite },
            new PathImageViewModel{Id= 8 ,FileName="Users" ,PathImg= BaisUrlUser },
            new PathImageViewModel{Id=9 ,FileName="ChatFiles" ,PathImg= BaisUrlChatFiles },
            new PathImageViewModel{Id=12 ,FileName="SocialMedia" ,PathImg= BaisUrlSocialMedia },

        };


        public string Upload(IFormFile Photo, int FileName)
        {
            PathImageViewModel NewPath = ListPath.Where(x => x.Id == FileName).FirstOrDefault();


            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, $"images/{NewPath.FileName}");
                uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return NewPath.PathImg + uniqueFileName;
        }


        public Tuple<List<string>, string> ListResizeImage(List<IFormFile> Photos, int FileName)
        {

            List<string> ListImages = UploadListImages(Photos, FileName);

            IFormFile FirstFile = Photos.FirstOrDefault();

            string FirstImg = ResizeImage(FirstFile, FileName);

            return new Tuple<List<string>, string>(ListImages, FirstImg);
        }


        public List<string> UploadListImages(List<IFormFile> Photos, int FileName)
        {
            List<string> ListImages = new List<string>();
            if (Photos != null)
            {
                foreach (var photo in Photos)
                {
                    if (photo != null)
                    {
                        string NewImage = Upload(photo, FileName);
                        ListImages.Add(NewImage);
                    }
                }
                return ListImages;
            }
            return ListImages;
        }


        public string ResizeImage(IFormFile Photo, int FileName)
        {
            string uniqueFileName = UploadToResize(Photo, FileName);

            PathImageViewModel NewPath = ListPath.Where(x => x.Id == FileName).FirstOrDefault();



            // use using to dispose the image after resize and free memory
            using (var img = Image.FromFile($"wwwroot/images/{NewPath.FileName}/" + uniqueFileName))
            {
                img.Scale(200, 200)
                    .SaveAs($"wwwroot/images/{NewPath.FileName}/" + "new-" + uniqueFileName);


            }
            return NewPath.PathImg + "new-" + uniqueFileName;
        }

        public string UploadToResize(IFormFile Photo, int FileName)
        {
            PathImageViewModel NewPath = ListPath.Where(x => x.Id == FileName).FirstOrDefault();

            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, $"images/{NewPath.FileName}");
                uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public List<ResizeImagesViewModel> NewUploadBaseAndResizeImages(List<IFormFile> Photos, int FileName)
        {
            List<ResizeImagesViewModel> ListBaseImages = new List<ResizeImagesViewModel>();

            if (Photos != null)
            {
                foreach (var photo in Photos)
                {
                    if (photo != null)
                    {
                        string BaseImg = Upload(photo, FileName);
                        string ResizeImg = ResizeImage(photo, FileName);
                        ListBaseImages.Add(new ResizeImagesViewModel { NormalImg = BaseImg, ResizeImg = ResizeImg });
                    }
                }
                return ListBaseImages;
            }
            return ListBaseImages;
        }

        public async Task<List<ResizeImagesViewModel>> NewUploadBaseAndResizeImages_WithWaterMark(List<IFormFile> Photos, int FileName, string Logo = "")
        {
            List<ResizeImagesViewModel> ListBaseImages = new List<ResizeImagesViewModel>();

            if (Photos.Count() > 0)
            {
                foreach (var photo in Photos)
                {
                    if (photo != null)
                    {
                        string BaseImg = default;
                        if (string.IsNullOrEmpty(Logo))
                        {
                            //BaseImg = Upload_WithWaterMark(photo, FileName, BranchName);
                            BaseImg = Upload(photo, FileName);
                        }
                        else
                        {
                            BaseImg = await AddLogo(photo, FileName, Logo);
                        }
                        // string ResizeImg = ResizeImage_WithWaterMark(photo, FileName, BranchName);
                        string ResizeImg = ResizeImage(photo, FileName);

                        ListBaseImages.Add(new ResizeImagesViewModel { NormalImg = BaseImg, ResizeImg = ResizeImg });
                    }
                }
                return ListBaseImages;
            }
            return ListBaseImages;
        }

        /***********************************Add Logo**************************************/

        public async Task<string> AddLogo(IFormFile item, int FileName, string Logo = "")
        {
            // get stream of image to >>>> convert it from <<<< IFormFile to Image >>>> (For Processing)
            var stream = new MemoryStream();
            await item.CopyToAsync(stream);

            using (Image image = Image.FromStream(stream, true, false))
            {

                // get image uploaded
                Image upImage = Image.FromStream(stream);


                // get image logo
                string logoImagepath = Path.Combine(HostingEnvironment.WebRootPath, $"images\\logo\\{Logo}");
                //string logoImagepath = $"wwwroot/images/logo/ShowLogo.png";
                Image logoImage = Image.FromFile(logoImagepath);




                //get filePath to upload
                //string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "ImagWatermark");
                //string uniqueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;


                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                PathImageViewModel NewPath = ListPath.Where(x => x.Id == FileName).FirstOrDefault();
                //string FullPathImg = $"wwwroot/images/{NewPath.FileName}/{uniqueFileName}";

                string filePath = Path.Combine($"wwwroot/images/{NewPath.FileName}/{uniqueFileName}");



                Bitmap tempbitmap = new Bitmap(new Bitmap(upImage));

                // set water mark
                using (Graphics g = Graphics.FromImage(tempbitmap))
                {

                    // resize the logo depend on uploaded images
                    #region resize the logo depend on uploaded images
                    int newWidth = 0, newHeight = 0;
                    int sourceWidth = logoImage.Width;
                    int sourceHeight = logoImage.Height;


                    // set height and width of logo
                    newWidth = tempbitmap.Width / 3;
                    newHeight = tempbitmap.Height / 2;



                    int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
                    float nPercent = 0, nPercentW = 0, nPercentH = 0;

                    nPercentW = ((float)newWidth / (float)sourceWidth);
                    nPercentH = ((float)newHeight / (float)sourceHeight);
                    if (nPercentH < nPercentW)
                    {
                        nPercent = nPercentH;
                        destX = System.Convert.ToInt16((newWidth -
                                  (sourceWidth * nPercent)) / 2);
                    }
                    else
                    {
                        nPercent = nPercentW;
                        destY = System.Convert.ToInt16((newHeight -
                                  (sourceHeight * nPercent)) / 2);
                    }

                    int destWidth = (int)(sourceWidth * nPercent);
                    int destHeight = (int)(sourceHeight * nPercent);


                    Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                                  PixelFormat.Format64bppPArgb);

                    bmPhoto.SetResolution(logoImage.HorizontalResolution,
                                 logoImage.VerticalResolution);

                    Graphics grPhoto = Graphics.FromImage(bmPhoto);
                    //grPhoto.Clear(Color.Transparent);
                    grPhoto.InterpolationMode =
                        System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    grPhoto.DrawImage(logoImage,
                        new Rectangle(destX, destY, destWidth, destHeight),
                        new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                        GraphicsUnit.Pixel);



                    // convert new logo from <<<< Bitmap to Image >>>
                    Image logo2 = (Image)bmPhoto;
                    #endregion


                    // set logo to uploaded image
                    g.DrawImage(logo2, new Point(tempbitmap.Width - (logo2.Width / 3), tempbitmap.Height - (tempbitmap.Height / 6)));


                    //save uploaded to server
                    tempbitmap.Save(filePath);

                }

                return NewPath.PathImg + uniqueFileName;
                //// set paths to view in runtime in index
                //listimg.Add(uniqueFileName);
            }
        }

    }
}
