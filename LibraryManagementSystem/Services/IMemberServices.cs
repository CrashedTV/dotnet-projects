public interface IMemberServices
{
    //Add Members
    void AddMembers(Members members);
    void EditMembers(Members members);
    void DeleteMembers(Members members);
    List<Members> ListMembers();
    void RenewMembership(Members members);
    void MembershipDuration(Members members);
    void MembershipType(Members members);


}
