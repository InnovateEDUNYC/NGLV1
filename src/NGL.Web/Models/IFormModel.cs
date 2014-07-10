using System.Collections.Generic;

namespace NGL.Web.Models
{
    public interface IFormModel
    {
        Dictionary<string, string> GetErrors();
    }
}