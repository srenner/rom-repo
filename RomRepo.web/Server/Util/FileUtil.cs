namespace RomRepo.web.Server.Util
{
    public static class FileUtil
    {
        public static bool TestNetworkPath(string path)
        {
            return new FileInfo(path).Exists;
        }

    }
}
