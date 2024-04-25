namespace FaceBook.Helpers
{
    public class ImageDocument
    {
        //upload image

        public static string uploadFile(IFormFile file,string folderName)
        {
            //steps 
            //1-get located foler path
            //Directory.GetCurrentDirectory() + "\\wwwroot\\files" + folderName;
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            //2-get file name and make it unique 
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            //3-get file path (folder path +Filename)
            string filePath= Path.Combine(folderPath, fileName);
            //4-save file as streams 
            using var fs = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fs);
            //5- return file name 

            return fileName;


        }

        //delete image
    }
}
