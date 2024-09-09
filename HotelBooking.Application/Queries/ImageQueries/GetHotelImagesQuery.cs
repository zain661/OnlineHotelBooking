using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.Image.Responses;
using MediatR;

namespace HotelBooking.Application.Queries.ImageQueries
{
    public record GetHotelImagesQuery(Guid HotelId): IRequest<IList<ImageDTO>>;
}
