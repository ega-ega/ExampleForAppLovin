using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;
using Company.Client.Presentation.Utils;

namespace Company.Client.Presentation.Controls
{
  [RequireComponent(typeof(PointerClickHandlerProxy))]
  public class AnnotationOrientationOptionMenuItem : MonoBehaviour, IOptionMenuItem<AnnotationOrientation>
  {
    [SerializeField] private Transform selectionView;
    public IOption<AnnotationOrientation> Option { get; private set; }

    public void Setup(IOption<AnnotationOrientation> option, IOptionMenuItem<AnnotationOrientation>.Selected selectHandler)
    {
      Option = option;

      transform.EnumViewerUpdateState(option.Value);
      
      gameObject.TurnOnClicker(selectHandler);
    }

    public void ChangeSelect(bool isSelected)
    {
      selectionView.gameObject.SetActive(isSelected);
    }
  }
}