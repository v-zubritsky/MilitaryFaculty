﻿using System;
using MilitaryFaculty.Domain;
using MilitaryFaculty.Presentation.Custom;
using MilitaryFaculty.Presentation.Infrastructure;

namespace MilitaryFaculty.Presentation.ViewModels
{
    public class ExhibitionInfoViewModel : EntityViewModel<Exhibition>
    {
        #region Class Properties

        public override string Title
        {
            get { return "Базовая информация"; }
        }

        [TextProperty(Label = "Название:")]
        public string Name
        {
            get { return Model.Name; }
            set { SetModelProperty(m => m.Name, value); }
        }

        [DateProperty(Label = "Дата проведения:")]
        public DateTime Date
        {
            get { return Model.Date; }
            set { SetModelProperty(m => m.Date, value); }
        }

        [EnumProperty(Label = "Награда:")]
        public AwardType AwardType
        {
            get { return Model.AwardType; }
            set { SetModelProperty(m => m.AwardType, value); }
        }

        #endregion // Class Properties

        #region Class Constructors

        public ExhibitionInfoViewModel(Exhibition model)
            : base(model)
        {
            var editCommands = new EditableViewBehaviour<Exhibition>(Do.Conference.Update, Model);
            editCommands.Inject(this);
        }

        #endregion // Class Constructors
    }
}