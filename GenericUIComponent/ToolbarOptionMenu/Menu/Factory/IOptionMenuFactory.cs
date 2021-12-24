using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public interface IOptionMenuFactory
  {
    IOptionMenu<TValue> Create<TValue>(Transform parent);
  }
}