using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using XFMvvmHelperPractice.Models;

namespace XFMvvmHelperPractice.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Person> _people;
        public ObservableRangeCollection<Person> Person
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        public MainPageViewModel()
        {
            //テスト
            this.Title = "Hello MvvmHelper";
            this.SubTitle = "How to use MvvmHelper";
            this.IsBusy = true;
        }
    }
}
