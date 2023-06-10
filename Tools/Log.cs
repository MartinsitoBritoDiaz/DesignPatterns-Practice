namespace Tools
{

    //Sealed (Sellado) to protect our class of being inherited
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;
        private static readonly object _protect = new object();

        public static Log GetInstance(string path)
        {
            //lock is useful when we want to protected one peace of code of execute in various threads at the same time
            //,so we use lock to protect, so only one thread can go inside at the same time
            lock (_protect)
            {
                _instance ??= new Log(path);
            }

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