using Core.Initialization;
using Core.Model.ModelSystems;
using Core.View.UI;
using Core.Zenject.Source.Main;
using Game;
using UnityEngine;
using Zenject;

namespace Global.Logic
{
    public sealed class ProjectBootstrap : RuntimeProjectBootstrap
    {

        [SerializeField] private MenusConfig MenusConfig = null!;
        [SerializeField] private GameConfig GameConfig = null!;
        [SerializeField] private GameStatsContainer GameStatsContainer;
        
		
        private GameProjectInstaller _installer;
        public override SystemsInstallerBase GetLogicInstaller()
        {
            if(_installer == null)
            {
                _installer = new GameProjectInstaller(Container, MenusConfig, GameConfig, GameStatsContainer);
            }

            return _installer;
        }
        
        
    }

    public sealed class GameProjectInstaller : SystemsInstallerBase
    {
        private MenusConfig _menusConfig;
        private GameConfig _gameConfig;
        private GameStatsContainer _gameStatsContainer;

        public GameProjectInstaller(DiContainer container, 
                                    MenusConfig menusConfig, 
                                    GameConfig gameConfig,
                                    GameStatsContainer gameStatsContainer)
            : base(container)
        {
            _gameStatsContainer = gameStatsContainer;
            _gameConfig = gameConfig;
            _menusConfig = menusConfig;
        }

        public override void SetupConfigurations()
        {
        }
		protected override void AddDebugOptions()
		{
			
		}

        protected override void InstallSystems()
        {
            BindInstance<GameStatsContainer>(_gameStatsContainer);
            BindInstance<GameConfig>(_gameConfig);
            BindInstance<MenusConfig>(_menusConfig);

            
            
//             
//
//             // DebugManager.instance.displayEditorUI
//             DebugManager.instance.displayEditorUI = false;
            // UnityEngine..Rendering..DebugManager.instance.enableRuntimeUI = false;
            // UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
            Application.targetFrameRate = 60;
        }

		public override void ResetComponentContainers(DataContainersController dataContainersController) { }
        
    }
    
}
