using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WPF.State.Navigators;

namespace ToDo.WPF.ViewModels.Factories
{
    public class ToDoViewModelFactory : IToDoViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<TodayViewModel> _createTodayViewModel;
        private readonly CreateViewModel<WeekViewModel> _createWeekViewModel;
        private readonly CreateViewModel<MonthViewModel> _createMonthViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;
        private readonly CreateViewModel<AccountViewModel> _createAccountViewModel;
        private readonly CreateViewModel<TaskSummaryViewModel> _createTaskDescriptionViewModel;

        public ToDoViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
                                    CreateViewModel<LoginViewModel> createLoginViewModel,
                                    CreateViewModel<SettingsViewModel> createSettingsViewModel,
                                    CreateViewModel<TodayViewModel> createTodayViewModel,
                                    CreateViewModel<AccountViewModel> createAccountViewModel,
                                    CreateViewModel<TaskSummaryViewModel> createTaskDescriptionViewModel, 
                                    CreateViewModel<WeekViewModel> createWeekViewModel, 
                                    CreateViewModel<MonthViewModel> createMonthViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createSettingsViewModel = createSettingsViewModel;
            _createTodayViewModel = createTodayViewModel;
            _createAccountViewModel = createAccountViewModel;
            _createTaskDescriptionViewModel = createTaskDescriptionViewModel;
            _createWeekViewModel = createWeekViewModel;
            _createMonthViewModel = createMonthViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Account:
                    return _createAccountViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Settings:
                    return _createSettingsViewModel();
                case ViewType.Task:
                    return _createTaskDescriptionViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Today:
                    return _createTodayViewModel();
                case ViewType.Week:
                    return _createWeekViewModel();
                case ViewType.Month:
                    return _createMonthViewModel();
                default: throw new ArgumentException("The ViewType does not have a ViewModel", "viewType");
            }
        }
    }
}
