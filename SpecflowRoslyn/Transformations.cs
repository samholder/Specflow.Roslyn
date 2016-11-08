using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using TechTalk.SpecFlow;

namespace Specflow.Roslyn
{
    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation]
        public List<DiagnosticResult> TransformToDiagnostic(Table table)
        {
            List<DiagnosticResult> diagnostics = new List<DiagnosticResult>();
            foreach (var tableRow in table.Rows)
            {
                diagnostics.Add(new DiagnosticResult()
                {
                    Id = tableRow["Id"],
                    Message = tableRow["Message"],
                    Severity = (DiagnosticSeverity)Enum.Parse(typeof(DiagnosticSeverity), tableRow["Severity"]),
                    Locations = GetLocations(tableRow["Locations"])
                });
            }
            return diagnostics;
        }

        private DiagnosticResultLocation[] GetLocations(string locations)
        {
            List<DiagnosticResultLocation> resultLocations = new List<DiagnosticResultLocation>();
            foreach (var singleLocation in locations.Split(';'))
            {
                var locationParts = singleLocation.Split(',');
                resultLocations.Add(new DiagnosticResultLocation(locationParts[0], int.Parse(locationParts[1]), int.Parse(locationParts[2])));
            }

            return resultLocations.ToArray();
        }
    }
}
