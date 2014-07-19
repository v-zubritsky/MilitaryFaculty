﻿using System;
using MilitaryFaculty.Common;
using MilitaryFaculty.Domain.Base;
using MilitaryFaculty.Domain.Resources;

namespace MilitaryFaculty.Domain
{
    [LocalizedEnum(typeof(EnumStrings))]
    public enum AwardType
    {
        FirstDegree,
        SecondDegree,
        ThirdDegree,
        WithoutDegree
    }

    // ReSharper disable DoNotCallOverridableMethodsInConstructor
    // Properties are virtual only for EntityFramework
    public class Exhibition : UniqueEntity, IImitator<Exhibition>
    {
        public static int NameMaxLength = 50;

        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Professor Participant { get; set; }
        public virtual AwardType AwardType { get; set; }
        public virtual EventLevel EventLevel { get; set; }

        public Exhibition()
        {
            Id = Guid.Empty;
            Name = String.Empty;
            Date = DateTime.Now;
        }

        public Exhibition(Exhibition other)
            : this()
        {
            Imitate(other);
        }

        public void Imitate(Exhibition other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            AwardType = other.AwardType;
            Date = other.Date;
            Name = other.Name;
            Participant = other.Participant;
        }
    }
    // ReSharper restore DoNotCallOverridableMethodsInConstructor
}