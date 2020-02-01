using System.IO;
using SampSharp.Core;

namespace GrandLarcency.Services
{
    /// <inheritdoc />
    public class ScriptFilesService : IScriptFilesService
    {
        private readonly IGameModeClient _gameModeClient;

        public ScriptFilesService(IGameModeClient gameModeClient)
        {
            _gameModeClient = gameModeClient;
        }

        /// <inheritdoc />
        public Stream OpenFile(string fileName)
        {
            var path = Path.Combine(_gameModeClient.ServerPath, "scriptfiles", fileName);

            if (!File.Exists(path))
                throw new FileNotFoundException("The scriptfile could not be found.", path);

            return File.OpenRead(path);
        }
    }
}