using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sample;
using Newtonsoft.Json;

namespace Samples
{
    class PhoneService
    {
        public string filePath = "PhoneData.json";

        public List<PhoneInfo> phoneInfo { get; set; }

        public PhoneService()
        {
            File.Exists(filePath);
            if (File.Exists(filePath) == false)
            {
                File.Create(filePath).Close();
            }


            try
            {
                string jsonContent = File.ReadAllText(filePath);

                phoneInfo = JsonConvert.DeserializeObject<List<PhoneInfo>>(jsonContent);

                if (phoneInfo == null)
                {
                    phoneInfo = new List<PhoneInfo>();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error reading file");
            }
        }


        public List<PhoneInfo> GetListSortedByPrice()
        {

            List<PhoneInfo> list = phoneInfo.ToList().OrderBy(x => x.price).ToList();
            return list;
        }


        public void PrintPhoneModelDetails()
        {
            int id = 0;
            foreach (PhoneInfo info in phoneInfo)
            {
                while (id == info.id)
                {
                    id++;
                }
            }

            Console.WriteLine("Модель Телефона");
            foreach (PhoneInfo model in phoneInfo)
            {
                for (int size = 0; size <= id; size++)
                {
                    Console.WriteLine(model.model);
                }

            }

            Console.WriteLine("Цена");
            foreach (PhoneInfo price in phoneInfo)
            {
                for (int size = 0; size <= id; size++)
                {
                    Console.WriteLine(price.price);
                }

            }

            Console.WriteLine("Хранилище");
            foreach (PhoneInfo storage in phoneInfo)
            {
                for (int size = 0; size <= id; size++)
                {
                    Console.WriteLine(storage.storage);
                }
            }

            Console.WriteLine("RAM");
            foreach (PhoneInfo ram in phoneInfo)
            {
                for (int size = 0; size <= id; size++)
                {
                    Console.WriteLine(ram.ram);
                }

            }

        }



        public void Add(PhoneInfo phoneInfo)
        {
            try
            {
                phoneInfo.id = GetNewId();
                this.phoneInfo.Add(phoneInfo); // add to the list
                Save(); // save to the file
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete(int id)
        {
            foreach (PhoneInfo info in this.phoneInfo)     // iterate
            {
                if (info.id == id)        // check
                {
                    this.phoneInfo.Remove(info);     // delete
                    Save();                 // save
                    return true;               // exit
                }
            }
            return false;                    // if not found
        }

        private int GetNewId()
        {
            if (phoneInfo.Count == 0)            // if the list is empty
                return 1;                  // start from 1
            else
                return phoneInfo.Last().id + 1;  // else - last element of the list + 1
        }


        public void Save()
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(phoneInfo); // serialize
                File.WriteAllText(filePath, jsonContent); // completely rewrite
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing");
            }

        }
    }
}

