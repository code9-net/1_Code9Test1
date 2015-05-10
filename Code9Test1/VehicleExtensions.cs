using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Code9Test1
{
  public static class VehicleExtensions
  {
    public static Car AddCar(this List<IVehicle> vehicles)
    {
      Car c= new Car();

      vehicles.Add(c);

      return c;
    }

    public static Motor AddMotor(this List<IVehicle> vehicles)
    {
      Motor m = new Motor();
      vehicles.Add(m);
      return m;
    }

    public static string SerializeToXmlString(this object obj)
    {
      XmlSerializer xSerializer = new XmlSerializer(obj.GetType());
      MemoryStream objMemoryStream = new MemoryStream();
      try
      {
        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(objMemoryStream, UTF8Encoding.UTF8))
        {
          xSerializer.Serialize(xmlTextWriter, obj);

          objMemoryStream = (MemoryStream)xmlTextWriter.BaseStream;
          UTF8Encoding encoding = new UTF8Encoding();
          return encoding.GetString(objMemoryStream.ToArray());          
        }
      }
      finally
      {
        objMemoryStream.Dispose();
      }
    }


    public static T Deserialize<T>(this string strXML)
    {
      XmlSerializer xSerializer = new XmlSerializer(typeof(T));
      UTF8Encoding encoding = new UTF8Encoding();
      byte[] buffer = encoding.GetBytes(strXML);

      using (MemoryStream objMemoryStream = new MemoryStream(buffer.Length))
      {
        objMemoryStream.Write(buffer, 0, buffer.Length);
        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(objMemoryStream, UTF8Encoding.UTF8))
        {
          objMemoryStream.Position = 0;
          return (T)xSerializer.Deserialize(objMemoryStream);
        }
      }
    }

  }
}
