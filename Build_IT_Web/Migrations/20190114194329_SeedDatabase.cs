using Build_IT_Web.Models;
using Build_IT_Web.Models.Enums;
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
                            $"VALUES ('{p.Name}', {p.Number}, '{p.Description}', {(int)p.ValueType}, '{p.Value}', '{p.DataValidator}', '{p.Unit}', {(int)p.Context}, '{p.GroupName}', '{p.AccordingTo}', '{p.Notes}', {(int)p.ValueOptionSetting}, {scriptIdSelection})");

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
                migrationBuilder.Sql($"DELETE FROM Scripts WHERE Name = '{s.Name}'");
        }

        private IEnumerable<Script> SetUpScript()
        {
            var script = new Script()
            {
                Name = "Steel tension",
                Description = "Calculate tension resistance. Base on [PN-EN-1993-1-1:2005 6.2.3.(2)a)].",
                Author = "Konrad Kania",
                AccordingTo = "PN-EN-1993-1-1:2005",
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


            yield return script;
        }
    }
}
