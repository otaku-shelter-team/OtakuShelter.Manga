using Microsoft.Extensions.DependencyInjection;

using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Mangas
{
	public static class MangasRabbitMqExtensions
	{
		public static IServiceCollection AddMangasRabbitMq(
			this IServiceCollection services,
			MangasRabbitMqConfiguration configuration)
		{
			services.AddPhemaJsonSerializer();
			
			var builder = services.AddPhemaRabbitMq(configuration.InstanceName,
				options =>
				{
					options.UserName = configuration.Username;
					options.Password = configuration.Password;
					options.Port = configuration.Port;
					options.HostName = configuration.Hostname;
					options.VirtualHost = configuration.VirtualHost;
				});
			
			builder.AddProducers(options =>
				options.AddProducer<MangasExceptionPayload>("amq.direct", "errors")
					.Mandatory());
			
			return services;
		}
	}
}