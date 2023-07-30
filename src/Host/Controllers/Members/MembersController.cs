using EventManagment.Application.DTOs;
using EventManagment.Application.Members;


namespace EventManagment.Host.Controllers.Members;
public class MembersController : VersionNeutralApiController
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMemberService _memberService;

    public MembersController(IWebHostEnvironment webHostEnvironment, IMemberService memberService) => (_webHostEnvironment, _memberService) = (webHostEnvironment, memberService);

    [HttpPost]

    // [MustHavePermission(FSHAction.View, FSHResource.Users)]
    [OpenApiOperation("Get list of all members.", "")]
    public async Task<PaginationResponse<MemberDetailsDto>> GetListAsync(PaginationFilter filter)
    {
        var response = await _memberService.GetListAsync(filter);
        return response;
    }



}