
using DALI.Enum;
using ReactiveUI;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DALI.Models
{
    public class PowerSupply
    {
        
        public PowerSupply(string idi, int temp, int vol, int cur_str, string na, Channel channel, Controller cont, WorkStatus work, string _placement)
        {
            id = idi;
            temperature = temp;
            voltage = vol;
            current_strength = cur_str;
            name = na;
            _channel = channel;
            controller = cont;
            workStatus = work;
            Placement = _placement;
        }
        //второй конструктор нужен для viewmodel т.к чтобы быстро и просто принимать данные

        public PowerSupply(PowerSupply items)
        {
            Items = items;
        }

        public ICommand TurningOffOnCommand
        {
            get => ReactiveCommand.CreateFromTask(async () =>
            {
                switch (this.workStatus)
                {
                    case WorkStatus.On:
                        await this.start();
                        break;
                    case WorkStatus.Off:
                        await this.stop();
                        break;
                }
            });
        }

        public string Color {
            get
            {
                string color = "";
                if (this.temperature <= 30)
                    color = "Black";
                else if (this.temperature <= 65)
                    color = "Orange";
                else if (this.temperature <= 90)
                    color = "Red";
                else if (this.temperature > 90)
                    color = "DarkRed";
                return color;
            }
        }

        public string id { get; set; }

        private int temperature { get; set; }
        public string TemperatureCard
        {
            get => Convert.ToString(this.temperature) + "°C";
        }
        public string KelvincTempCard
        {
            get => Convert.ToString((this.temperature + 273, 15)) + "k";
        }

        private int voltage { get; set; }

        private int current_strength { get; set; }
        public string VoltazAndPowerCard
        {
            get => Convert.ToString(this.voltage) + "V | " + Convert.ToString(this.current_strength) + "A";
        }

        public string name { get; set; }

        public Channel _channel { get; set; }

        private Controller controller { get; set; }
        public string ControllerAndChannelCard
        {
            get => this.controller.productionName + " | Канал" + Convert.ToString(this.id);
        }
        public string Placement { get; set; }

        public WorkStatus workStatus { get; set; }
        public PowerSupply Items { get; }

        public async Task stop()
        {
            // Deleted
            this.workStatus = WorkStatus.Off;
        }

        public async Task start()
        {
            // Deleted
            this.workStatus = WorkStatus.On;
        }

    }
}