namespace TestePleno.Models {
  public class Fare : IModel {
    public Guid Id { get; set ;}
    public Guid OperatorId { get; set ;}
    public int Status { get; set; }
  }
}