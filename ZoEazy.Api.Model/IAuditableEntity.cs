namespace ZoEazy.Api.Model
{
    public interface IAuditableEntity
    {
        Status Created { get; set; }
        Status Updated { get; set; }
        Status Deleted { get; set; }
    }
}
