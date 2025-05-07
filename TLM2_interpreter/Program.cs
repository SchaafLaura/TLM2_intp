using SadConsole.Configuration;
using TLM2_interpreter.Utils;

Settings.WindowTitle = "TLM2Intp";

var fontPath = Util.ConcatWithSystemPathSeparator(".", "Assets", "Graphics", "TileSets", "Talryth_square_15x15.font");

Builder gameStartup = new Builder()
    .ConfigureFonts(fontPath)
    .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
    .SetStartingScreen<TLM2_interpreter.RootScreen>()
    .IsStartingScreenFocused(true)
    .OnStart(OnStartup)
    ;

Game.Create(gameStartup);
Game.Instance.Run();
Game.Instance.Dispose();

static void OnStartup(object? sender, GameHost g)
{
    Settings.ResizeMode = Settings.WindowResizeOptions.Scale;
}