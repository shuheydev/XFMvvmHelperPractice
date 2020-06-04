using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XFMvvmHelperPractice.Models;

namespace XFMvvmHelperPractice.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Person> _people;
        public ObservableRangeCollection<Person> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        public MainPageViewModel()
        {
            //テスト
            this.Title = "Hello MvvmHelper";
            this.SubTitle = "How to use MvvmHelper";

            People = new ObservableRangeCollection<Person>();
            People.CollectionChanged += (s, e) =>
            {
                //Peopleに変更(追加や削除. 各アイテムのデータの変更ではない)があった場合に出力
                //確認用
                Debug.WriteLine("People collection changed");
            };

            GetPeopleCommand = new Command(async () =>
            {
                this.IsBusy = true;//忙しさアピール
                await GetPeople();
                this.IsBusy = false;//忙しさアピール解除
            });
        }

        public Command GetPeopleCommand { get; }
        private async Task GetPeople()
        {
            //データ生成
            var people = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                people.Add(new Person { Name = $"Person{i}", Age = i });
            }

            await Task.Delay(2000);//処理に時間がかかる演出

            //Peopleに一括で追加する
            this.People.AddRange(people);
        }
    }
}
