using RG.Application.Common.Models;
using System.Threading.Tasks;

namespace RG.Application.Common.CommonInterfaces
{
    public interface IEmailSenderService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">Commaa seperator email.</param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(EmailMessageAttachment message);
 
        
    }
}
