using MassTransit;
using Microsoft.Extensions.Options;

namespace Accommodation.Api
{
    internal sealed class MassTransitHostOptionsSetup : IConfigureOptions<MassTransitHostOptions>
    {
        /// <inheritdoc />
        public void Configure(MassTransitHostOptions options) => options.WaitUntilStarted = true;
    }
}
