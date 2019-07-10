using System.IO;
using System.Linq;

namespace Build_IT_Data.Entities.Scripts
{
    public class FigureSettings
    {
        #region Properties
        
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        #endregion // Properties

        #region Public_Methods
        
        public bool IsSupported(string fileName)
            => AcceptedFileTypes.Any(aft => aft == Path.GetExtension(fileName).ToLower());

        #endregion // Public_Methods
    }
}
