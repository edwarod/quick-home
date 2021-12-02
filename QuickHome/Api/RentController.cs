using Microsoft.AspNetCore.Mvc;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Api
{
    [ApiController]
    [Route("api/rent")]
    public class RentController
    {
        private readonly IRentDomainService _rentDomainService;

        public RentController(IRentDomainService rentDomainService)
        {
            _rentDomainService = rentDomainService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var rents = await _rentDomainService.GetAllAsync( cancellationToken);
            return new OkObjectResult(rents);
        }

        [HttpGet]
        [Route("{rentId:int}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int rentId, CancellationToken cancellationToken = default)
        {
            var rent = await _rentDomainService.GetByIdAsync(rentId, cancellationToken);
            if (rent == null)
            {
                return new NotFoundObjectResult("Rent Not found.");
            }
            return new OkObjectResult(rent);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] RentDto rentDto, CancellationToken cancellationToken = default)
        {
            var rent = await _rentDomainService.CreateRentalRequirementAsync(rentDto, cancellationToken);
            return new CreatedResult($"/api/rent/{rent.RentID}", rent);
        }

        [HttpPut]
        [Route("approve/{rentId:int}")]
        public async Task<ActionResult> ApproveRentAsync([FromRoute] int rentId, CancellationToken cancellationToken = default)
        {
            var rent = await _rentDomainService.GetByIdAsync(rentId, cancellationToken);

            if (rent == null)
            {
                return new NotFoundObjectResult("Rent Not found.");
            }

            var rentDto = await _rentDomainService.ApproveRentalRequirementAsync(rentId, cancellationToken);

            return new OkObjectResult(rentDto);
        }

        [HttpPut]
        [Route("reject/{rentId:int}")]
        public async Task<ActionResult> RejectRentAsync([FromRoute] int rentId, CancellationToken cancellationToken = default)
        {
            var rent = await _rentDomainService.GetByIdAsync(rentId, cancellationToken);

            if (rent == null)
            {
                return new NotFoundObjectResult("Rent Not found.");
            }

            var rentDto = await _rentDomainService.RejectRentalRequirementAsync(rentId, cancellationToken);

            return new OkObjectResult(rentDto);
        }
    }
}
