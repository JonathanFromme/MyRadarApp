using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRadarQuizApp.Models
{
    public interface IRestService
    {
        Task<List<Video>> RefreshDataAsync();
    }
}