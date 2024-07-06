﻿using Microsoft.Extensions.DependencyInjection;

namespace Rat.Domain.Infrastructure
{
    /// <summary>
    /// Inteface to define application start
    /// </summary>
    public partial interface IAppStart
    {
        /// <summary>
        /// Configure services dependency injection
        /// </summary>
        /// <param name="services">collection of services</param>
        void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Instance order
        /// </summary>
        int Order { get; }
    }
}
