using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.Models
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupported(string fileName) 
            => AcceptedFileTypes.Any(aft => aft == Path.GetExtension(fileName).ToLower());

    }
}
