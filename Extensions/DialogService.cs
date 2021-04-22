using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnoGame2.View;

namespace UnoGame2.Extensions
{
    public class DialogService
    {

        Window MainWindow = null;
        Window CreateNicknameWindow = null;
        Window GameWindow = null;
        Window GameHistoryWindow = null;
        Window PickColorWindow = null;
        Window ResultWindow = null;

        public DialogService() { }

        public void ShowMainWindow()
        {
            MainWindow = new MainWindow();
            MainWindow.ShowDialog();
        }

        public void CloseMainWindow()
        {
            if (MainWindow != null)
            {
                MainWindow.Close();
            }
        }

        public void ShowCreateNicknameWindow()
        {
            CreateNicknameWindow = new CreateNicknameWindow();
            CreateNicknameWindow.ShowDialog();
        }

        public void CloseCreateNicknameWindow()
        {

            if (CreateNicknameWindow != null)
            {
                CreateNicknameWindow.Close();

            }
        }
        public void ShowGameWindow()
        {
            GameWindow = new GameWindow();
            GameWindow.Show();

        }
        public void CloseGameWindow()
        {
            if (GameWindow != null)
            {
                GameWindow.Close();
            }

        }

        public void ShowGameHistoryWindow()
        {
            
                GameHistoryWindow = new GameHistoryWindow();
                GameHistoryWindow.Show();
            
        }

        public void CloseGameHistoryWindow()
        {

            if (GameHistoryWindow != null)
            {
                GameHistoryWindow.Close();
            }

        }

        public void ShowPickColorWindow()
        {
            
                PickColorWindow = new PickColorWindow();
                PickColorWindow.Show();
            
        }

        public void ClosePickColorWindow()
        {
            if (PickColorWindow != null)
            {
                PickColorWindow.Close();
            }
        }

        public void ShowResultWindow()
        {
            ResultWindow = new ResultWindow();
            ResultWindow.Show();
        }
        public void CloseResultWindow()
        {
            if (ResultWindow != null)
            {
                ResultWindow.Close();
            }
        }
    }
}
