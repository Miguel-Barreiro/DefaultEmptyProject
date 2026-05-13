## Project Overview

## Development
- **Engine:** Unity 6.0.3.8f1 — open `Project/` directory in Unity Hub
- **Run:** Press Play in Editor, starting from the Preload scene
- **Build:** File > Build Settings (1920x1080 Windows/Mac/Linux)
- **Editor Utility:** `Assets > Create Data Config` — creates DataConfig/DataTable ScriptableObject instances

### Scene Flow
PreloadScene → MainMenuScene → PlayScene

Each scene has a `Bootstrap` (entry point) and an `Installer` (Zenject DI bindings):
- `ProjectBootstrap` (Resources/ProjectBootstrap): project-level init, loads configs, switches to MainMenu
- `MainMenuBootstrap` → `MainMenuInstaller` → `MainMenuController` shows UI, play button triggers scene switch
- `GameplayBootstrap` → `GameplayInstaller`: ready for gameplay systems (currently empty)

### Key Patterns

**Dependency Injection:** Zenject. Systems register via `SystemsInstallerBase` subclasses. `IStartSystem` marks classes that run once during initialization.

**Data/Config:** `DataConfig` and `DataTable` are ScriptableObject base classes. Global configs (`GameConfig`, `MenusConfig`) are injected through installers. `GameStatsContainer` holds runtime game state.

**UI System:** `UIRoot` manages screens. Screens are `UIView<TMessenger>` bound to a messenger. Events flow through the messenger (e.g., `MainMenuMessenger` → play button → `ScenesController.SwitchScene`).

**Scene constants:** `SceneNames.cs` — PRELOAD, MAIN_MENU, PLAY_SCENE.

### Source Layout

All game code lives under `Assets/!/` (the `!` prefix sorts it to the top):
- `Configs/` — ScriptableObject data configs
- `Content/Game/` — gameplay logic
- `Content/Menus/MainMenu/` — main menu UI and controller
- `Global/` — `GameConfig`, `MenusConfig`, `SceneNames`
- `Scenes/` — per-scene Bootstrap and Installer scripts
- `Resources/ProjectBootstrap/` — project-level bootstrap (loaded at runtime via Resources)
- `Editor/Utils/` — editor-only tools (DataCreatorUtil)

Third-party plugins are in `Assets/Plugins/` (Odin Inspector, DOTween, SRDebugger).

### Adding New Gameplay Systems

1. Register the system in `GameplayInstaller` via Zenject bindings
2. Implement `IStartSystem` if it needs initialization
3. Add game state to `GameStatsContainer`
4. Use the existing `EventQueue` or messenger pattern for inter-system events
