
using DALI.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DALI.Models
{
    public class Controller
    {

        public Controller(Channel id, WorkStatus work, string prodname, string useName)
        {
            channels = id;
            workStatus = work;
            productionName = prodname;
            userName = useName;
        }

        public Channel channels { get; set; }

        public WorkStatus workStatus { get; set; }

        public string productionName { get; set; }

        public string userName { get; set; }

        

        public int countPowerSupply()
        {
            // Deleted
            return 65;
        }

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