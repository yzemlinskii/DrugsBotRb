﻿using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface IDrugWriteRepository : IWriteRepository<Drug>
{
    Task UpdateManufacturer(string manufacturer, CancellationToken cancellationToken);
}