using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.Models
{
    class DemoService
    {
        private static List<DemoModel> ObjList;

        public DemoService()
        {
            ObjList = new List<DemoModel>()
            {
            };
        }

        public List<DemoModel> GetAll()
        {
            return ObjList;
        }

        private int getObjIndex(int id)
        {
            for (int index = 0; index < ObjList.Count; index++)
            {
                if (ObjList[index].Id == id)
                    return index;
            }
            return -1;
        }

        void varifyObjAge(int newObjAge)
        {
            const int ageThreshold = 18;
            if (newObjAge < ageThreshold)
                throw new Exception("Age " + newObjAge + " is below " + ageThreshold);
        }

        void varifyObj(DemoModel newObj)
        {
            varifyObjAge(newObj.Age);
        }

        public bool AddObj(DemoModel newObj)
        {
            if(newObj == null)
                throw new Exception("Please enter the correct value");

            varifyObj(newObj);

            int objIndex = getObjIndex(newObj.Id);

            if (objIndex == -1)
                ObjList.Add(new DemoModel { Age = newObj.Age, Id = newObj.Id, Name = newObj.Name });
            else
                Update(newObj);
            return true;
        }

        public bool Update(DemoModel newObj)
        {
            bool isUpdated = false;

            varifyObj(newObj);

            for (int index = 0; index < ObjList.Count; index++)
            {
                if(ObjList[index].Id == newObj.Id)
                {
                    ObjList[index].Name = newObj.Name;
                    ObjList[index].Age = newObj.Age;
                    isUpdated = true;
                    break;
                }
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            for (int index = 0; index < ObjList.Count; index++)
            {
                if (ObjList[index].Id == id)
                {
                    ObjList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }

        public DemoModel Search(int id)
        {
            return ObjList.FirstOrDefault(e => e.Id == id);
        }
    }
}
