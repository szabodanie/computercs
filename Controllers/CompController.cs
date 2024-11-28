using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers
{
    [Route("osystems")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        private readonly ComputerContext computerContext;

        public OsystemController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }
        [HttpPost]
        public async Task<ActionResult<Osystem>> Post(CreateOsysytemDto createOsysytemDto)
        {
            var os = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = createOsysytemDto.Name,
                CreatedTime = DateTime.Now
            };
            if (os != null)
            {
                await computerContext.Osystems.AddAsync(os);
                await computerContext.SaveChangesAsync();
                return StatusCode(201, os);

            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<Osystem>> Get()
        {
            return Ok(await computerContext.Osystems.ToListAsync()); using ComputerApi.Models;
            using Microsoft.AspNetCore.Mvc;
            using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers
    {
        [Route("osystems")]
        [ApiController]
        public class OsystemController : ControllerBase
        {
            private readonly ComputerContext computerContext;

            public OsystemController(ComputerContext computerContext)
            {
                this.computerContext = computerContext;
            }

            [HttpPost]
            public async Task<ActionResult<Osystem>> Post(CreateOsystemDto createOsystemDto)
            {
                var os = new Osystem
                {
                    Id = Guid.NewGuid(),
                    Name = createOsystemDto.Name,
                    CreatedTime = DateTime.Now
                };

                if (os != null)
                {
                    await computerContext.Osystems.AddAsync(os);
                    await computerContext.SaveChangesAsync();
                    return StatusCode(201, os);
                }

                return BadRequest();
            }

            [HttpGet]
            public async Task<ActionResult<Osystem>> Get()
            {
                return Ok(await computerContext.Osystems.ToListAsync());
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Osystem>> GetByID(Guid id)
            {
                var os = await computerContext.Osystems.FirstOrDefaultAsync(os => os.Id == id);

                if (os != null)
                {
                    return Ok(os);
                }

                return NotFound();
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Osystem>> Put(UpdateOsystemDto updateOsystemDto, Guid id)
            {
                var existingOs = await computerContext.Osystems.FirstOrDefaultAsync(os => os.Id == id);

                if (existingOs != null)
                {
                    existingOs.Name = updateOsystemDto.Name;
                    computerContext.Osystems.Update(existingOs);
                    await computerContext.SaveChangesAsync();
                    return Ok(existingOs);

                }
                return NotFound(new { message = "Nincs ilyen találat." });
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(Guid id)
            {
                var os = await computerContext.Osystems.FirstOrDefaultAsync(o => o.Id == id);

                if (os != null)
                {
                    computerContext.Osystems.Remove(os);
                    await computerContext.SaveChangesAsync();
                    return Ok(new { message = "Sikeres törlés!" });
                }

                return NotFound(new { message = "Nincs ilyen találat." });
            }
        }
    }
}
        [HttpGet("{id")]
        public async Task<ActionResult<Osystem>> GetByID(Guid id)
        {
            var os = await computerContext.Osystems.FirstOrDefaultAsync(o => o.Id == id);

            if (os != null)
            {
                return Ok(os);
            }
            return NotFound();

        }
        [HttpPut("{id")]
        public async Task<ActionResult<Osystem>> Put(UpdateOsysytemDto updateOsystemDto, Guid id)
        {
            var existingOs = await computerContext.Osystems.FirstOrDefaultAsync(os => os.Id == id);

            if (existingOs != null)
            {
                existingOs.Name = updateOsystemDto.Name;
                computerContext.Osystems.Update(existingOs);
                await computerContext.SaveChangesAsync();
                return Ok();
            }

            {
                return Ok(new { message = "Nincs ilyen találat" });
            }
        }
        [HttpDelete("{id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var os = await computerContext.Osystems.FirstOrDefaultAsync(os => os.Id == id);

            if (os != null)
            {
                computerContext.Osystems.Remove(os);
                await computerContext.SaveChangesAsync();
                return Ok(new { message ="Sikeres törlés" });
            }
            return NotFound(new { message = "Nem sikerült törölni" });
        }
[HttpGet("allMicrosoftOs")]
public async Task<ActionResult<Comp>> GetAllMicrosoftOs()
{
    var microOs = await computerContext.Comps.Where(cmp => cmp.Os.Name.Contains("Microsoft")).Select(cmp=> new {cmp.Brand, cmp.Type, cmp.Memory}).ToListAsync();
    return Ok(microOs);
}
[httpGet("orderComputer")]
public async Task<ActionResult<Osystem>> GetComputer()
{
    var orderOs = await computerContext.Osystems.OverByDescending(o => o.Name).ToListAsynv();
    return Ok(orderOs);
}
[HttpGet("maxDisplaySize")]
public async Task<ActionResult<Comp>> GetMaxDisplaySize()
{
    var maxSize= await computerContext.Comps.MaxAsync(cmp => cmp.Display);
    var maxSizeComputer = await computerContext.Comps.Where(cmp => cmp.Display == maxSize).Select(cmp=> new {cmp.Brand, cmp.Type,cmp.Os.Name}).ToListAsync();
    return Ok(maxSizeComputer);
}
[HttpGet("newComputer")]
public async Task<ActionResult<Comp>> GetNewcoumputer()
{
    var newComputerDate = await computerContext.Comps.MaxAsync(comp => comp.CreatedTime);
    var newComputer = await computerContext.Comps.Where(comp => comp.CreatedTime == newComputerDate).Select(cmp => new {cmp, cmp.Os.Name}).ToListAsync();
return Ok(newComputer);
}

}
}