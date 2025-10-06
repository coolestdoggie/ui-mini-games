# UI Mini Games

## Summary

This repository contains several standalone mini-games that demonstrate UI patterns, small gameplay loops, and reusable UI infrastructure. The project is organized so each game lives under `Assets/Games/<GameName>` and includes its own scenes, UI prefabs, and code assemblies.

Included games (each has its own scene and assembly definitions):
- `AceOfShadows` — located at `Assets/Games/AceOfShadows` (entry scene: `Assets/Games/AceOfShadows/Scenes/AceOfShadows.unity`).
- `MagicWords` — located at `Assets/Games/MagicWords` (entry scene: `Assets/Games/MagicWords/Scenes/MagicWords.unity`).
- `PhoenixFlame` — located at `Assets/Games/PhoenixFlame` (entry scene: `Assets/Games/PhoenixFlame/Scenes/PhoenixFlame.unity`).
- `LoadingMenu` — a launcher/menu for the collection: `Assets/Games/LoadingMenu/Scenes/LoadingMenu.unity`.

## Test The Build
You can test a WebGL build here: https://play.unity.com/en/games/928c8dbe-83f5-44c8-a99a-9a12c5ee9a8a/ui-mini-games

## Unity Editor Version

Unity 6000.2.6f2

## Third-party libraries
- DOTween (Demigiant) — used for animations/tweens.
- UniTask — async/await support in Unity.

## Project Structure (high level)

- `Assets/` — Unity assets and game code. Main subfolders:
  - `Games/` — each game's Scenes, CodeBase, and UI.
  - `Common/`, `Resources/`, `Plugins/`, etc. — shared assets and utilities.

## Architecture

This section explains the high-level architecture, how code is organized into assemblies and layers, and recommended patterns for adding or changing features.

High-level layers
- Launcher / Entry: `LoadingMenu` provides a single entry point and scene that can navigate to individual game scenes. Treat it as the shell that selects and loads game scenes.
- Game Scenes: Each game lives in `Assets/Games/<GameName>/Scenes` and contains the root scene that implements that game's flow (UI + small gameplay loop).
- Game Module: Under `Assets/Games/<GameName>/CodeBase` you will find assembly definitions (`*.asmdef`) and subfolders (UI, Infrastructure, Data, etc.). Each game's code is scoped to its asmdef to limit cross-game coupling.
- Shared Services & Common: `Assets/Common`. Common contains a `Common.asmdef` so shared code compiles into a well-scoped assembly.
- Plugins / 3rd-party: `Assets/Plugins` holds external libraries (for example `Demigiant`/DOTween and `UniTask`).

The project is based on Component Service architecture.

The flow of the every game starts in the GameBootstrap class that creates Game State Machine. The Game State machine's goal is to control the flow of the game. The State machine pattern comes in handy when we need to sequentially do some things. Examples of basic game states are:

- Bootstrap State (The state that registers services)
- LoadScene State (The state that instantiates and constructs an object that we need in the game)
- GameLoop etc.

<img width="911" height="456" alt="image" src="https://github.com/user-attachments/assets/339b551d-f130-472a-9fb6-83bf9ecb0522" />

Another important thing to discuss is the Service Locator pattern. It's the Dependency Injection implementation. I thought importing Zenject or some kind of DI framework would be bloated for such a small project, so I've decided to use the manual-written one. The game uses the concept of Services. Services are objects that handle one responsibility of a game. For example in these games you will find:

- Game Factory Service
- Time Service
- Cards Service etc.

You can look at the work of service mostly in GameFactory, which is the Service that creates objects for the game and constructs them (passing them needed reference e.g.)
