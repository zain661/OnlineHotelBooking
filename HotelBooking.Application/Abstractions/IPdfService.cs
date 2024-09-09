using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Abstractions
{
    public interface IPdfService
    {
        Task<byte[]> CreatePdfFromHtmlAsync(string html);
    }
}
