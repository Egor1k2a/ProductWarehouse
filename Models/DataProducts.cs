using System.Text;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using ProductWarehouse.ViewModels;

namespace ProductWarehouse.Models
{
    public class DataProducts
    {
        //Сохранить первый продукт или первого клиента
        public void SaveFirstData<T>(ObservableCollection<T> collection, string FileName)
        {
            string FileNewName = FileName + ".xml";
            File.Create(FileNewName).Close();
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using (Stream fs = new FileStream(FileNewName, FileMode.Create))
            {
                XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
                serializer.Serialize(writer, collection);
                writer.Close();
            }
        }
    }
}
