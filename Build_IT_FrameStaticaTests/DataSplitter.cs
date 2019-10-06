using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Build_IT_FrameStaticaTests
{
    public static class DataSplitter
    {
        #region Public_Methods

        public static IEnumerable SplitData(short spanNumber, string fileName)
        {
            var valuesData = GetDataFromFile(fileName);
            var split = valuesData.Split(';');
            var organizedData = new List<Data>();

            for (int i = 0; i < split.Length; i += 8)
            {
                var data = new Data();

                data.Fx = Convert.ToDouble(split[i + 3].Replace(',', '.'), CultureInfo.InvariantCulture);
                data.Fz = Convert.ToDouble(split[i + 4].Replace(',', '.'), CultureInfo.InvariantCulture);
                data.My = Convert.ToDouble(split[i + 5].Replace(',', '.'), CultureInfo.InvariantCulture);
                data.Ux = Convert.ToDouble(split[i + 6].Replace(',', '.'), CultureInfo.InvariantCulture);
                data.Uz = Convert.ToDouble(split[i + 7].Replace(',', '.'), CultureInfo.InvariantCulture);

                if (split[i + 1].Contains("początek"))
                    data.Position = 0;
                else if (split[i + 1].Contains("koniec"))
                    data.LastOne = true;
                else
                    SetPosition(split, i, data);

                organizedData.Add(data);
            }

            return GroupSamePositions(spanNumber, organizedData);
        }

        #endregion // Public_Methods

        #region Private_Methods
        
        private static string GetDataFromFile(string fileName)
        {
            var path = @".\FrameData\" + fileName + ".csv";
            string[] fileData = File.ReadAllLines(path)
                .Skip(1)
                .TakeWhile(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

            return string.Join(';', fileData);
        }


        private static void SetPosition(string[] split, int i, Data data)
        {
            var positionString = new String(split[i + 1].Where(s => Char.IsDigit(s) || s == ',').ToArray());
            data.Position = Convert.ToDouble(positionString.Replace(',', '.'), CultureInfo.InvariantCulture);

            if (split[i + 1].Contains("(+)"))
                data.Positive = true;
            else if (split[i + 1].Contains("(-)"))
                data.Positive = false;
        }

        private static IEnumerable GroupSamePositions(short spanNumber, List<Data> organizedData)
        {

            Data toBeAdded = null;
            foreach (var data in organizedData)
            {
                if (toBeAdded != null && toBeAdded.Position == data.Position)
                    yield return new TestCaseData(spanNumber, data.Position,
                        (data.Fx + toBeAdded.Fx) / 2,
                        (data.Fz + toBeAdded.Fz) / 2,
                        (data.My + toBeAdded.My) / 2,
                        (data.Ux + toBeAdded.Ux) / 2,
                        (data.Uz + toBeAdded.Uz) / 2,
                        data.LastOne);
                else if (data.Positive == true || data.Positive == false)
                    toBeAdded = data;
                else
                    yield return new TestCaseData(spanNumber, data.Position, data.Fx, data.Fz, data.My, data.Ux, data.Uz, data.LastOne);
            }
        }

        #endregion // Private_Methods
    }
}
