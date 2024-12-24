using REAL_Estate.Data;
using REAL_Estate.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static REAL_Estate.Services.PropertyService;

namespace REAL_Estate.Services
{
    public class PropertyService : AService
    {

        public PropertyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

            public IEnumerable<Property> GetAllProperties()
            {
                return UnitOfWork.Select<Property>().ToList();
            }

            public Property? GetPropertyById(long id)
            {
                return UnitOfWork.Get<Property>(id);
            }

            public void AddProperty(Property property)
            {
                UnitOfWork.Insert(property);
                UnitOfWork.Commit();

            }

            
        public Filee? GetFileById(long id)
        {
            return UnitOfWork.Get<Filee>(id);
        }

        public void AddFilesToProperty(long propertyId, List<Filee> files)
        {
            Property? property = UnitOfWork.Get<Property>(propertyId);

            if (property != null)
            {
                foreach (Filee file in files)
                {
                    file.PropertyId = propertyId;
                }

                UnitOfWork.InsertRange(files);
                UnitOfWork.Commit();
            }
        }

        public void DeleteFile(long id)
        {
            Filee? file = UnitOfWork.Get<Filee>(id);

            if (file != null)
            {
                if (File.Exists(file.FilePath))
                {
                    File.Delete(file.FilePath);
                }

                UnitOfWork.Delete(file);
                UnitOfWork.Commit();
            }
        }

        public void UpdateProperty(Property property)
        {
            UnitOfWork.Update(property);
            UnitOfWork.Commit();
        }

        public void DeleteProperty(long id)
        {
            Property? property = UnitOfWork.Get<Property>(id);

            if (property != null)
            {
                List<Filee> files = UnitOfWork.Select<Filee>().Where(f => f.PropertyId == id).ToList();

                foreach (Filee file in files)
                {
                    if (File.Exists(file.FilePath))
                    {
                        File.Delete(file.FilePath);
                    }
                }

                UnitOfWork.DeleteRange(files);
                UnitOfWork.Delete(property);
                UnitOfWork.Commit();
            }
        }

    }
}

