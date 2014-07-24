using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Infrastructure.Azure
{
    public interface IFileDownloader
    {
        string DownloadPath(string container, string fileName);
    }
}