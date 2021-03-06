﻿using DTO.Enums;
using Infrastructure.Handlers.LogHandler;

namespace Infrastructure.Services.LoggerFactory
{
    public interface ILoggerFactory
    {
        public ILogHandler GetLogger(LogWay logWay);
    }
}