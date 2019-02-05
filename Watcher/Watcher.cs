using System;
using System.IO;

namespace Watcher
{
    class Watcher
    {
        private string path;

        public Watcher(string path)
        {
            this.path = path;
        }

        internal void Loop()
        {
            using (var observer = new FileSystemWatcher())
            {
                observer.Path = path; 
                observer.NotifyFilter = (NotifyFilters.FileName | NotifyFilters.LastWrite);
                observer.Filter = "*.min.js";
                observer.Changed += OnChangeFile;
                observer.EnableRaisingEvents = true;

                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChangeFile(object source, FileSystemEventArgs e)
        {
            WatcherChangeTypes type = e.ChangeType;

            Console.WriteLine(new Hasher(e.FullPath).GetHash());
        }
    }
}
