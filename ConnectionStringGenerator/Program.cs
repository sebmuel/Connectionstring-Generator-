using ConnectionStringGenerator.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<GenerateCommand>("generate");
});

return app.Run(args);