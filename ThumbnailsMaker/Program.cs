using System;
using Autofac;
using CommandLine;
using ThumbnailsMaker.Components;
using ThumbnailsMaker.ImageOperations;

namespace ThumbnailsMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ConfigurationsModule(args));
            builder.RegisterModule(new ComponentsModule());

            builder.Register(c =>
                    new Filters(c.Resolve<AppConfiguration>().Config.Background.Filters))
                .Keyed<IFilters>(typeof(Background)).SingleInstance();

            var container = builder.Build();
            
            container.Resolve<IProcessComponent>().DoProcess();
        }
    }

    internal class ComponentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BarComponent>().As<IBarComponent>().InstancePerLifetimeScope();
            builder.RegisterType<BackgroundComponent>().As<IBackgroundComponent>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessComponent>().As<IProcessComponent>().InstancePerLifetimeScope();
        }
    }
    
    internal class ConfigurationsModule : Module
    {
        private readonly string[] _args;

        public ConfigurationsModule(string[] args)
            => _args = args;

        protected override void Load(ContainerBuilder builder)
        {
            Parser.Default.ParseArguments<Options>(_args)
                .WithParsed(options =>
                {
                    builder.RegisterType<AppConfiguration>()
                        .WithParameter(new TypedParameter(typeof(string), options.Config))
                        .SingleInstance();
                });
        }
    }
    
    internal class Options
    {
        [Option('c', "config", Required = false, Default = "config.json" , HelpText = "Configuration file name")]
        public string Config { get; set; } = String.Empty;
    }
}
