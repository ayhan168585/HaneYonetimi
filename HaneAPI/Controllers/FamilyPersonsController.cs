using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyPersonsController : ControllerBase
    {
        IFamilyPersonService _familyPersonService;

        public FamilyPersonsController(IFamilyPersonService familyPersonService)
        {
            _familyPersonService = familyPersonService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _familyPersonService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _familyPersonService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(FamilyPerson user)
        {
            var result = _familyPersonService.Delete(user);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deletefamilyperson")]
        public IActionResult DeleteFamilyPerson(int userId)
        {
            var result = _familyPersonService.DeleteFamilyPerson(userId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("addfamilyperson")]
        public IActionResult AddFamilyPerson(FamilyPersonCreateDto userCreateDto)
        {
            var result = _familyPersonService.AddFamilyPerson(userCreateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallfamilyperson")]
        public IActionResult GetAllFamilyPersons()
        {
            var result = _familyPersonService.GetAllFamilyPersons();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getfamilypersondetail")]
        public IActionResult GetFamilyPersonDetail(int id)
        {
            var result = _familyPersonService.GetFamilyPersonDetail(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("familypersonsinrole")]
        public IActionResult FamilyPersonsInRole(int roleId)
        {
            var result = _familyPersonService.FamilyPersonsInRole(roleId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("familypersonwisefinancials")]
        public IActionResult FamilyPersonWiseFinancials()
        {
            var result = _familyPersonService.FamilyPersonWiseFinancials();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("averagefamilypersonexpense")]
        public IActionResult AverageFamilyPersonExpense()
        {
            var result = _familyPersonService.AverageFamilyPersonExpense();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("upload-profile-picture/{familyPersonId}")]
        public IActionResult UploadProfilePicture(int familyPersonId, IFormFile profilePicture)
        {
            try
            {
                // Fotoğraf kontrolü
                if (profilePicture == null || profilePicture.Length == 0)
                {
                    return BadRequest("Fotoğraf yüklenemedi. Lütfen geçerli bir dosya seçin.");
                }

                // İzin verilen dosya türlerini kontrol et (.jpg, .png gibi)
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(profilePicture.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Sadece JPG ve PNG formatındaki dosyalara izin verilmektedir.");
                }

                // Yükleme dizini (wwwroot/uploads/profile_pictures)
                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/profile_pictures");
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                // Benzersiz dosya adı oluştur
                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadDirectory, fileName);

                // Fotoğrafı dizine kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    profilePicture.CopyTo(stream);
                }

                // Kullanıcıyı güncelle
                using (var context = new HaneYonetimiContext())
                {
                    var familyPerson = context.FamilyPersons.SingleOrDefault(u => u.Id == familyPersonId);
                    if (familyPerson == null)
                    {
                        return NotFound("Kullanıcı bulunamadı.");
                    }

                    // Eski fotoğrafı sil
                    if (!string.IsNullOrEmpty(familyPerson.ProfilePicture))
                    {
                        var oldFilePath = Path.Combine(uploadDirectory, familyPerson.ProfilePicture);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Yeni fotoğrafı kullanıcıya kaydet
                    familyPerson.ProfilePicture = fileName;
                    context.SaveChanges();
                }

                return Ok("Fotoğraf başarıyla yüklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpGet("get-profile-picture/{FamilyPersonId}")]
        public IActionResult GetProfilePicture(int FamilyPersonId)
        {
            using (var context = new HaneYonetimiContext())
            {
                var familyPerson = context.FamilyPersons.SingleOrDefault(u => u.Id == FamilyPersonId);
                if (familyPerson == null || string.IsNullOrEmpty(familyPerson.ProfilePicture))
                {
                    return NotFound("Profil fotoğrafı bulunamadı.");
                }

                var filePath = Path.Combine("wwwroot/uploads/profile_pictures", familyPerson.ProfilePicture);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("Fotoğraf dosyası bulunamadı.");
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fileStream, "image/jpeg");
            }
        }
        [HttpPost("transaction")]
        public IActionResult TransactionTest(FamilyPerson familyPerson)
        {
            var result = _familyPersonService.TransactionalOperation(familyPerson);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }



    }
}
