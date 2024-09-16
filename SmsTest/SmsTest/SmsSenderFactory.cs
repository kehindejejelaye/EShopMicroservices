using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsTest
{
    public class SmsSenderFactory : ISmsSenderFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SmsSenderFactory> _logger;

        public SmsSenderFactory(IServiceProvider serviceProvider, ILogger<SmsSenderFactory> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public ISmsSender CreateSmsSender(string provider)
        {
            _logger.LogInformation($"Creating SMS sender for provider: {provider}");

            if (Enum.TryParse(provider, true, out SmsProvider smsProvider))
            {
                return smsProvider switch
                {
                    SmsProvider.Infobip => ActivatorUtilities.CreateInstance<InfobipSmsSender>(_serviceProvider),
                    SmsProvider.Vanso => ActivatorUtilities.CreateInstance<VansoSmsSender>(_serviceProvider),
                    _ => throw new ArgumentException($"Unknown SMS provider: {provider}")
                };
            }
            else
            {
                throw new ArgumentException($"Invalid SMS provider: {provider}");
            }
        }
    }
}
