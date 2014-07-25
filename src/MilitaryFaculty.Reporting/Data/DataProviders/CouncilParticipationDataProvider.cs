﻿using MilitaryFaculty.Data;
using MilitaryFaculty.Domain;

namespace MilitaryFaculty.Reporting.Data.DataProviders
{
    public class CouncilParticipationDataProvider : DataProvider<CouncilParticipation>
    {
        public CouncilParticipationDataProvider(IRepository<CouncilParticipation> repository) : base(repository)
        {
        }

        public override void SetFacultyModificator(TimeInterval interval)
        {
            QueryModificator = cp =>
                (cp.Start >= interval.From && cp.Start <= interval.To)
                || (cp.End >= interval.From && cp.End <= interval.To)
                || (cp.Start <= interval.From && cp.End >= interval.To);
        }

        public override void SetCathedraModificator(Cathedra cathedra, TimeInterval interval)
        {
            QueryModificator = cp =>
                cp.Participant.Cathedra.Id == cathedra.Id
                && (cp.Start >= interval.From && cp.Start <= interval.To)
                || (cp.End >= interval.From && cp.End <= interval.To)
                || (cp.Start <= interval.From && cp.End >= interval.To);
        }

        public override void SetProfessorModificator(Professor professor, TimeInterval interval)
        {
            QueryModificator = cp =>
                cp.Participant.Id == professor.Id
                && (cp.Start >= interval.From && cp.Start <= interval.To)
                || (cp.End >= interval.From && cp.End <= interval.To)
                || (cp.Start <= interval.From && cp.End >= interval.To);
        }

        /// <summary>
        ///     Количество научных работников высшей квалификации из числа ППС,
        ///     участвующих в работе экспертных советов ВАК Беларуси
        /// </summary>
        /// <returns></returns>
        [FormulaArgument("HacHqProfsCount")]
        public double HacHqProfsCount()
        {
            return CountOf(c => c.Type == CouncilType.SupremeCertificationCommissionCouncil);
        }

        /// <summary>
        ///     Количество научных работников высшей квалификации из числа ППС,
        ///     участвующих в работе специализированных советов по защите диссертаций
        /// </summary>
        /// <returns></returns>
        [FormulaArgument("DodHqProfsCount")]
        public double DodHqProfsCount()
        {
            return CountOf(c => c.Type == CouncilType.DefenceOfDissertationsCouncil);
        }

        /// <summary>
        ///     Количество научных работников высшей квалификации из числа ППС,
        ///     участвующих в работе научных советов вуза
        /// </summary>
        /// <returns></returns>
        [FormulaArgument("RcHqProfsCount")]
        public double RcHqProfsCount()
        {
            return CountOf(c => c.Type == CouncilType.ResearchCounsil);
        }

        /// <summary>
        ///     Количество научных работников высшей квалификации из числа ППС,
        ///     участвующих в работе редакционных коллегий научных изданий
        /// </summary>
        /// <returns></returns>
        [FormulaArgument("EbspHqProfsCount")]
        public double EbspHqProfsCount()
        {
            return CountOf(c => c.Type == CouncilType.EditorialBoardCouncil);
        }
    }
}