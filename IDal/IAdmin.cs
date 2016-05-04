using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IAdmin
    {
        int register(Model.BBSUsers model);

        int login(Model.BBSUsers model);

        int add_section(Model.BBSSection model);
    }
}
