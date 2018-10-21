using System;
using System.Linq;

namespace WhatToArchive
{
    class Program
    {
        private static Arguments _arguments;

        static void Main(string[] args)
        {
            _arguments = new Arguments(args);

            if (!_arguments.IsValid)
            {
                Console.WriteLine(_arguments.InvalidUseMessage);
                return;
            }

            ListFolder();
        }

        private static void ListFolder()
        {
            var folderList = new FolderAge(_arguments.Folder);

            foreach (var subFolder in folderList.SubFolderAges.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{subFolder.Key,50} - {subFolder.Value}");
            }

            if (_arguments.IsNoPauseOptionActivated) { return; }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
