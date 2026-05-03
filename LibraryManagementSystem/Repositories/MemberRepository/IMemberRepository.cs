public interface IMemberRepository
{
    void AddMember(Member member);
    bool EditMember(Member member);
    bool DeleteMember(int memberId);
    List<Member> ViewAllMembers();
    List<Member> SearchMembers(string searchParam);
    void RenewMembership(Member member);
}
