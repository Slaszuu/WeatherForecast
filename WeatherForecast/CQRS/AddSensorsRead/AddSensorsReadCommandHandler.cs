#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence.Entities;

#endregion

namespace WeatherForecast.CQRS.AddSensorsRead;

public class AddSensorsReadCommandHandler(DbContext dbContext, IMapper<SensorsDTO, Sensors> mapper)
    : IRequestHandler<AddSensorsReadCommand, bool>
{
    public async Task<bool> Handle(AddSensorsReadCommand request, CancellationToken cancellationToken)
    {
        var sensors = mapper.Map(request.SensorsDTO);

        await dbContext.AddAsync(sensors, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}