using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using REAL_Estate.Components.Security;
using REAL_Estate.Objects.Models;
using REAL_Estate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAL_Estate.Controllers
{
    [AllowUnauthorized]
    public class RealEstate : ServicedController<PropertyService>
    {
        public RealEstate(PropertyService service) : base(service)
        {
        }

        public IActionResult Index()
        {
            IEnumerable<Property> properties = Service.GetAllProperties();
            return View(properties);
        }

        public IActionResult Show(string? searchQuery, decimal? minPrice, decimal? maxPrice, string? country, string? city, string? region)
        {
            IEnumerable<Property> properties = Service.GetFilteredProperties(searchQuery, minPrice, maxPrice);

            if (!string.IsNullOrEmpty(country))
                properties = properties.Where(p => p.Country == country);

            if (!string.IsNullOrEmpty(city))
                properties = properties.Where(p => p.City == city);

            if (!string.IsNullOrEmpty(region))
                properties = properties.Where(p => p.Region == region);

            ViewBag.Countries = Service.GetAllCountries();
            ViewBag.Cities = string.IsNullOrEmpty(country) ? new List<string>() : Service.GetCitiesByCountry(country);
            ViewBag.Regions = string.IsNullOrEmpty(city) ? new List<string>() : Service.GetRegionsByCity(city);

            return View(properties);
        }

        [AllowUnauthorized]
        [HttpGet]
        [Route("RealEstate/GetCities/country")]
        public JsonResult GetCities(string country)
        {
            var cities = Service.GetCitiesByCountry(country)
                .Select(city => new { value = city, text = city })
                .ToList();

            return Json(cities);
        }


        [AllowUnauthorized]
        [HttpGet]
        [Route("RealEstate/GetRegions/city")]
        public JsonResult GetRegions(string city)
        {
            var regions = Service.GetRegionsByCity(city)
                .Select(region => new { value = region, text = region }) 
                .ToList();

            return Json(regions);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Property property)
        {
            
                Service.AddProperty(property);
                return RedirectToAction(nameof(Index));

        }

        private List<Filee> SaveFiles(List<IFormFile> files)
        {
            List<Filee> uploadedFiles = new List<Filee>();

            if (files != null && files.Any())
            {
                String uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder);

                foreach (IFormFile file in files)
                {
                    String uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    String filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    uploadedFiles.Add(new Filee
                    {
                        FileName = file.FileName,
                        FilePath = filePath
                    });
                }
            }

            return uploadedFiles;
        }

        public IActionResult ManageFiles(long propertyId)
        {
            Property? property = Service.GetPropertyById(propertyId);

            if (property == null)
            {
                return NotFound();
            }

            ViewBag.PropertyId = propertyId;
            return View(property.Files);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadFiles(long propertyId, List<IFormFile> files)
        {
            if (files != null && files.Any())
            {
                List<Filee> uploadedFiles = SaveFiles(files);

                foreach (Filee file in uploadedFiles)
                {
                    file.PropertyId = propertyId;
                }

                Service.AddFilesToProperty(propertyId, uploadedFiles);
            }

            return RedirectToAction("ManageFiles", new { propertyId });
        }

        public IActionResult DeleteFile(long id)
        {
            Filee? file = Service.GetFileById(id);

            if (file == null)
            {
                return NotFound();
            }

            return View(file);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFileConfirmed(long id)
        {
            Filee? file = Service.GetFileById(id);

            if (file != null)
            {
                Service.DeleteFile(id);
            }

            return RedirectToAction("ManageFiles", new { propertyId = file?.PropertyId });
        }
        public IActionResult Edit(long id)
        {
            Property? property = Service.GetPropertyById(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Property property)
        {
            
                Service.UpdateProperty(property);
                return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Delete(long id)
        {
            Property? property = Service.GetPropertyById(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            Service.DeleteProperty(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detailes(long id)
        {
            Property? property = Service.GetPropertyDetail(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

    }
}

