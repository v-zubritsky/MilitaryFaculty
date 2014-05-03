﻿using MilitaryFaculty.Domain;
using MilitaryFaculty.Presentation.Core.ViewModels;

namespace MilitaryFaculty.Presentation.ViewModels
{
    public class ProfessorHeaderViewModel : ViewModel<Professor>
    {
        public ProfessorHeaderViewModel(Professor model)
            : base(model)
        {
            // Empty
        }

        public string FullName
        {
            get { return Model.FullName.ToString(); }
        }

        public MilitaryRank MilitaryRank
        {
            get { return Model.MilitaryRank; }
            set { SetModelProperty(m => m.MilitaryRank, value); }
        }
    }
}