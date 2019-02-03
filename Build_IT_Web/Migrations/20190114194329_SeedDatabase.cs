using Build_IT_Web.Core.Models;
using Build_IT_Web.Core.Models.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Build_IT_Web.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var scripts = SetUpScript();

            foreach (var s in scripts)
            {
                migrationBuilder.Sql("INSERT INTO Scripts (Name, Description, GroupName, Author, Added, Modified, AccordingTo, Notes, Version) " +
                    $"VALUES ('{s.Name}', '{s.Description}', '{s.GroupName}', '{s.Author}', '{s.Added}', '{s.Modified}', '{s.AccordingTo}', '{s.Notes}', '{s.Version}')");

                string scriptIdSelection = $"(SELECT ID FROM Scripts WHERE Name = '{s.Name}')";
                if (s.Tags != null)
                    foreach (var st in s.Tags)
                    {
                        migrationBuilder.Sql($"INSERT INTO Tags (Name) VALUES ('{st.Tag.Name}')");
                        
                        string tagIdSelection = $"(SELECT ID FROM Tags WHERE Name = '{st.Tag.Name}')";

                        migrationBuilder.Sql($"INSERT INTO ScriptTags (ScriptId, TagId) VALUES ({scriptIdSelection}, {tagIdSelection})");
                    }

                if (s.Parameters != null)
                    foreach (var p in s.Parameters)
                    {
                        string parameterIdSelection = $"(SELECT ID FROM Parameters WHERE Name = '{p.Name}')";

                        migrationBuilder.Sql("INSERT INTO Parameters (Name, Number, Description, ValueType, Value, DataValidator, Unit, Context, GroupName, AccordingTo, Notes, ValueOptionSetting, ScriptId ) " +
                            $"VALUES ('{p.Name}', {p.Number}, '{p.Description}', {(int)p.ValueType}, '{p.Value?.Replace("\'", "\'\'")}', '{p.DataValidator}', '{p.Unit}', {(int)p.Context}, '{p.GroupName}', '{p.AccordingTo}', '{p.Notes}', {(int)p.ValueOptionSetting}, {scriptIdSelection})");

                        if (p.ValueOptions != null)
                            foreach (var vo in p.ValueOptions)
                                migrationBuilder.Sql("INSERT INTO ValueOptions (Value, Description, ParameterId)" +
                                    $"VALUES ('{vo.Value}', '{vo.Description}', {parameterIdSelection})");

                        if (p.NestedScripts != null)
                            foreach (var alt in p.NestedScripts)
                                migrationBuilder.Sql("INSERT INTO AlternativeScripts (ScriptName, ParameterId)" +
                                    $"VALUES ('{alt.ScriptName}', {parameterIdSelection})");
                    }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var scripts = SetUpScript();

            foreach (var s in scripts)
            {
                migrationBuilder.Sql($"DELETE FROM Scripts WHERE Name = '{s.Name}'");
                foreach (var tag in s.Tags)
                {
                    migrationBuilder.Sql($"DELETE FROM Tags WHERE Name = '{tag.Tag.Name}'");
                }
            }
        }

        private IEnumerable<Script> SetUpScript()
        {
            yield return SteelTensionScript();
            yield return CompressiveStrengthAtAgeScript();
            yield return MeanCompressiveStrengthScript();
            yield return ShearResistanceWithoutShearReinforcementScript();
        }

        private Script SteelTensionScript()
        {
            var script = new Script()
            {
                Name = "Steel tension",
                Description = "Calculate tension resistance.",
                Author = "Konrad Kania",
                AccordingTo = "PN-EN-1993-1-1:2005 6.2.3.(2)a)",
                GroupName = "Eurocode 3",
                Notes = "Net area not included.",
                Version = 1.0f,
                Added = DateTime.Now,
                Modified = DateTime.Now,
                Tags = new Collection<ScriptTag>()
                {
                    new ScriptTag(){ Tag = new Tag(){ Name = "Eurocode 1993" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Steel" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Tension" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Resistance" }},
                },
                Parameters = new Collection<Parameter>()
                {
                    new Parameter()
                    {
                        Number = 1,
                        Name = "N_Ed_",
                        Description = "Normal design force at calculated position.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "kN",
                    },
                    new Parameter()
                    {
                        Number = 2,
                        Name = "A",
                        Description = "Area of the section.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "cm^2^",
                    },
                    new Parameter()
                    {
                        Number = 3,
                        Name = "f_y_",
                        Description = "Yield strength.",
                        ValueType = ValueTypes.Number,
                        ValueOptions = new Collection<ValueOption>()
                        {
                           new ValueOption() { Value = "235" },
                           new ValueOption() { Value = "275" },
                           new ValueOption() { Value = "355" },
                           new ValueOption() { Value = "420" },
                           new ValueOption() { Value = "440" },
                           new ValueOption() { Value = "460" },

                        },
                        ValueOptionSetting = ValueOptionSettings.UserInput,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "MPa",
                    },
                    new Parameter()
                    {
                        Number = 4,
                        Name = "γ_M0_",
                        Description = "Partial safety factor.",
                        Value = "1.0",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.StaticData,
                        Unit = "",
                    },
                    new Parameter()
                    {
                        Number = 5,
                        Name = "N_pl,Rd_",
                        Value = "[A]*[f_y_]/[γ_M0_]/10",
                        Description = "Design plastic resistance of the gross cross-section.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "kN",
                    },
                    new Parameter()
                    {
                        Number = 10,
                        Name = "Resistance",
                        Value = "[N_Ed_]/[N_pl,Rd_]*100",
                        Description = "Resistance of the element loaded with normal force.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "%",
                    }
                }
            };

            return script;
        }

        private Script CompressiveStrengthAtAgeScript()
        {
            var cementTypes = new List<ValueOption>();
            cementTypes.Add(new ValueOption()
            {
                Value = "CEM 42,5R",
                Description = "Rapid hardening high strength cements (R)."
            });
            cementTypes.Add(new ValueOption()
            {
                Value = "CEM 52,5N",
                Description = "Rapid hardening high strength cements (R)."
            });
            cementTypes.Add(new ValueOption()
            {
                Value = "CEM 52,5R",
                Description = "Rapid hardening high strength cements (R)."
            });
            cementTypes.Add(new ValueOption()
            {
                Value = "CEM 32,5R",
                Description = "Normal and rapid hardening cements (N)."
            });
            cementTypes.Add(new ValueOption()
            {
                Value = "CEM 42,5",
                Description = "Normal and rapid hardening cements (N)."
            });
            cementTypes.Add(new ValueOption()
            {
                Value = "CEM 32,5N",
                Description = "Slow hardening cements (S)."
            });

            var script = new Script()
            {
                Name = "Compressive strength of concrete at an age",
                Description = "Calculate compressive strength of concrete at an age.",
                Author = "Konrad Kania",
                AccordingTo = "PN-EN-1992-1-1:2002 3.1.2",
                GroupName = "Eurocode 2",
                Notes = "Calculate compressive strength at any age greater than 5 days.",
                Version = 1.0f,
                Added = DateTime.Now,
                Modified = DateTime.Now,
                Tags = new Collection<ScriptTag>()
                {
                    new ScriptTag(){ Tag = new Tag(){ Name = "Eurocode 1992" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Concrete" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Materials" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Strength" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Time" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Compressive" }},
                },
                Parameters = new Collection<Parameter>()
                {
                    new Parameter()
                    {
                        Number = 1,
                        Name = "f_ck_",
                        DataValidator = "[f_ck_]>0",
                        Description = "Characteristic compressive cylinder strength of concrete at 28 days.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 2,
                        Name = "f_cm_",
                        DataValidator = "[f_cm_]>0",
                        Description = "Mean compressive strength at 28 days.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "MPa",
                    },
                    new Parameter()
                    {
                        Number = 3,
                        Name = "cement_type_",
                        Description = "Type of cement.",
                        ValueOptions = cementTypes,
                        ValueType = ValueTypes.Text,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 4,
                        Name = "t",
                        DataValidator = "[t]>3",
                        Description = "Age of the concrete in days.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "day"
                    },
                    new Parameter()
                    {
                        Number = 10,
                        Name = "s",
                        Value = "if(in([cement_type_],'CEM 42,5R','CEM 52,5N', 'CEM 52,5R') == true,0.2," +
                        "if(in([cement_type_],'CEM 32,5R','CEM 42,5') == true,0.25," +
                        "if(in([cement_type_],'CEM 32,5N') == true,0.38, ERROR('Invalid cement type.'))))",
                        Description = "Coefficient which depends on the type of cement.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 11,
                        Name = "β_cc_(t)",
                        Value = "Exp([s]*(1-Sqrt(28/[t])))",
                        Description = "Coefficient which depends on the age of the concrete t.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 12,
                        Name = "f_cm_(t)",
                        Value = "[β_cc_(t)]*[f_cm_]",
                        Description = "Mean concrete compressive strength at an age of t days.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 13,
                        Name = "f_ck_(t)",
                        Value = "if([t]>=28,[f_ck_],if([t]>3,[f_cm_(t)]-8,ERROR('Not even 3 days.')))",
                        Description = "Concrete compressive strength at time t.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "MPa"
                    }
                }
            };

            return script;
        }

        private Script MeanCompressiveStrengthScript()
        {
            var script = new Script()
            {
                Name = "Mean compresive strength of concrete at 28 days",
                Description = "Calculate mean compressive strength of concrete at 28 days.",
                Author = "Konrad Kania",
                AccordingTo = "PN-EN-1992-1-1:2002 Table 3.1",
                GroupName = "Eurocode 2",
                Version = 1.0f,
                Added = DateTime.Now,
                Modified = DateTime.Now,
                Tags = new Collection<ScriptTag>()
                {
                    //new ScriptTag(){ Tag = new Tag(){ Name = "Eurocode 1992" }},
                    //new ScriptTag(){ Tag = new Tag(){ Name = "Concrete" }},
                    //new ScriptTag(){ Tag = new Tag(){ Name = "Materials" }},
                    //new ScriptTag(){ Tag = new Tag(){ Name = "Strength" }},
                    //new ScriptTag(){ Tag = new Tag(){ Name = "Compressive" }},
                },
                Parameters = new Collection<Parameter>()
                {
                    new Parameter()
                    {
                        Number = 1,
                        Name = "f_ck_",
                        DataValidator = "[f_ck_]>0",
                        Description = "Characteristic compressive cylinder strength of concrete at 28 days.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 2,
                        Name = "f_cm_",
                        DataValidator = "[f_cm_]>0",
                        Description = "Mean compressive strength at 28 days.",
                        Value = "[f_ck_]+8",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "MPa"
                    }
                }
            };

            return script;
        }

        private Script ShearResistanceWithoutShearReinforcementScript()
        {
            var script = new Script()
            {
                Name = "Shear resistance without shear reinforcement",
                Description = "Calculate shear resistance without shear reinforcement.",
                Author = "Konrad Kania",
                AccordingTo = "PN-EN-1992-1-1:2002 6.2.2",
                GroupName = "Eurocode 2",
                Notes = "Calculate compressive strength at any age greater than 5 days.",
                Version = 1.0f,
                Added = DateTime.Now,
                Modified = DateTime.Now,
                Tags = new Collection<ScriptTag>()
                {
                   // new ScriptTag(){ Tag = new Tag(){ Name = "Eurocode 1992" }},
                   // new ScriptTag(){ Tag = new Tag(){ Name = "Concrete" }},
                    new ScriptTag(){ Tag = new Tag(){ Name = "Shear" }},
                   // new ScriptTag(){ Tag = new Tag(){ Name = "Resistance" }},
                },
                Parameters = new Collection<Parameter>()
                {
                    new Parameter()
                    {
                        Number = 1,
                        Name = "V_Ed_",
                        Description = "Shear force at calculated position.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "kN"
                    },
                    new Parameter()
                    {
                        Number = 2,
                        Name = "f_ck_",
                        Description = "Mean compressive strength at 28 days.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 4,
                        Name = "b_w_",
                        Description = "Section width.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "mm"
                    },
                    new Parameter()
                    {
                        Number = 5,
                        Name = "d",
                        Description = "Effective depth of a cross-section.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "mm"
                    },
                    new Parameter()
                    {
                        Number = 6,
                        Name = "A_sl_",
                        Description = "Area of the tensile reinforcement, which extends ≥ (lbd + d) beyond the section considered.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "cm^2^"
                    },
                    new Parameter()
                    {
                        Number = 7,
                        Name = "N_Ed_",
                        Description = "Axial force in the cross-section due to loading or prestressing in newtons (NEd>0 for compression)." +
                        " The influence of imposed deformations on NEd may be ignored.",
                        Value = "0",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "N"
                    },
                    new Parameter()
                    {
                        Number = 8,
                        Name = "A_c_",
                        Description = "Area of concrete cross section [mm2].",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Editable | ParameterOptions.Visible,
                        Unit = "mm^2^"
                    },
                    new Parameter()
                    {
                        Number = 10,
                        Name = "k_1_",
                        Value = "0.15",
                        Description = "Coefficient",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.StaticData,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 11,
                        Name = "γ_c_",
                        Value = "1.4",
                        Description = "Partial factors for concrete.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.StaticData,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 20,
                        Name = "C_Rd,c_",
                        Value = "0.18/[γ_c_]",
                        Description = "Coefficient.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 21,
                        Name = "k",
                        Value = "Min(1+Sqrt(200/[d]),2)",
                        Description = "Coefficient.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 22,
                        Name = "ρ_l_",
                        Value = "Min(0.02,[A_sl_]/([b_w_]*[d]))",
                        Description = "Reinforcement ratio for longitudinal reinforcement.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "-"
                    },
                    new Parameter()
                    {
                        Number = 23,
                        Name = "f_cd_",
                        Value = "[f_ck_]/[γ_c_]",
                        Description = "Design value of concrete compressive strength.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 24,
                        Name = "σ_cp_",
                        Value = "Min([N_Ed_]/[A_c_],0.2*[f_cd_])",
                        Description = "Compressive stress in the concrete from axial load or prestressing.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 25,
                        Name = "v_min_",
                        Value = "0.035*Pow([k],3/2)*Pow([f_ck_],1/2)",
                        Description = "Coefficient.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "MPa"
                    },
                    new Parameter()
                    {
                        Number = 26,
                        Name = "V_Rd,c_",
                        Value = "Max(([v_min_]+[k_1_]*[σ_cp_])*[b_w_]*[d]," +
                        "([C_Rd,c_]*[k]*Pow(100*[ρ_l_]*[f_ck_],1/3)+[k_1_]*[σ_cp_])*[b_w_]*[d])" +
                        "/1000",
                        Description = "Design value for the shear resistance.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "kN"
                    },
                    new Parameter()
                    {
                        Number = 27,
                        Name = "Resistance",
                        Value = "[V_Ed_]/[V_Rd,c_]*100",
                        Description = "Resistance of the element without shear reinforcement.",
                        ValueType = ValueTypes.Number,
                        Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                        Unit = "%"
                    },
                }
            };

            return script;
        }

    }
}
