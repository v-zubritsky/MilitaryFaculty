﻿using System;

namespace MilitaryFaculty.Presentation.ViewModels
{
    public class EnumPropertyViewModel : PropertyViewModel
    {
        public EnumPropertyViewModel(Func<object> getter, Action<object> setter, string label)
            : base(getter, setter, label)
        {
            // Empty
        }
    }
}