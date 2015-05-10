using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9Test1
{
  //2 - abstract class DrivableVehicle
  public abstract class DrivableVehicle: IVehicle
  {

    public void Drive(string where)
    {
      Console.WriteLine(String.Format("Driving {0} to {1}", Name, where));
    }

    public void Stop()
    {
      Console.WriteLine(String.Format("Stopped {0}", Name));
    }

    public abstract string Name { get; set; }
  }
}
