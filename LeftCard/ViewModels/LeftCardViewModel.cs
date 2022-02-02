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
        private PowerSupply _items;
        public LeftCardViewModel(PowerSupply items)
        {
            _items = items;
            TemperatureCard = Convert.ToString(items.temperature) + "°C";
                if (items.temperature <= 30)
                    ColorTempCard = "Black";
                else if (items.temperature <= 65)
                    ColorTempCard = "Orange";
                else if (items.temperature <= 90)
                    ColorTempCard = "Red";
                else if (items.temperature > 90)
                    ColorTempCard = "DarkRed";

                KelvincTempCard = Convert.ToString((items.temperature + 273, 15)) + "k";
                VoltazAndPowerCard = Convert.ToString(items.voltage) + "V | " + Convert.ToString(items.current_strength) + "A";
                NameCard = items.name;
                ControllerAndChannelCard = items.controller.productionName + " | Канал" + Convert.ToString(items.id);
                PlacementCard = items.Placement;
        }

        public ICommand TurningOffOnCommand
        {
            get => ReactiveCommand.CreateFromTask(async () =>
            {
                switch (_items.workStatus)
                {
                    case WorkStatus.On:
                        await _items.start();
                        break;
                    case WorkStatus.Off:
                        await _items.stop();
                        break;
                }
            });
        }

        private string _temperatureCard;
        public string TemperatureCard { get => _temperatureCard; set => this.RaiseAndSetIfChanged(ref _temperatureCard, value); }

        private string _colortempcard;
        public string ColorTempCard { get => _colortempcard; set => this.RaiseAndSetIfChanged(ref _colortempcard, value); }

        private string _kelvinctempcard;
        public string KelvincTempCard { get => _kelvinctempcard; set => this.RaiseAndSetIfChanged(ref _kelvinctempcard, value); }

        private string _voltazandpowercard;
        public string VoltazAndPowerCard { get => _voltazandpowercard; set => this.RaiseAndSetIfChanged(ref _voltazandpowercard, value); }

        private string _namecard;
        public string NameCard { get => _namecard; set => this.RaiseAndSetIfChanged(ref _namecard, value); }

        private string _controllerandchannelcard;
        public string ControllerAndChannelCard { get => _controllerandchannelcard; set => this.RaiseAndSetIfChanged(ref _controllerandchannelcard, value); }

        private string _placementcard;
        public string PlacementCard { get => _placementcard; set => this.RaiseAndSetIfChanged(ref _placementcard, value); }

        
    }
}
