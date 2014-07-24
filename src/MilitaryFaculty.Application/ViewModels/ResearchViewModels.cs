﻿using System;
using System.Collections.Generic;
using MilitaryFaculty.Application.ViewModels.Base;
using MilitaryFaculty.Common;
using MilitaryFaculty.Domain;
using MilitaryFaculty.Presentation.Attributes;
using MilitaryFaculty.Presentation.ViewBehaviours;
using MilitaryFaculty.Presentation.ViewModels;

namespace MilitaryFaculty.Application.ViewModels
{
    internal static class ResearchView
    {
        internal class Root : EntityRootViewModel<Research>
        {
            public Root(Research model)
                : base(model)
            {
                HeaderViewModel = new Header();
            }

            protected override IEnumerable<ViewModel<Research>> GetViewModels()
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
                get { return "Информация о НИР"; }
            }
        }

        internal class Add : AddEntityViewModel<Research>
        {
            public Add(Research model) : base(model) { }

            public override string Title
            {
                get { return "Добавить НИР "; }
            }

            protected override IEnumerable<ViewModel<Research>> GetViewModels()
            {
                return new[]
                       {
                           new MainInfo(Model)
                       };
            }
        }

        internal class MainInfo : EntityViewModel<Research>
        {
            public MainInfo(Research model)
                : base(model)
            {
                this.Editable(GlobalCommands.Save<Research>());
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
                get { return Model.CreatedAt; }
                set { SetModelProperty(m => m.CreatedAt, value); }
            }
        }

        internal class ListItem : ListItemViewModel<Research>
        {
            public ListItem(Research model)
                : base(model)
            {
                InitCommands();
                TooltipViewModel = new MainInfo(Model);
            }

            public override string PrimaryInfo
            {
                get { return Model.CreatedAt.ToShortDateString(); }
            }

            public override string SecondaryInfo
            {
                get { return Model.Name; }
            }

            private void InitCommands()
            {
                Commands.AddRange(new[]
                                  {
                                      CreateBrowseDetailsCommand(),
                                      CreateRemoveCommand()
                                  });
            }

            private ImagedCommandViewModel CreateRemoveCommand()
            {
                const string tooltip = "Удалить НИР";
                const string imageSource = @"..\Content\remove.png";

                return new ImagedCommandViewModel(GlobalCommands.Remove<Research>(),
                                                  Model,
                                                  tooltip,
                                                  imageSource);
            }

            private ImagedCommandViewModel CreateBrowseDetailsCommand()
            {
                const string tooltip = "Подробно";
                const string imageSource = @"..\Content\details.png";

                return new ImagedCommandViewModel(GlobalCommands.BrowseDetails<Research>(),
                                                  Model,
                                                  tooltip,
                                                  imageSource);
            }

            public static ListItem FromModel(Research model)
            {
                return new ListItem(model);
            }
        }
    }
}