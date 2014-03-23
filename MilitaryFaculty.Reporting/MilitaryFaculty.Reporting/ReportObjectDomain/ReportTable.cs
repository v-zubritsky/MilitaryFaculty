﻿using System;
using System.Collections.Generic;
using MilitaryFaculty.Reporting.Data;
using MilitaryFaculty.Reporting.XmlDomain;

namespace MilitaryFaculty.Reporting.ReportObjectDomain
{
    public class ReportTable
    {
        public string Name { get; private set; }
        public ICollection<ReportFormulasGroup> FormulasGroups { get; private set; }

        public ReportTable(XReportTable xmlTable, 
                           IFormulaProvider formulaProvider,
                           ReportDataProvider reportDataProvider)
        {
            if (xmlTable == null)
            {
                throw new ArgumentNullException("xmlTable");
            }
            if (formulaProvider == null)
            {
                throw new ArgumentNullException("formulaProvider");
            }
            if (reportDataProvider == null)
            {
                throw new ArgumentNullException("reportDataProvider");
            }

            Name = xmlTable.Name;
            FormulasGroups = new List<ReportFormulasGroup>();

            foreach (var xmlGroup in xmlTable.Groups)
            {
                var reportGroup = new ReportFormulasGroup(xmlGroup, formulaProvider, reportDataProvider);
                FormulasGroups.Add(reportGroup);
            }
        }
    }
}
