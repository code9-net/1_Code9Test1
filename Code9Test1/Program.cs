using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9Test1
{
  class Program
  {
    static void Main(string[] args)
    {
      List<IVehicle> allVehicles = new List<IVehicle>();

      //allVehicles.Add(new Car());
      //allVehicles.Add(new Motor());

      Car c1 = allVehicles.AddCar();
      Motor m1 = allVehicles.AddMotor();
      Motor m2 = allVehicles.AddMotor();

      foreach (var one in allVehicles)
      {
        one.Drive("Work");
        one.Drive("Home");
        one.Stop();
      }


      var foundVehicle = allVehicles.First(v => v is Car) as Car;
      Console.WriteLine(String.Format("We found: {0}", foundVehicle.Name));

      var countMotors = allVehicles.Count(v => v is Motor);
      Console.WriteLine(String.Format("We found {0} motors", countMotors));

      Console.WriteLine();
      Console.WriteLine(c1.SerializeToXmlString());
      Console.WriteLine();
      Console.WriteLine(m1.SerializeToXmlString());

      c1.Name = "Toyota";
      string c1Str = c1.SerializeToXmlString();

      Car c2 = c1Str.Deserialize<Car>();
      Console.WriteLine(c2.Name);

      string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      string fullFilePath = Path.Combine(desktopFolder, "mycar.xml");
      System.IO.File.WriteAllText(fullFilePath, c1Str );
      Console.WriteLine(String.Format("File written to: '{0}'", fullFilePath));


      string fileContent = System.IO.File.ReadAllText(fullFilePath);
      Car c3 = fileContent.Deserialize<Car>();
      Console.WriteLine(String.Format("Read Car '{0}' from file '{1}'", c3.Name, fullFilePath));

      Console.ReadKey();
    }
  }
}
