﻿using System;
using System.Xml.Serialization;

namespace MilitaryFaculty.Reporting.Structure.XmlDomain
{
    [Serializable]
    public class XCoefficient
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public double Value { get; set; }
    }
}