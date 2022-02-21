using DALI.Enum;
using DALI.Models;
using LeftCard.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeftCard.ViewModels
{
    public class LeftCardViewModel : ViewModelBase
    {
        private PowerSupply _powerSupply;

        public PowerSupply PowerSupply
        {
            get => _powerSupply;
            set
            {
                this.RaiseAndSetIfChanged(ref _powerSupply, value);
                this.RaisePropertyChanged(nameof(TurningOffOnCommand));
                this.RaisePropertyChanged(nameof(TemperatureCard));
                this.RaisePropertyChanged(nameof(ColorTempCard));
                this.RaisePropertyChanged(nameof(KelvincTempCard));
                this.RaisePropertyChanged(nameof(VoltazAndPowerCard));
                this.RaisePropertyChanged(nameof(ControllerAndChannelCard));
            }
        }
        public LeftCardViewModel(PowerSupply items)
        {
            PowerSupply = items;
            TemperatureCard = items.TemperatureCard;
            ColorTempCard = items.Color;
            KelvincTempCard = items.KelvincTempCard;
            VoltazAndPowerCard = items.VoltazAndPowerCard;
            NameCard = items.name;
            ControllerAndChannelCard = items.ControllerAndChannelCard;
            PlacementCard = items.Placement;
            TurningOffOnCommand = items.TurningOffOnCommand;
        }
        public ICommand TurningOffOnCommand{ get;set;}
        public string TemperatureCard { get; set; }
        public string ColorTempCard { get; set; }
        public string KelvincTempCard { get; set; }
        public string VoltazAndPowerCard { get; set; }
        public string NameCard { get; set; }
        public string ControllerAndChannelCard { get; set; }
        public string PlacementCard { get; set; }
    }
}
