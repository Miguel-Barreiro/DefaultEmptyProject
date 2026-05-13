using Core.Initialization;
using Core.Model.ModelSystems;
using Core.Zenject.Source.Main;

namespace Scenes.Play
{
	public sealed class GameplayBootstrap : SceneBootstrap
	{
		private GameplayInstaller _installer;

		public override SystemsInstallerBase GetLogicInstaller()
		{
			if(_installer == null)
				_installer = new GameplayInstaller(Container);

			return _installer;
		}
	}
	
	public sealed class GameplayInstaller : SystemsInstallerBase
	{
		public GameplayInstaller(DiContainer container) : base(container)
		{
		}

		public override void SetupConfigurations()
		{
		}

		protected override void InstallSystems()
		{
			
		}

		protected override void AddDebugOptions()
		{
//			AddDebugOption();
			
		}

		public override void ResetComponentContainers(DataContainersController dataController)
		{
			
		}
	}
}