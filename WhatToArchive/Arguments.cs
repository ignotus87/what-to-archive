using System.IO;
using System.Linq;

namespace WhatToArchive
{
    class Arguments
    {
        public string InvalidUseMessage { get; private set; }
        public bool IsValid => string.IsNullOrEmpty(InvalidUseMessage);
        public string Folder => _args?.FirstOrDefault();
        private string[] _args;
        public bool IsLengthValid => _args?.Length == 1 || _args?.Length == 2;
        public bool IsNoPauseOptionActivated => _args?.Length == 2 && _args[1] == "/nopause";

        public Arguments(string[] args)
        {
            _args = args;

            CheckLength();
         
            if (!IsLengthValid) { return; }

            CheckFolder();            
        }

        private void CheckFolder()
        {
            if (!Directory.Exists(Folder))
            {
                InvalidUseMessage = "Path in argument 1 does not exist.";
            }
        }

        private void CheckLength()
        {
            if (!IsLengthValid)
            {
                InvalidUseMessage = "Usage: WhatToArchive.exe path";
            }
        }
    }
}
