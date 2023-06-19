using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingManagement.Services
{
    public interface IFcmService
    {
        Task<string> SendNotification(string title, string body, string token);
    }
}
