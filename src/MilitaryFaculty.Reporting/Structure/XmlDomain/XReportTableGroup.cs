﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MilitaryFaculty.Reporting.Structure.XmlDomain
{
    [Serializable]
    [XmlType(TypeName = "Group")]
    public class XReportTableGroup
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("Formulas")]
        [XmlArrayItem("id", typeof (int))]
        public List<int> Formulas { get; set; }
    }
}