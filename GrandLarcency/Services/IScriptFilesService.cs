using System.IO;

namespace GrandLarcency
{
    public interface IScriptFilesService
    {
        Stream OpenFile(string fileName);
    }
}