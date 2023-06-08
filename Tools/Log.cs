namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;

        public static Log GetInstance(string path)
        {
            _instance ??= new Log(path);

            return _instance;
        }
        private Log(string path) 
        {
            _path = path;
        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }

    }
}