using DALI.Enum;
using DALI.Models;
using LeftCard.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LeftCard.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private LeftCardViewModel _item;
        public LeftCardViewModel Item { get => _item; set => this.RaiseAndSetIfChanged(ref _item, value); }
        public MainWindowViewModel()
        {
            Item = new LeftCardViewModel(GetDate());
    
        }
        //просто метод для заполнения данными
        private PowerSupply GetDate()
        {         
            return new PowerSupply("Some id", 45, 10, 5, "ИП FnGSGgsd (4)", new Channel(1), new Controller(new Channel(1), WorkStatus.On, "Some production", "Some user"), DALI.Enum.WorkStatus.On, "Серверная");
        }
       

        
    }
}
