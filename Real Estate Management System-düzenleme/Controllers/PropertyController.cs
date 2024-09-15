using Microsoft.AspNetCore.Mvc;

public class PropertyController : Controller
{
    private readonly HttpClient _httpClient;

    public PropertyController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PropertyViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Property/Add", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            ModelState.AddModelError("", "İlan ekleme başarısız.");
        }
        return View(model);
    }
    public async Task<IActionResult> List()
    {
        var response = await _httpClient.GetAsync("api/Property/GetAll");

        if (response.IsSuccessStatusCode)
        {
            var properties = await response.Content.ReadFromJsonAsync<IEnumerable<PropertyViewModel>>();
            return View(properties);
        }

        return View(new List<PropertyViewModel>());
    }
}











//using Microsoft.AspNetCore.Mvc;

//namespace Real_Estate_Management_System_düzenleme.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PropertyController : ControllerBase
//    {
//        private readonly IPropertyService _propertyService;

//        public PropertyController(IPropertyService propertyService)
//        {
//            _propertyService = propertyService;
//        }

//        [HttpGet("GetAll")]
//        public async Task<IActionResult> GetAll()
//        {
//            var properties = await _propertyService.GetAllPropertiesAsync();
//            return Ok(properties);
//        }

//        [HttpPost("Add")]
//        public async Task<IActionResult> Add([FromBody] PropertyDto propertyDto)
//        {
//            await _propertyService.AddPropertyAsync(propertyDto);
//            return Ok();
//        }

//        [HttpPut("Approve/{id}")]
//        public async Task<IActionResult> Approve(int id)
//        {
//            await _propertyService.ApprovePropertyAsync(id);
//            return Ok();
//        }

//        [HttpDelete("Delete/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _propertyService.DeletePropertyAsync(id);
//            return Ok();
//        }
//    }

//}
