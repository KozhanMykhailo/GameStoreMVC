using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using GameStore.WebUI.Infrastructure.Abstract;
using GameStore.WebUI.Infrastructure.Concrete;
using Moq;
using Ninject;

namespace GameStore.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			//Mock<IGameRepository> mock = new Mock<IGameRepository>();
			//mock.Setup(m => m.Games).Returns(new List<Game>
			//{
			//new Game {GameId = 1, Name = "SimCity", Price = 1499 , Category = "Симулятор" , Description= "Градостроительный симулятор снова с вами! Создайте город своей мечты" },
			//new Game {GameId = 2, Name = "TITANFALL", Price=2299 , Category = "Шутер" , Description= "Эта игра перенесет вас во вселенную, где малое противопоставляется большому, природа – индустрии, а человек – машине"},
			//new Game {GameId = 3, Name = "Battlefield 4", Price=899.4M , Category = "Шутер" , Description= "Battlefield 4 – это определяющий для жанра, полный экшена боевик, известный своей разрушаемостью, равных которой нет"},
			//new Game {GameId = 4, Name = "The Sims 4", Price=15.00M , Category = "Симулятор" , Description= "В реальности каждому человеку дано прожить лишь одну жизнь. Но с помощью The Sims 4 это ограничение можно снять! Вам решать — где, как и с кем жить, чем заниматься, чем украшать и обустраивать свой дом"},
			//new Game {GameId = 5, Name = "Dark Souls 2", Price=949.00M , Category = "RPG" , Description= "Продолжение знаменитого ролевого экшена вновь заставит игроков пройти через сложнейшие испытания. Dark Souls II предложит нового героя, новую историю и новый мир. Лишь одно неизменно – выжить в мрачной вселенной Dark Souls очень непросто."},
			//new Game {GameId = 6, Name = "The Elder Scrolls V: Skyrim", Price=1399.00M , Category = "RPG" , Description= "После убийства короля Скайрима империя оказалась на грани катастрофы. Вокруг претендентов на престол сплотились новые союзы, и разгорелся конфликт. К тому же, как предсказывали древние свитки, в мир вернулись жестокие и беспощадные драконы. Теперь будущее Скайрима и всей империи зависит от драконорожденного — человека, в жилах которого течет кровь легендарных существ."},
			//new Game {GameId = 7, Name = "Need for Speed Rivals", Price=15.00M , Category = "Симулятор" , Description= "Забудьте про стандартные режимы игры. Сотрите грань между одиночным и многопользовательским режимом в постоянном соперничестве между гонщиками и полицией. Свободно войдите в мир, в котором ваши друзья уже участвуют в гонках и погонях."}
			//});
			//kernel.Bind<IGameRepository>().ToConstant(mock.Object);
			kernel.Bind<IGameRepository>().To<EFGameRepository>();
			EmailSettings emailSettings = new EmailSettings
			{
				WriteAsFile = bool.Parse(ConfigurationManager
				  .AppSettings["Email.WriteAsFile"] ?? "false")
			};

			kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
				.WithConstructorArgument("settings", emailSettings);
			kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
		}
	}
}