﻿using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities;

public class Location : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
}
