using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.EncapsulateWhatChanges
{
    public class BusinessLogic
    {
        private IDataService _dataService;
        public BusinessLogic(IDataService dataservice)
        {
            _dataService = dataservice;
        }

        public void ProcessData() => _dataService.Getdata().ToUpper();
    }
}
