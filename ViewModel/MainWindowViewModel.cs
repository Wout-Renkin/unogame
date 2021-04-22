using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnoGame2.Extensions;
using UnoGame2.Messages;
using UnoGame2.Model;

namespace UnoGame2.ViewModel
{
    class MainWindowViewModel:BaseModel
    {
        private Player player;
        private int amountPlayers;
        private ICommand changeNicknameCommand;
        private ICommand playCommand;
        private ICommand gameHistoryCommand;

        public ICommand GameHistoryCommand
        {
            get 
            {
                return gameHistoryCommand;
            }
            set
            {
                gameHistoryCommand = value;
            }
        }
        public ICommand PlayCommand
        {
            get
            {
                return playCommand;
            }
            set
            {
                playCommand = value;
            }
        }
        public ICommand ChangeNicknameCommand
        {
            get
            {
                return changeNicknameCommand;
            }

            set
            {
                changeNicknameCommand = value;
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
                NotifyPropertyChanged();
            }
        }

        public int AmountPlayers
        {
            get
            {
                return amountPlayers;
            }
            set
            {
                amountPlayers = value;
            }
        }

        private DialogService dialogService;


        public MainWindowViewModel()
        {
            BindCommands();
            dialogService = new DialogService();
            Messenger.Default.Register<int>(this, OnPlayerReceived);

        }

        private void BindCommands()
        {
            ChangeNicknameCommand = new BaseCommand(UpdateNickname);
            PlayCommand = new BaseCommand(Play);
            GameHistoryCommand = new BaseCommand(ShowHistory);

        }

        private void UpdateNickname()
        {
            Messenger.Default.Send<Player>(player);
            dialogService.ShowCreateNicknameWindow();

        }


        private void OnPlayerReceived(int playerid)
        {
            dialogService.CloseCreateNicknameWindow();
            PlayerDataService playerDS = new PlayerDataService();
            Player = playerDS.GetPlayer(playerid);
        }

        private void Play()
        {
            if (AmountPlayers != 0)
            {
                Messenger.Default.Unregister(this);
                Messenger.Default.Register<EndGameMessage>(this, EndGame);
                Tuple<int, Player> data = new Tuple<int, Player>(amountPlayers, player);
                DialogHost.CloseDialogCommand.Execute(null, null);

                Messenger.Default.Send<Tuple<int, Player>>(data);
                dialogService.ShowGameWindow();
            }
        }

        private void ShowHistory()
        {
            dialogService.ShowGameHistoryWindow();
            Messenger.Default.Unregister(this);
            Messenger.Default.Register<BackMainMenu>(this, CloseHistory);
            Messenger.Default.Send<GameHistory>(new GameHistory(Player));

        }

        private void CloseHistory(BackMainMenu message)
        {
            dialogService.CloseGameHistoryWindow();
            Messenger.Default.Unregister(this);
            Messenger.Default.Register<int>(this, OnPlayerReceived);

        }

        private void EndGame(EndGameMessage end)
        {
            dialogService.CloseGameWindow();
            Messenger.Default.Register<int>(this, OnPlayerReceived);

        }

    }
}
