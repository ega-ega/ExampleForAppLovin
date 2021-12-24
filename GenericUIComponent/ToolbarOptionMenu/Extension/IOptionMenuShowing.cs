using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public interface IOptionMenuShowing
  {
    IMenuShowingProcess Invoke(Transform target);
    IOptionMenuShowing Concat(IOptionMenuShowing another);
  }
}