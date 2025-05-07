using TLM2_interpreter.Utils;

namespace TLM2_interpreter
{
    internal sealed class RootScreen : ScreenObject
    {
        private readonly ScreenSurface _mainSurface;
        public RootScreen()
        {
            _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);
            Children.Add(_mainSurface);
            Init();
        }

        private void Init()
        {
            var codePath = Util.ConcatWithSystemPathSeparator(".", "Code", "code.tlm");
            var code = File.ReadAllLines(codePath);
            var k = 4;
            foreach (var line in code)
                _mainSurface.Print(4, k++, line,Color.AliceBlue, new Color(20, 20, 20));

            List<List<string>> splitFunctions = [];

            k = 0;
            var kPrev = 0;
            while (k < code.Length)
            {
                if (code[k][0] != '{')
                    throw new Exception("not a function");

                kPrev = k;
                while (code[k][0] != '}')
                    k++;

                var f = new List<string>();

                for(int i = kPrev; i <= k; i++)
                    f.Add(code[i]);

                splitFunctions.Add(f);
                k++;
            }

            var p = new TLMProgram([.. splitFunctions.Select(f => new TLMFunction(f))]);

        }
    }
}