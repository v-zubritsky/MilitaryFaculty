﻿using MilitaryFaculty.Extensions;

namespace MilitaryFaculty.Logic.DataProviders
{
    public class CustomDataProvider : IDataProvider
    {
        #region Class Public Argument Methods

        [FormulaArgument("PlanDocsOrg")]
        public double PlanningDocumentsOrganization()
        {
            return 1;
        }

        [FormulaArgument("ResTopicsOrg")]
        public double ResearchTopicsOrganization()
        {
            return 2;
        }

        [FormulaArgument("ProfsOrg")]
        public double ProfessorsOrganization()
        {
            return 3;
        }

        [FormulaArgument("IntConfOrg")]
        public double InternationalConferencesOrganization()
        {
            return 4;
        }

        [FormulaArgument("RepConfOrg")]
        public double RepublicanConferenceOrganization()
        {
            return 5;
        }

        [FormulaArgument("UnConfOrg")]
        public double UniversityConferenceOrganization()
        {
            return 1;
        }

        [FormulaArgument("RepSemOrg")]
        public double RepablicanSeminarOrganization()
        {
            return 2;
        }

        [FormulaArgument("UnSemOrg")]
        public double UniversitySeminarOrganization()
        {
            return 3;
        }

        [FormulaArgument("ProfsOrgFull")]
        public double ProfessorsOrganizationFull()
        {
            return 4;
        }

        [FormulaArgument("ProfsOrgCust")]
        public double ProfessorsOrganizationCustom()
        {
            return 5;
        }

        [FormulaArgument("HistWorkFull")]
        public double HistoricalWorkOrganizationFull()
        {
            return 1;
        }

        [FormulaArgument("HistWorkCust")]
        public double HistoricalWorkOrganizationCustom()
        {
            return 2;
        }

        [FormulaArgument("MssFull")]
        public double MilitaryScientificSocietyOrganizationFull()
        {
            return 3;
        }

        [FormulaArgument("MssCust")]
        public double MilitaryScientificSocietyOrganizationCustom()
        {
            return 4;
        }

        [FormulaArgument("CustSwOrg")]
        public double CustomScientificWorkOrganizationRating()
        {
            return 5;
        }

        [FormulaArgument("SrwProfsCount")]
        public double ScientificResearchWorkProfessorsCount()
        {
            return 1;
        }

        [FormulaArgument("SrwCount")]
        public double ScientificResearchWorksCount()
        {
            return 3;
        }

        [FormulaArgument("MssCount")]
        public double MilitaryScientificSupportsCount()
        {
            return 4;
        }

        [FormulaArgument("InnCount")]
        public double InnovationsCount()
        {
            return 2;
        }

        [FormulaArgument("UsModCount")]
        public double UsefulModelsCount()
        {
            return 3;
        }

        [FormulaArgument("PosInnCount")]
        public double PositiveInnovationsCount()
        {
            return 4;
        }

        [FormulaArgument("PosUsModCount")]
        public double PositiveUsefulModelsCount()
        {
            return 5;
        }

        [FormulaArgument("RationPropCount")]
        public double RationalizationProposalsCount()
        {
            return 1;
        }

        [FormulaArgument("SeProfsCount")]
        public double ScientificExperticeProfessorsCount()
        {
            return 2;
        }

        [FormulaArgument("CustSrOrg")]
        public double CustomScientificResearchOrganizationRating()
        {
            return 3;
        }

        [FormulaArgument("UnConfProfsCount")]
        public double UniversityConferenceProfessorsCount()
        {
            return 4;
        }

        [FormulaArgument("UnConfStudsCount")]
        public double UniversityConferenceStudentsCount()
        {
            return 5;
        }

        [FormulaArgument("ReConfProfsCount")]
        public double RepublicanConferenceProfessorsCount()
        {
            return 1;
        }

        [FormulaArgument("ReConfStudsCount")]
        public double RepublicanConferenceStudentsCount()
        {
            return 2;
        }

        [FormulaArgument("InConfProfsCount")]
        public double InternationalConferenceProfessorsCount()
        {
            return 3;
        }

        [FormulaArgument("InConfStudsCount")]
        public double InternationalConferenceStudentsCount()
        {
            return 4;
        }

        [FormulaArgument("UnFirstDiplCount")]
        public double UniversityFirstDiplomasCount()
        {
            return 5;
        }

        [FormulaArgument("UnSecondDiplCount")]
        public double UniversitySecondDiplomasCount()
        {
            return 1;
        }

        [FormulaArgument("UnThirdDiplCount")]
        public double UniversityThirdDiplomasCount()
        {
            return 2;
        }

        [FormulaArgument("UnLettersCommendationCount")]
        public double UniversityLettersOfCommendationCount()
        {
            return 3;
        }

        [FormulaArgument("ReFirstDiplCount")]
        public double RepublicanFirstDiplomasCount()
        {
            return 5;
        }

        [FormulaArgument("ReSecondDiplCount")]
        public double RepublicanSecondDiplomasCount()
        {
            return 1;
        }

        [FormulaArgument("ReThirdDiplCount")]
        public double RepublicanThirdDiplomasCount()
        {
            return 2;
        }

        [FormulaArgument("ReLettersCommendationCount")]
        public double RepublicanLettersOfCommendationCount()
        {
            return 3;
        }

        [FormulaArgument("InFirstDiplCount")]
        public double InternationalFirstDiplomasCount()
        {
            return 5;
        }

        [FormulaArgument("InSecondDiplCount")]
        public double InternationalSecondDiplomasCount()
        {
            return 1;
        }

        [FormulaArgument("InThirdDiplCount")]
        public double InternationalThirdDiplomasCount()
        {
            return 2;
        }

        [FormulaArgument("InLettersCommendationCount")]
        public double InternationalLettersOfCommendationCount()
        {
            return 3;
        }

        [FormulaArgument("LecturesCount")]
        public double LecturesCount()
        {
            return 2;
        }

        [FormulaArgument("CustArsrOrg")]
        public double CustomAprobationResultsOfScientificWork()
        {
            return 3;
        }

        [FormulaArgument("CustTcSpHq")]
        public double CustomTcSpHq() //training and certification of scientific personnel of higher qualification
        {
            return 1;
        }
        
        #endregion Class Public Argument Methods
    }
}