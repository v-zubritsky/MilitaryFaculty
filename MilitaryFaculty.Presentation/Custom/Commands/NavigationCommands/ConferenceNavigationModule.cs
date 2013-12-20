﻿using System;
using MilitaryFaculty.Domain;
using MilitaryFaculty.Presentation.Infrastructure;
using MilitaryFaculty.Presentation.ViewModels;

namespace MilitaryFaculty.Presentation.Custom
{
    public class ConferenceNavigationModule : BaseNavigationModule
    {
        #region Class Constructors

        public ConferenceNavigationModule(MainViewModel viewModel)
            : base(viewModel)
        {
            // Empty
        }

        #endregion // Class Constructors

        #region Class Public Methods

        public override void RegisterModule(CommandContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("sink");
            }

            container.RegisterCommand<Professor>(Browse.Conference.Add,
                                                 OnBrowseConferenceAdd);

            container.RegisterCommand<Conference>(Browse.Conference.Details,
                                                  OnBrowseConferenceDetails);
        }

        #endregion // Class Public Methods

        #region Class Private Methods

        private void OnBrowseConferenceAdd(Professor curator)
        {
            if (curator == null)
            {
                throw new ArgumentNullException("curator");
            }

            var model = new Conference
                        {
                            Curator = curator,
                        };

            ViewModel.WorkWindow = new AddConferenceViewModel(model);
        }

        private void OnBrowseConferenceDetails(Conference conference)
        {
            if (conference == null)
            {
                throw new ArgumentNullException("conference");
            }

            ViewModel.WorkWindow = new ConferenceRootViewModel(conference);
        }

        #endregion // Class Private Methods
    }
}