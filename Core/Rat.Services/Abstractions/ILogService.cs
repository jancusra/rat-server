using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Domain.Entities;
using Rat.Domain.Types;

namespace Rat.Services
{
    public partial interface ILogService
    {
        Task<IList<Log>> GetAllAsync();

        Task InsertLogAsync(
            LogLevelType logLevelType, string shortMessage, string fullMessage);

        Task InformationAsync(string message, Exception exception = null);

        Task WarningAsync(string message, Exception exception = null);

        Task ErrorAsync(string message, Exception exception = null);
    }
}
