using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.Image.Responses;
using HotelBooking.Application.Queries.ImageQueries;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.ImageHandlers
{
    public sealed class GetHotelImagesQueryHandler : IRequestHandler<GetHotelImagesQuery, IList<ImageDTO>>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public GetHotelImagesQueryHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<IList<ImageDTO>> Handle(GetHotelImagesQuery request, CancellationToken cancellationToken)
        {
            var images = await _imageRepo.GetImagesByHotelIdAsync(request.HotelId);
            var imageDtos = _mapper.Map<IList<ImageDTO>>(images);
            return imageDtos;
        }
    }
}
