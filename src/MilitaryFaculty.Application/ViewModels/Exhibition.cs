﻿using System;
using System.Collections.Generic;
using MilitaryFaculty.Application.Custom;
using MilitaryFaculty.Application.ViewModels.Base;
using MilitaryFaculty.Domain;
using MilitaryFaculty.Presentation.Attributes;
using MilitaryFaculty.Presentation.ViewModels;

namespace MilitaryFaculty.Application.ViewModels
{
    internal static class ExhibitionView
    {
        internal class Root : EntityRootViewModel<Exhibition>
        {
            public Root(Exhibition model)
                : base(model)
            {
                HeaderViewModel = new Header();
            }

            protected override IEnumerable<ViewModel<Exhibition>> GetViewModels()
            {
                return new[]
                       {
                           new MainInfo(Model)
                       };
            }
        }

        internal class Header : ViewModel
        {
            public override string Title
            {
                get { return "Информация о научной выставке"; }
            }
        }

        internal class Add : AddEntityViewModel<Exhibition>
        {
            public Add(Exhibition model) : base(model) { }

            public override string Title
            {
                get { return "Добавить научную выставку "; }
            }
            
            protected override IEnumerable<ViewModel<Exhibition>> GetViewModels()
            {
                return new[]
                       {
                           new MainInfo(Model)
                       };
            }
        }

        internal class MainInfo : EntityViewModel<Exhibition>
        {
            public MainInfo(Exhibition model)
                : base(model)
            {
                this.Editable(GlobalCommands.Save<Exhibition>());
            }

            public override string Title
            {
                get { return "Основная информация"; }
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

            [EnumProperty(Label = "Уровень мероприятия:")]
            public EventLevel EventLevel
            {
                get { return Model.EventLevel; }
                set { SetModelProperty(m => m.EventLevel, value); }
            }

            [EnumProperty(Label = "Награда:")]
            public ExhibitionAward ExhibitionAward
            {
                get { return Model.Award; }
                set { SetModelProperty(m => m.Award, value); }
            }
        }

        internal class ListItem : ListItemViewModel<Exhibition>
        {
            public ListItem(Exhibition model)
                : base(model)
            {
                TooltipViewModel = new MainInfo(Model);

                this.Browsable(GlobalCommands.BrowseDetails<Exhibition>());
                this.Removable(GlobalCommands.Remove<Exhibition>());
            }

            public override string PrimaryInfo
            {
                get { return GetCreationDate(); }
            }

            public override string SecondaryInfo
            {
                get { return Model.Name; }
            }

            public static ListItem FromModel(Exhibition model)
            {
                return new ListItem(model);
            }

            private string GetCreationDate()
            {
                return Model.Date.ToShortDateString();
            }
        }
    }
}