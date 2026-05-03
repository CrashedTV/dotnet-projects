public class MemberService : IMemberService
{
    public readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public void AddMember(Member member)
    {
        member.JoinedDate = DateTime.Now;
        member.CreatedDate = DateTime.Now;
        member.CreatedDate = DateTime.Now;
        member.CreatedBy = "admin";
        _memberRepository.AddMember(member);
    }

    public bool DeleteMember(int memberId)
    {
        return _memberRepository.DeleteMember(memberId);
    }

    public bool EditMember(Member member)
    {
        member.ModifiedBy = "admin";
        member.ModifiedDate = DateTime.Now;
        return _memberRepository.EditMember(member);
    }

    public void RenewMembership(Member member)
    {
        member.ExpirationDate = DateTime.Now.AddDays(90);
        member.ModifiedBy = "admin";
        member.ModifiedDate = DateTime.Now;
        _memberRepository.RenewMembership(member);
    }

    public List<Member> SearchMembers(string searchParam)
    {
        return _memberRepository.SearchMembers(searchParam);
    } 

    public List<Member> ViewAllMembers()
    {
        var memberDetails = _memberRepository.ViewAllMembers();
        return memberDetails;
    }
}

