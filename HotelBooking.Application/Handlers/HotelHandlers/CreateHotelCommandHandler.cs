using FluentValidation;
using HotelBooking.Application.Commands.HotelCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Guid>
{
    private readonly IHotelRepo _hotelRepository;
    private readonly IValidator<CreateHotelCommand> _validator;

    public CreateHotelCommandHandler(IHotelRepo hotelRepository, IValidator<CreateHotelCommand> validator)
    {
        _hotelRepository = hotelRepository;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var hotel = new Hotel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Rating = request.Rating,
            StreetAddress = request.StreetAddress,
            Description = request.Description,
            NumberOfRooms = request.NumberOfRooms,
            CityId = request.CityId,
            OwnerId = request.OwnerId,
            PhoneNumber = request.PhoneNumber,
            Category = request.Category,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        await _hotelRepository.CreateHotelAsync(hotel);
        return hotel.Id;
    }
}
