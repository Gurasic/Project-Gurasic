﻿using Project_Gurasic.Scenes;


Settings.WindowTitle = "My SadConsole Game";

Game.Configuration gameStartup = new Game.Configuration()
    .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
    .SetStartingScreen<RootScene>();

Game.Create(gameStartup);
Game.Instance.Run();
Game.Instance.Dispose();




