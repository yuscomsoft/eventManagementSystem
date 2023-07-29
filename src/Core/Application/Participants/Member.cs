using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Participants;
public class Member
{
    public string MemberNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public IList<Member> Members { get; set; } = new List<Member>();

    public Member()
    {
        Member member = new Member { MemberNumber = "123456", FirstName = "Ade", LastName = "Bayo" };
        Member member2 = new Member { MemberNumber = "3456667", FirstName = "Kola", LastName = "Tunde" };
        Member member3 = new Member { MemberNumber = "56778", FirstName = "Ayo", LastName = "Wale" };

        Members.Add(member);
        Members.Add(member2);
        Members.Add(member3);
    }


}
