
using DALI.Enum;
using System.Threading.Tasks;

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

        public string id { get; set; }

        public int temperature { get; set; }

        public int voltage { get; set; }

        public int current_strength { get; set; }

        public string name { get; set; }

        public Channel _channel { get; set; }

        public Controller controller { get; set; }
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