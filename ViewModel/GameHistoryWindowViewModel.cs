using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnoGame2.Extensions;
using UnoGame2.Messages;
using UnoGame2.Model;

namespace UnoGame2.ViewModel
{
    class GameHistoryWindowViewModel : BaseViewModel
    {
        private DialogService dialogService;
        private ObservableCollection<Game> games;
        private Player player;
        private ICommand backMainPageCommand;
        private ICommand deleteGameCommand;
        private Game selectedItem;

        public GameHistoryWindowViewModel()
        {
            BindCommands();
            Messenger.Default.Register<GameHistory>(this, PlayerReceived);

        }

        public Game SelectedItem {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
            }
        }


        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }
        public ObservableCollection<Game> Games
        {
            get
            {
                return games;
            }
            set
            {
                games = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand BackMainPageCommand
        {
            get
            {
                return backMainPageCommand;
            }

            set
            {
                backMainPageCommand = value;
            }
        }

        public ICommand DeleteGameCommand
        {
            get
            {
                return deleteGameCommand;
            }
            set
            {
                deleteGameCommand = value;
            }
        }

        private void BindCommands()
        {
            BackMainPageCommand = new BaseCommand(Redirect);
            DeleteGameCommand = new BaseCommand(Delete);

        }

        private void Redirect()
        {

            Messenger.Default.Send<BackMainMenu>(new BackMainMenu());
        }

        private void Delete()
        {
            if(SelectedItem != null)
            {
                GameDataService ds = new GameDataService();
                ds.DeleteGame(SelectedItem);
                LoadGames();
            }
        }

        private void LoadGames()
        {
            GameDataService ds = new GameDataService();
            if (Player != null)
            {
                Games = ds.GetGames(Player.Id);
            }
        }

        private void PlayerReceived(GameHistory player)
        {
            Player = player.Player;
            LoadGames();
        }
    }
}
