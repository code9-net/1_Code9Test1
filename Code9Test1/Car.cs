using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Code9Test1
{
  //3 - class Car
  public class Car : DrivableVehicle
  {
    private string _name = "Car";
    
    public override string Name
    {
      get { return _name;  }
      set { _name = value; }
    }

  }
}
