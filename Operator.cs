namespace TestePleno.Models {
  public class Operator : IModel {
    public Guid Id { get; set; }
    public string Code { get; set; }

    public Operator(string code)
    {
      Code = code;
    }
  }
}