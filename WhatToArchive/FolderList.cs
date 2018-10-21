using System;
using System.Collections.Generic;
using System.IO;

namespace WhatToArchive
{
    class FolderAge
    {
        public List<KeyValuePair<string, DateTime>> SubFolderAges;
        private string _path;

        public FolderAge(string path)
        {
            _path = path;

            FillSubFolders();
        }

        private void FillSubFolders()
        {
            SubFolderAges = new List<KeyValuePair<string, DateTime>>();

            foreach(string subFolder in Directory.EnumerateDirectories(_path))
            {
                var visitor = new FolderVisitor(subFolder);
                visitor.VisitAll();

                var subFolderShortName = subFolder.Substring(subFolder.LastIndexOf('\\') + 1);
                SubFolderAges.Add(new KeyValuePair<string, DateTime>(subFolderShortName, visitor.LastModifiedDate));
            }  
        }
    }
}
