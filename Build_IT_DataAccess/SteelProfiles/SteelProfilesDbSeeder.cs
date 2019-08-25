using Build_IT_Data.Entities.SteelProfiles;
using Build_IT_Data.Entities.SteelProfiles.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Build_IT_DataAccess.SteelProfiles
{
    public static class SteelProfilesDbSeeder
    {
        public static void Seed()
        {
            var profileType = new ProfileType
            {
                Name = "IPE"
            };

            profileType.Parameters.Add(new Parameter
            {
                Name = "h",
                Unit = "mm",
                Description = "Height."
            });
            profileType.Parameters.Add(new Parameter
            {
                Name = "b",
                Unit = "mm",
                Description = "Width."
            });
            profileType.Parameters.Add(new Parameter
            {
                Name = "t_f_",
                Unit = "mm",
                Description = "Flange thickness."
            });
            profileType.Parameters.Add(new Parameter
            {
                Name = "t_w_",
                Unit = "mm",
                Description = "Web thickness."
            });
            profileType.Parameters.Add(new Parameter
            {
                Name = "r",
                Unit = "mm",
                Description = "Radius."
            });

            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "0",
                Y = "0",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b]",
                Y = "0",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b]",
                Y = "[t_f_]",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b] / 2 + [t_w_] / 2",
                Y = "[t_f_]",
                ChamferType = ChamferType.Round,
                ChamferX = "[r]"
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b] / 2 + [t_w_] / 2",
                Y = "[h] - [t_f_]",
                ChamferType = ChamferType.Round,
                ChamferX = "[r]"
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b]",
                Y = "[h] - [t_f_]",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b]",
                Y = "[h]",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "0",
                Y = "[h]",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "0",
                Y = "[h] - [t_f_]",
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b] / 2 - [t_w_] / 2",
                Y = "[h] - [t_f_]",
                ChamferType = ChamferType.Round,
                ChamferX = "[r]"
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "[b] / 2 - [t_w_] / 2",
                Y = "[t_f_]",
                ChamferType = ChamferType.Round,
                ChamferX = "[r]"
            });
            profileType.SectionPoints.Add(new SectionPoint
            {
                X = "0",
                Y = "[t_f_]",
            });

            var datas = new List<string>
            {
                "IPE 80,80,46,3.8,5.2,5",
                "IPE 100,100,55,4.1,5.7,7",
                "IPE 120,120,64,4.4,6.3,7",
            };

            foreach (var data in datas)
            {
                var values = data.Split(',');

                var profile = new SteelProfile
                {
                    Name = values[0]
                };

                int index = 0;
                foreach (var value in values.Skip(1))
                {
                    profile.ParametersValues.Add(new ParameterValue
                    {
                        Parameter = profileType.Parameters.ElementAt(index),
                        Value = Convert.ToDouble(value, CultureInfo.InvariantCulture)
                    });
                    index++;
                }               

                profileType.SteelProfiles.Add(profile);
            }          
        }
    }
}
