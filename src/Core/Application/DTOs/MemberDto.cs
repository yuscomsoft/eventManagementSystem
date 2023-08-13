namespace EventManagment.Application.DTOs;
public class MemberDto : IDto
{
    public string ChandaNo { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string AuxillaryBodyName { get; set; }
    public string MiddleName { get; set; }
    public virtual DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public int JamaatId { get; set; }
    public string JamaatName { get; set; } = default!;
    public int CircuitId { get; set; }
    public string CircuitCode { get; set; }
    public string CircuitName { get; set; } = default!;
    public string Sex { get; set; } = default!;
    public string MaritalStatus { get; set; }
    public string Address { get; set; }
    public string NextOfKinPhoneNo { get; set; }
    public string NextOfKinName { get; set; }
    public string Nationality { get; set; }

    public Guid? MuqamId { get; set; }
    public string? MuqamName { get; set; }
    public Guid? DilaId { get; set; }
    public string? DilaName { get; set; }
    public Guid ZoneId { get; set; }
    public string? Zone { get; set; }

    public List<DomainEvent> DomainEvents => throw new NotImplementedException();
}
