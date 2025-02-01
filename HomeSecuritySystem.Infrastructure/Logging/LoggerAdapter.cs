using HomeSecuritySystem.Application.Contracts.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HomeSecuritySystem.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly  ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.LogError(ex, message, args);
        }

    }
}
