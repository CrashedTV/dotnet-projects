public interface IMemberServices
{
    //Add Members
    void AddMembers(Member members);
    void EditMembers(Member members);
    void DeleteMembers(Member members);
    List<Member> ListMembers();
    void RenewMembership(Member members);
    void MembershipDuration(Member members);
    void MembershipType(Member members);


}
