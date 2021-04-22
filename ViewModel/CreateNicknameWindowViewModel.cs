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
    class CreateNicknameWindowViewModel:BaseViewModel
    {
        private DialogService dialogService;

        private ICommand saveNicknameCommand;
        private Player player;

        public CreateNicknameWindowViewModel()
        {
            dialogService = new DialogService();
            BindCommands();
            Messenger.Default.Register<Player>(this, OnPlayerReceived);


        }
        public Player Player
        {
            get {
                if(player == null)
                {
                    player = new Player();
                }
                return player;
            
            }
            set
            {
                player = value;
            }
        }

        public ICommand SaveNicknameCommand
        {
            get
            {
                return saveNicknameCommand;
            }

            set
            {
                saveNicknameCommand = value;
            }
        }

        private void Create()
        {
            PlayerDataService playerDS = new PlayerDataService();

            //We dont want the player taking bot 1, bot 2 or bot 3
            if (Player.Nickname != null && Player.Nickname != "bot 1" && Player.Nickname != "bot 2" && Player.Nickname != "bot 3")
            {
                if (Player.Id == 0)
                {
                    var playerid = playerDS.InsertPlayer(Player);
                    Messenger.Default.Send<int>(playerid);
                    dialogService.ShowMainWindow();

                }
                else
                {
                    playerDS.UpdatePlayer(Player);
                    Messenger.Default.Send<int>(Player.Id);
                }

            }
        }

        private void BindCommands()
        {
            SaveNicknameCommand = new BaseCommand(Create);

        }

        private void OnPlayerReceived(Player player)
        {
            Player = player;
        }


    }
}
