using IGE.Common.Services;
using IGE.TwinStick.Desktop;

using Lamar.Microsoft.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Xna.Framework;

ServiceLocator.SetServiceRegistry(new GameServiceRegistry());

ServiceLocator.AddService<Game>(new Game1());


var game = ServiceLocator.GameServiceContainer.GetService<Game>();

game.Run();

