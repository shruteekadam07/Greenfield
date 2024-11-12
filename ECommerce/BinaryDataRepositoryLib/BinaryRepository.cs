using Specification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDataRepositoryLib
{
    public class BinaryRepository<T>:IDataRepository<T>
    {
         public bool Serialize(string filename, List<T> items)
        {
            bool status = false;
            //code for saving
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            formatter.Serialize(stream, items);
            stream.Close();
            return status;
        }
        public List<T> Deserialize(string filename)
        {
            List<T> items = new List<T>();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null)
            {
                items = (List<T>)formatter.Deserialize(stream);
            }
            stream.Close();

            //retrieve all products from file
            return items;
        }
    

}
}
