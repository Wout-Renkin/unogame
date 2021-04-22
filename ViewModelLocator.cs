using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame2.ViewModel;

namespace UnoGame2
{
    class ViewModelLocator
    {
        private static CreateNicknameWindowViewModel createNicknameWindowViewModel = new CreateNicknameWindowViewModel();
        private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private static GameWindowViewModel gameWindowViewModel = new GameWindowViewModel();
        private static GameHistoryWindowViewModel gameHistoryWindowViewModel = new GameHistoryWindowViewModel();
        private static PickColorWindowViewModel pickColorWindowViewModel = new PickColorWindowViewModel();
        private static ResultWindowViewModel resultWindowViewModel = new ResultWindowViewModel();

        public static CreateNicknameWindowViewModel CreateNicknameWindowViewModel
        {
            get
            {
                return createNicknameWindowViewModel;
            }
        }

        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return mainWindowViewModel;
            }
        }

        public static GameWindowViewModel GameWindowViewModel
        {
            get
            {
                return gameWindowViewModel;
            }
        }

        public static GameHistoryWindowViewModel GameHistoryWindowViewModel
        {
            get
            {
                return gameHistoryWindowViewModel;
            }
        }

        public static PickColorWindowViewModel PickColorWindowViewModel
        {
            get
            {
                return pickColorWindowViewModel;
            }
        }

        public static ResultWindowViewModel ResultWindowViewModel
        {
            get
            {
                return resultWindowViewModel;
            }
        }
    }
}
