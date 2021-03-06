﻿using System;
using MilitaryFaculty.Common;
using MilitaryFaculty.Domain.Base;
using MilitaryFaculty.Resources;

namespace MilitaryFaculty.Domain
{
    [LocalizedEnum(typeof(EnumStrings))]
    public enum ResearchMaintainState
    {
        NotPerformed,
        Performed
    }

    // ReSharper disable DoNotCallOverridableMethodsInConstructor
    // Properties are virtual only for EntityFramework
    public class Research: UniqueEntity
    {
        public Research()
        {
            CreatedAt = DateTime.Now;
        }

        public string Name { get; set; }
        public Person Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public ResearchMaintainState MaintainState { get; set; }
    }
    // ReSharper restore DoNotCallOverridableMethodsInConstructor
}