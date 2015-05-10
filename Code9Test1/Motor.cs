using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9Test1
{
  //5 - class Motor
  public class Motor:DrivableVehicle
  {
    private string _name = "Motor";
    
    public override string Name
    {
      get { return _name; }
      set { _name = value; }
    }
    
  }
}
