using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models.Enums;

namespace TimeTracking.Models
{
    public class Exercising: Activity
    {
        public ExercisingTypeEnum ExercisingType { get; set; }

    }
}
