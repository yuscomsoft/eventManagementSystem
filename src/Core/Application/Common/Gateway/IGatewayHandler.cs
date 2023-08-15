using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagment.Application.DTOs;

namespace EventManagment.Application.Common.Gateway;
public interface IGatewayHandler
{
    Task<IList<MemberDto>> GetMembersAsync();
    Task<MemberDto> GetMemberAsync(string memberNo);

}
