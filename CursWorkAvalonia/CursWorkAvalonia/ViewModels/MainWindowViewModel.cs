using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
using System.Collections.Specialized;
using CursWorkAvalonia;

/* namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
    }
} */

namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request, value);
        }


        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }

        public ObservableCollection<Bookmaker> Bookmaker { get; set; }
        public ObservableCollection<Horse> Horse { get; set; }
        public ObservableCollection<Jockey> Jockey { get; set; }
        public ObservableCollection<Location> Location { get; set; }
        public ObservableCollection<Owner> Owner { get; set; }
        public ObservableCollection<Run> Run { get; set; }
        public ObservableCollection<Trainer> Trainer { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
            //tableNames = new ObservableCollection<TableName>() {
            //  new TableName("Nhlscore"){Fields = new List<string> {"NhlscoresId","Points","GoalFor","GoalAg","TeamId"}},
            //    new TableName("Player"){Fields = new List<string>{"PlayerId","Name","Age","TeamId"} },
            //new TableName("PlayerStatistic"){Fields = new List<string>{ "StaticticId","PlayerId","GamePlayed","Pos" ,"Satt","TimeOnIce"} },
            //new TableName("Team"){Fields = new List<string>{ "TeamId","Name"} },
            //new TableName("TeamStatistic"){ Fields = new List<string>{ "TeamStatisticId","GamePlayed", "Win", "Lose" ,"TeamId"} }
            //};

            using (var db = new HorseRasingContext())
            {

                this.Bookmaker = new ObservableCollection<Bookmaker>(db.Bookmakers);
                this.Horse = new ObservableCollection<Horse>(db.Horses);
                this.Jockey = new ObservableCollection<Jockey>(db.Jockeys);
                this.Location = new ObservableCollection<Location>(db.Locations);
                this.Owner = new ObservableCollection<Owner>(db.Owners);
                this.Run = new ObservableCollection<Run>(db.Runs);
                this.Trainer = new ObservableCollection<Trainer>(db.Trainers);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };


        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }
        public void SQLRequestOpen()
        {
            Content = new SQLRequestViewModel();
        }

        public void DeleteBookmaker(Bookmaker entity) => Bookmaker.Remove(entity);
        public void DeleteHorse(Horse entity) => Horse.Remove(entity);
        public void DeleteJockey(Jockey entity) => Jockey.Remove(entity);
        public void DeleteLocation(Location entity) => Location.Remove(entity);
        public void DeleteOwner(Owner entity) => Owner.Remove(entity);
        public void DeleteRun(Run entity) => Run.Remove(entity);
        public void DeleteTrainer(Trainer entity) => Trainer.Remove(entity);


        public void CreateBookmaker() => Bookmaker.Add(new Bookmaker() { OrganizationSName = "new", LeadTheRase = 0, RunId = 0 });
        public void CreateHorse() => Horse.Add(new Horse()
        {
            HorseId = 0,
            Name = "new",
            Rating = 0,
            Breed = "new",
            Weight = 0,
            Age = 0,
            TrainerId = 0,
            JockeyId = 0,
            OwnerId = 0,
        });

        public void CreateJockey() => Jockey.Add(new Jockey()
        {
            JockeyId = 0,
            FullName = "new",
            Weight = 0,
            Growth = 0,
        });
        public void CreateLocation() => Location.Add(new Location() { LocationId = 0, City = "new", Stadium = "new", Date = "00.00.00" });
        public void CreateOwner() => Owner.Add(new Owner(){ OwnerId = 0, FullName = "new" });
        public void CreateRun() => Run.Add(new Run { RunId = 0, TypeOfRace = "new", DistanceFur = 0, ListOfHorseId = 0, LocationId = 0 });
        public void CreateTrainer() => Trainer.Add(new Trainer { TrainerId = 0, FullName = "new", Age = 0, Rating = 0 });
        public void SQLRequestRun()
        {

            using (var db = new HorseRasingContext())
            {
                //Ñäåëàòü ðåàëèçàöèþ çàïðîñîâ, ÷åðåç ñâèò÷ êîìàíäû(SELECT JOIN è ò.ä.), â êåéñàõ ñàì çàïðîñ, ðåçóëüòàò çàïèñûâàòü â ñïèñîê çàïðîñîâ
                // Òèï ñïèñêà çàïðîñîâ? Îòäåëüíûé êëàññ?
            }
            Content = new DataBaseViewModel();
        }
    }
}
