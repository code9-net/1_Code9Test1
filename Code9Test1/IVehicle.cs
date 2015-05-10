using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Code9Test1
{
  //1 - interface IVehicle
  public interface IVehicle
  {
    string Name { get; set; }
    void Drive(string where);
    void Stop();
  }
}
