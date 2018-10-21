using System;
using System.IO;

namespace WhatToArchive
{
    class FolderVisitor
    {
        public string Folder { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public FolderVisitor(string folder)
        {
            Folder = folder;
        }

        public void VisitAll()
        {
            VisitFolder(Folder);
        }

        private void VisitFolder(string folder)
        {
            foreach (string subFolder in Directory.EnumerateDirectories(folder))
            {
                VisitFolder(subFolder);
            }

            foreach (string fileName in Directory.EnumerateFiles(folder))
            {
                var lastWriteTime = File.GetLastWriteTime(fileName);
                if (lastWriteTime > LastModifiedDate) { LastModifiedDate = lastWriteTime; }
            }
        }
    }
}
