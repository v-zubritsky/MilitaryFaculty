﻿using System;
using MilitaryFaculty.Application.Handlers;
using MilitaryFaculty.Application.ViewModels;
using MilitaryFaculty.Common;
using MilitaryFaculty.Data;
using MilitaryFaculty.Domain;
using MilitaryFaculty.Presentation.Commands;
using MilitaryFaculty.Presentation.ViewModels;
using MilitaryFaculty.Presentation.Widgets.TreeView.Events;
using MilitaryFaculty.Reporting;
using MilitaryFaculty.Reporting.Excel;
using Dissertation = MilitaryFaculty.Domain.Dissertation;
using EfficiencyProposal = MilitaryFaculty.Domain.EfficiencyProposal;

namespace MilitaryFaculty.Application.AppStartup
{
    public class WorkWindowChangedEventArgs : EventArgs
    {
        public ViewModel OldValue { get; set; }
        public ViewModel NewValue { get; set; }

        public WorkWindowChangedEventArgs(ViewModel oldValue, ViewModel newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public class MainViewModel : ViewModel
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Cathedra> _cathedraRepository;
        private readonly IRepository<Conference> _conferenceRepository;
        private readonly IRepository<Exhibition> _exhibitionRepository;
        private readonly IRepository<Person> _professorRepository;
        private readonly IRepository<Publication> _publicationRepository;
        private readonly IRepository<CouncilParticipation> _councilParticipationRepository;
        private readonly IRepository<Dissertation> _dissertationRepository;
        private readonly IRepository<InventiveApplication> _inventiveApplicationRepository;
        private readonly IRepository<EfficiencyProposal> _efficiencyProposalRepository;

        private readonly IReportGenerator _reportGenerator;
        private readonly IExcelReportingService _excelReportingService;
        private readonly ViewModel _workWindow;
        private readonly IRepository<Research> _researchRepository;
        private readonly IRepository<ScienceRank> _scienceRankRepository;
        private readonly IRepository<ScienceRankMetricDefinition> _scienceRankMetricDefinitionRepository;
        private readonly IRepository<ScienceRankMetric> _scienceRankMetricRepository;

        public FacultyTreeViewModel FacultyTree { get; private set; }
        public RoutedCommands RoutedCommands { get; private set; }

        public event EventHandler<WorkWindowChangedEventArgs> WorkWindowChanged;

        public MainViewModel(IRepository<Book> bookRepository,
                             IRepository<Cathedra> cathedraRepository,
                             IRepository<Conference> conferenceRepository,
                             IRepository<Exhibition> exhibitionRepository,
                             IRepository<Person> professorRepository,
                             IRepository<Publication> publicationRepository,
                             IRepository<CouncilParticipation> councilParticipationRepository,
                             IRepository<Dissertation> dissertationRepository,
                             IRepository<InventiveApplication> inventiveApplicationRepository,
                             IRepository<EfficiencyProposal> efficiencyProposalRepository,
                             IRepository<Research> researchRepository,
                             IRepository<ScienceRank> scienceRankRepository,
                             IRepository<ScienceRankMetric> scienceRankMetricRepository,
                             IRepository<ScienceRankMetricDefinition> scienceRankMetricDefinitionRepository,
                             IExcelReportingService excelReportingService,
                             IReportGenerator reportGenerator)
        {
            _bookRepository = bookRepository;
            _cathedraRepository = cathedraRepository;
            _conferenceRepository = conferenceRepository;
            _exhibitionRepository = exhibitionRepository;
            _professorRepository = professorRepository;
            _publicationRepository = publicationRepository;
            _councilParticipationRepository = councilParticipationRepository;
            _dissertationRepository = dissertationRepository;
            _inventiveApplicationRepository = inventiveApplicationRepository;
            _researchRepository = researchRepository;
            _scienceRankRepository = scienceRankRepository;

            _excelReportingService = excelReportingService;
            _reportGenerator = reportGenerator;
            _scienceRankMetricRepository = scienceRankMetricRepository;
            _scienceRankMetricDefinitionRepository = scienceRankMetricDefinitionRepository;
            _efficiencyProposalRepository = efficiencyProposalRepository;

            _workWindow = new StartupViewModel();

            InitFacultyTree();
            InitRoutedCommands();
        }

        public ViewModel WorkWindow
        {
            get { return _workWindow; }
            internal set
            {
                var oldValue = _workWindow;

                if (SetValue("WorkWindow", () => _workWindow, value))
                {
                    OnWorkWindowChanged(oldValue, value);
                }
            }
        }

        private void OnWorkWindowChanged(ViewModel oldValue, ViewModel newValue)
        {
            var handler = WorkWindowChanged;
            if (handler != null)
            {
                handler(null, new WorkWindowChangedEventArgs(oldValue, newValue));
            }
        }

        private void FacultyTreeOnSelectedItemChanged(object sender, SelectedChangedEventArgs eventArgs)
        {
            var selected = eventArgs.NewValue;
            var model = selected.Model;

            if (model is Cathedra)
            {
                WorkWindow = new CathedraView.Root(model as Cathedra,
                    _scienceRankRepository);
            }
            else if (model is Person)
            {
                WorkWindow = new ProfessorView.Root(model as Person,
                    _conferenceRepository,
                    _publicationRepository,
                    _exhibitionRepository,
                    _bookRepository,
                    _councilParticipationRepository,
                    _dissertationRepository,
                    _inventiveApplicationRepository,
                    _efficiencyProposalRepository,
                    _researchRepository);
            }
            else
            {
                throw new Exception();
            }
        }

        private void InitFacultyTree()
        {
            FacultyTree = new FacultyTreeViewModel(_professorRepository, _cathedraRepository);
            FacultyTree.SelectedItemChanged += FacultyTreeOnSelectedItemChanged;
        }

        private void InitRoutedCommands()
        {
            RoutedCommands = new RoutedCommands();

            //todo get module from container
            var modules = new ICommandModule[]
                          {
                              new ProfessorHandlers(_professorRepository),
                              new ProfessorNavigation(this),
                              new PublicationHandlers(_publicationRepository),
                              new PublicationNavigation(this),
                              new ConferenceHandlers(_conferenceRepository),
                              new ConferenceNavigation(this),
                              new ExhibitionHandlers(_exhibitionRepository),
                              new ExhibitionNavigation(this),
                              new BookHandlers(_bookRepository),
                              new BookNavigation(this),
                              new DissertationHandlers(_dissertationRepository),
                              new DissertationNavigation(this),
                              new InventiveApplicationHandlers(_inventiveApplicationRepository),
                              new InventiveApplicationNavigation(this),
                              new EfficiencyProposalHandlers(_efficiencyProposalRepository),
                              new EfficiencyProposalNavigation(this),
                              new CouncilParticipationHandlers(_councilParticipationRepository),
                              new CouncilParticipationNavigation(this),
                              new ScienceRankHandlers(_scienceRankRepository, _scienceRankMetricRepository),
                              new ScienceRankNavigation(this, _scienceRankMetricDefinitionRepository),
                              new ResearchHandlers(_researchRepository),
                              new ResearchNavigation(this),
                              new NavigationHistory(this),
                              new ReportingHandlers(_cathedraRepository,
                                                    _professorRepository,
                                                    _excelReportingService,
                                                    _reportGenerator)
                          };

            modules.ForEach(m => m.LoadModule(RoutedCommands));
        }
    }
}