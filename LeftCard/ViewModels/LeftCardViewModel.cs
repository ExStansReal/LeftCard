using DALI.Enum;
using DALI.Models;
using LeftCard.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                this.RaisePropertyChanged(nameof(KelvincTempCard));
                this.RaisePropertyChanged(nameof(VoltazAndPowerCard));
                this.RaisePropertyChanged(nameof(ControllerAndChannelCard));
            }
        }

        public LeftCardViewModel(PowerSupply powerSupply)
        {
            this.PowerSupply = powerSupply;
        }

        public ICommand TurningOffOnCommand
        {
            get => ReactiveCommand.CreateFromTask(async () =>
            {
                switch (PowerSupply.workStatus)
                {
                    case WorkStatus.On:
                        await PowerSupply.start();
                        break;
                    case WorkStatus.Off:
                        await PowerSupply.stop();
                        break;
                }
            });
        }

        public string TemperatureCard
        {
            get => Convert.ToString(PowerSupply.temperature) + "°C";
        }
        public string KelvincTempCard
        {
            get => Convert.ToString((PowerSupply.temperature + 273, 15)) + "k";
        }

        public string VoltazAndPowerCard
        {
            get => Convert.ToString(PowerSupply.voltage) + "V | " + Convert.ToString(PowerSupply.current_strength) + "A";
        }
        public string NameCard { get => "Name"; }
        public string PlacementCard { get => "Name"; }

        public string ControllerAndChannelCard
        {
            get => " | Канал" + Convert.ToString(PowerSupply.id);
        }
    }
}
