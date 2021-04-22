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
    class ResultWindowViewModel: BaseViewModel
    {
        private Player winner;
        private ICommand backMainMenu;

       

        public Player Winner { 
            get 
            {
                return winner;
            } 
            set 
            {
                winner = value;
            } 
        }

        public ResultWindowViewModel()
        {
            Messenger.Default.Register<WinnerMessage>(this, OnWinnerReceived);
            BindCommands();
        }

        public void OnWinnerReceived(WinnerMessage winner)
        {
            Winner = winner.Winner;

        }

        private void BindCommands()
        {
            BackMainMenu = new BaseCommand(Back);
 

        }

        public ICommand BackMainMenu
        {
            get
            {
                return backMainMenu;
            }
            set
            {
                backMainMenu = value;
            }
        }

        public void Back()
        {
            Messenger.Default.Send<EndGameMessage>(new EndGameMessage());

        }

    }
}
