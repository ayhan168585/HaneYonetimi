using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Dtos.MarketItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketItemsController : ControllerBase
    {
        IMarketItemService _marketItemService;

        public MarketItemsController(IMarketItemService marketItemService)
        {
            _marketItemService = marketItemService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _marketItemService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _marketItemService.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MarketItem item)
        {
            var result = _marketItemService.Add(item);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(MarketItem item)
        {
            var result = _marketItemService.Update(item);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(MarketItem item)
        {
            var result = _marketItemService.Delete(item);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("marketitemlists")]
        public IActionResult MarketItemLists()
        {
            var result = _marketItemService.MarketItemLists();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("marketitemlistsbyexpense")]
        //public IActionResult MarketItemListsByExpense(int expenseId)
        //{
        //    var result = _marketItemService.MarketItemListsByExpense(expenseId);
        //    if (result.IsSuccess)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPost("addmarketitem")]
        //public IActionResult AddMarketItem(MarketItemCreateDto marketItemCreateDto)
        //{
        //    var result = _marketItemService.AddMarketItem(marketItemCreateDto);
        //    if (result.IsSuccess)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [HttpPost("updatemarketitem")]
        public IActionResult UpdateMarketItem(MarketItemUpdateDto marketItemUpdateDto)
        {
            var result = _marketItemService.UpdateMarketItem(marketItemUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deletemarketitem")]
        public IActionResult DeleteMarketItem(int marketItemId)
        {
            var result = _marketItemService.DeleteMarketItem(marketItemId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
             

        [HttpGet("marketitemexpenses")]
        public IActionResult MarketItemExpenses()
        {
            var result = _marketItemService.MarketItemExpenses();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add-market-item")]
        public IActionResult AddMarketItem(MarketItemCreateDto marketItemCreateDto)
        {
          
            try
            {
                using (var context = new HaneYonetimiContext())
                {
                    // Yeni MarketItem oluştur
                    var marketItem = new MarketItem
                    {
                        Name = marketItemCreateDto.Name,
                        Price = marketItemCreateDto.Price,
                        CategoryId = marketItemCreateDto.CategoryId,
                        Quantity=marketItemCreateDto.Quantity,
                        UnitId = marketItemCreateDto.UnitId,
                        Photos = new List<MarketItemPhoto>() // Koleksiyon başlatıldı

                    };

                    // Fotoğraf yükleme işlemi
                    if (marketItemCreateDto.Photos != null && marketItemCreateDto.Photos.Any())
                    {
                        foreach (var photo in marketItemCreateDto.Photos)
                        {
                            // İzin verilen uzantıları kontrol et
                            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                            var fileExtension = Path.GetExtension(photo.FileName).ToLower();
                            if (!allowedExtensions.Contains(fileExtension))
                            {
                                return BadRequest("Sadece JPG ve PNG formatındaki dosyalara izin verilmektedir.");
                            }

                            // Fotoğraf kaydetme dizini
                            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/market_items");
                            if (!Directory.Exists(uploadDirectory))
                            {
                                Directory.CreateDirectory(uploadDirectory);
                            }

                            // Benzersiz dosya adı oluştur
                            var fileName = $"{Guid.NewGuid()}{fileExtension}";
                            var filePath = Path.Combine(uploadDirectory, fileName);

                            // Fotoğrafı kaydet
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                photo.CopyTo(stream);
                            }

                            // Fotoğraf kaydını ekle
                            marketItem.Photos.Add(new MarketItemPhoto
                            {
                                FilePath = fileName
                            });
                        }
                    }

                    context.MarketItems.Add(marketItem);
                    context.SaveChanges();
                }

                return Ok("Market item başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpGet("get-market-item/{id}")]
        public IActionResult GetMarketItem(int id)
        {
            using (var context = new HaneYonetimiContext())
            {
                var marketItem = context.MarketItems
                    .Include(mi => mi.Photos)
                    .Where(mi => mi.Id == id)
                    .Select(mi => new
                    {
                        mi.Name,
                        mi.Price,
                        Photos = mi.Photos.Select(p => new MarketItemPhotoDto
                        {
                            Id = p.Id,
                            FilePath = p.FilePath
                        }).ToList()
                    })
                    .FirstOrDefault();

                if (marketItem == null)
                {
                    return NotFound("Market item bulunamadı.");
                }

                return Ok(marketItem);
            }
        }

    }
}
