using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRadarQuizApp.Models
{
    public class VideoItemManager
    {
        IRestService restService;

        public VideoItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Video>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}