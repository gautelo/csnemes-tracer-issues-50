using Autofac;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace LogWeb5
{
    public static class IocConfigurer
    {
        public static void RegisterAppServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SomethingSvc>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<OtherSvc>().AsImplementedInterfaces().SingleInstance();
        }

        public static void RegisterLogger(this ContainerBuilder builder)
        {
            var loggerFactory = new LoggerFactory().AddNLog();

            // We don't need to ConfigureNLog, since NLog.config is automatically read for asp.net 4.
            // loggerFactory.ConfigureNLog("NLog.config");

            builder.RegisterInstance(loggerFactory).As<ILoggerFactory>();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
        }
    }
}