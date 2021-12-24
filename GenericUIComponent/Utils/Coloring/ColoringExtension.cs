using UnityEngine;

namespace Company.Client.Presentation.Utils
{
  public static class ColoringExtension
  {
    public static void TryColoring(this Transform root, Color color)
    {
      foreach (var coloring in root.GetComponents<IColorChangeable>())
      {
        coloring.SetupColor(color);
      }
    }
  }
}