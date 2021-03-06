﻿using System;
using MilitaryFaculty.Domain;
using MilitaryFaculty.Domain.Base;

namespace MilitaryFaculty.Data.Events
{
    public class ModifiedEntityEventArgs<T> : EventArgs
        where T : class, IUniqueEntity
    {
        public T ModifiedEntity { get; protected set; }

        public ModifiedEntityEventArgs(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ModifiedEntity = entity;
        }
    }
}