using System.Text.Json;

public class MemberRepository : IMemberRepository
{
    public readonly string _connectionString = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\Projects\\LibraryManagementSystem\\Data\\member.json";
    public void AddMember(Member member)
    {
        var memberDetails = GetAllMembersForOperation();

        int memberMaxId = memberDetails.Any() ? memberDetails.Max(m => m.MemberId) : 0;
        member.MemberId = memberMaxId + 1;

        memberDetails.Add(member);

        var updatedMemberDetails = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_connectionString, updatedMemberDetails);
    }

    public bool DeleteMember(int memberId)
    {
        var memberDetails = GetAllMembersForOperation();
        var memberToDelete = memberDetails.FirstOrDefault(b => b.MemberId == memberId);

        if (memberToDelete == null)
        {
            return false;
        }

        memberDetails.RemoveAll(b => b.MemberId == memberId);
        var memberString = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_connectionString, memberString);
        return true;
    }

    public bool EditMember(Member member)
    {
        var memberDetails = GetAllMembersForOperation();
        var memberToEdit = memberDetails.FirstOrDefault(b => b.MemberId == member.MemberId);

        if (memberToEdit == null)
        {
            return false;
        }
        else
        {
            memberToEdit.MemberName = member.MemberName;
            memberToEdit.ModifiedDate = member.ModifiedDate;
            memberToEdit.ModifiedBy = member.ModifiedBy;
            var memberStringUpdated = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, memberStringUpdated);
            return true;
        }
    }

    public void RenewMembership(Member member)
    {
        var memberDetails = GetAllMembersForOperation();
        var memberToRenew = memberDetails.FirstOrDefault(m => m.MemberId == member.MemberId);
        if (memberToRenew != null)
        {
            memberToRenew.ExpirationDate = member.ExpirationDate;
            memberToRenew.Status = member.Status;
            memberToRenew.ModifiedDate = member.ModifiedDate;
            memberToRenew.ModifiedBy = member.ModifiedBy;
            var memberStringUpdated = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, memberStringUpdated);
        }
    }

    public List<Member> SearchMembers(string searchParam)
    {
        var searchMembers = GetAllMembersForOperation();
        var filteredMembers = searchMembers.Where(m => m.MemberName.Contains(searchParam, StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredMembers;
    }

    public List<Member> ViewAllMembers()
    {
        return GetAllMembersForOperation();
    }

    private List<Member> GetAllMembersForOperation()
    {
        if (!File.Exists(_connectionString))
        {
            return new List<Member>();
        }
        var memberFromTable = File.ReadAllText(_connectionString);
        if (string.IsNullOrWhiteSpace(memberFromTable))
        {
            return new List<Member>();
        }

        var memberDetails = JsonSerializer.Deserialize<List<Member>>(memberFromTable);
        return memberDetails ?? new List<Member>();
    }
}
