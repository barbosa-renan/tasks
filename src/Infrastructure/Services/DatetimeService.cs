﻿using Application.Interfaces;

namespace Infrastructure.Services;

internal class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
