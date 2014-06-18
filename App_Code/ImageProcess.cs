using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// 
/// 
/// Developer: Tupaz, Reiner S., Vasay Brian
/// Date Created: 06/28/2013
/// 
/// ***************************************************************************************
/// REVISION HISTORY:
/// CHANGE DATE:    CHANGED BY:         DESCRIPTION
/// 06/28/2013                          Creation of the class
/// ***************************************************************************************
/// </summary>

namespace ImageProcessor
{
    public class ImageProcess
    {
        // This is to validate if the file stream is a valid and supported image file
        public bool ValidateImageFileType(Stream File_Stream)
        {
            try
            {
                // This is to validate if the file stream is a valid image file
                System.Drawing.Image _image = System.Drawing.Image.FromStream(File_Stream);

                // This is to validate if the file stream is among the indicated image file types
                if ((_image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid) || (_image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid) ||
                    (_image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid) || (_image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid) ||
                    (_image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid) || (_image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }
        // This is to validate the image file size
        public bool ValidateImageFileSize(Stream File_Stream, int Size_Limit)
        {
            try
            {
                if (File_Stream.Length <= Size_Limit)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // This is to resize an image file biased to the width of the image
        public void ResizeImageProportionate_XInclination(Stream File_Stream, int Target_Width, string Save_Path)
        {
            try
            {
                // This to extract the image from the file stream without uploading
                System.Drawing.Image _image = System.Drawing.Image.FromStream(File_Stream);
                int Image_Width = _image.Width;
                int Image_Height = _image.Height;
                int target_width = Target_Width;
                int target_height = (Target_Width * Image_Height) / Image_Width;
                // This is to create a new image from the file stream to a specified height and width
                Bitmap _bitmap = new Bitmap(target_width, target_height, _image.PixelFormat);
                _bitmap.SetResolution(72, 72);
                // This is to resize the image to the target height and target width
                Graphics _graphics = Graphics.FromImage(_bitmap);
                _graphics.DrawImage(_image, new Rectangle(0, 0, target_width, target_height),
                   new Rectangle(0, 0, Image_Width, Image_Height), GraphicsUnit.Pixel);
                // This is to save the image file into the save path
                _bitmap.Save(Save_Path, _image.RawFormat);
                _image.Dispose();
                _graphics.Dispose();
                _bitmap.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // This is to resize an image file biased to the height of the image
        public void ResizeImageProportionate_YInclination(Stream File_Stream, int Target_Height, string Save_Path)
        {
            try
            {
                // This to extract the image from the file stream without uploading
                System.Drawing.Image _image = System.Drawing.Image.FromStream(File_Stream);
                int Image_Height = _image.Height;
                int Image_Width = _image.Width;
                int target_height = Target_Height;
                int target_width = (Target_Height * Image_Width) / Image_Height;
                // This is to create a new image from the file stream
                Bitmap _bitmap = new Bitmap(target_width, target_height, _image.PixelFormat);
                _bitmap.SetResolution(72, 72);
                // This is to resize the image to the target height and target width
                Graphics _graphics = Graphics.FromImage(_bitmap);
                _graphics.DrawImage(_image, new Rectangle(0, 0, target_width, target_height),
                   new Rectangle(0, 0, Image_Width, Image_Height), GraphicsUnit.Pixel);
                // This is to save the image file into the save path
                _bitmap.Save(Save_Path, _image.RawFormat);

                _image.Dispose();
                _graphics.Dispose();
                _bitmap.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // This is to resize an image file based on user input of width and height
        public void ResizeImage(Stream File_Stream, int Target_Width, int Target_Height, string Save_Path)
        {
            try
            {
                // This to extract the image from the file stream without uploading
                System.Drawing.Image _image = System.Drawing.Image.FromStream(File_Stream);
                int Image_Height = _image.Height;
                int Image_Width = _image.Width;
                int target_height = Target_Height;
                int target_width = Target_Width;
                // This is to create a new image from the file stream
                Bitmap _bitmap = new Bitmap(target_width, target_height, _image.PixelFormat);
                _bitmap.SetResolution(72, 72);
                // This is to resize the image to the target height and target width
                Graphics _graphics = Graphics.FromImage(_bitmap);
                _graphics.DrawImage(_image, new Rectangle(0, 0, target_width, target_height),
                   new Rectangle(0, 0, Image_Width, Image_Height), GraphicsUnit.Pixel);
                // This is to save the image file into the save path
                _bitmap.Save(Save_Path, _image.RawFormat);

                _image.Dispose();
                _graphics.Dispose();
                _bitmap.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
