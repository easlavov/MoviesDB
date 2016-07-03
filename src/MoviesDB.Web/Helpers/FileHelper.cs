namespace MoviesDB.Web.Helpers
{
    using System.Text;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    public class FileHelper : IFileHelper
    {
        public FileContentResult GetJsonFile(object data, bool indented)
        {
            string serializedData = string.Empty;
            if (indented)
            {
                serializedData = JsonConvert.SerializeObject(data, Formatting.Indented);
            }
            else
            {
                serializedData = JsonConvert.SerializeObject(data);
            }

            var byteArray = Encoding.UTF8.GetBytes(serializedData);
            return new FileContentResult(byteArray, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}