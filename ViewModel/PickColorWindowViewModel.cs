using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnoGame2.Extensions;
using UnoGame2.Messages;

namespace UnoGame2.ViewModel
{
    class PickColorWindowViewModel : BaseViewModel
    {
        private DialogService dialogService;
        private ICommand pickColorCommand;
        private String pickedColor;

        public PickColorWindowViewModel()
        {
            BindCommands();
            dialogService = new DialogService();

        }

        private void BindCommands()
        {
            PickColorCommand = new RelayCommand<object>(PickColor); ;

        }

        public ICommand PickColorCommand
        {
            get
            {
                return pickColorCommand;
            }
            set
            {
                pickColorCommand = value;
            }
        }

        public String PickedColor
        {
            get
            {
                return pickedColor;
            }
            set
            {
                pickedColor = value;
            }
        }

        public void PickColor(object color)
        {

            PickedColor = color.ToString();
            Messenger.Default.Send<PickedColorMessage>(new PickedColorMessage(PickedColor));

        }


    }
    
}
