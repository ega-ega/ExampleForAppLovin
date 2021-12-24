namespace Company.Client.Presentation.Utils
{
  public interface IEnumStateViewer<in TEnum>
  {
    void SetupState(TEnum state);
  }
}