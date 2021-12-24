using UnityEngine;

namespace Company.Client.Presentation.Utils
{
  public static class EnumStateViewerExtension
  {
    public static void EnumViewerUpdateState<TEnum>(this Transform root, TEnum state)
    {
      foreach (var stateViewer in root.GetComponents<IEnumStateViewer<TEnum>>())
      {
        stateViewer.SetupState(state);
      }
    }
  }
}