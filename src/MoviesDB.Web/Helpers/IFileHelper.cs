using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MoviesDB.Web.Helpers
{
    public interface IFileHelper
    {
        FileContentResult GetJsonFile(object data, bool indented);
    }
}
