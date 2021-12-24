namespace Company.Client.Presentation.Controls
{
  public class MenuShowingProcess : IMenuShowingProcess
  {
    public bool IsShow { get; private set; }

    public MenuShowingProcess()
    {
      IsShow = true;
    }

    public void Finish()
    {
      IsShow = false;
    }

    private static MenuShowingProcess _finishedInstance;

    public static MenuShowingProcess FinishedShowing
    {
      get
      {
        if (_finishedInstance == null)
        {
          _finishedInstance = new MenuShowingProcess();
          _finishedInstance.Finish();
        }

        return _finishedInstance;
      }
    }
  }
}