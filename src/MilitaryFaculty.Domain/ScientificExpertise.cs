﻿using System;
using MilitaryFaculty.Domain.Base;

namespace MilitaryFaculty.Domain
{
    public enum ScientificExpertiseType
    {
        StatuteDocument,
        SchoolBook,
        Tutorial
    }

    // ReSharper disable DoNotCallOverridableMethodsInConstructor
    // Properties are virtual only for EntityFramework
    public class ScientificExpertise: UniqueEntity
    {
        public ScientificExpertise()
        {
            CreatedAt = DateTime.Now;
        }

        public virtual string Name { get; set; }
        public virtual Person Author { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual ScientificExpertiseType Type { get; set; }
    }
    // ReSharper restore DoNotCallOverridableMethodsInConstructor
}