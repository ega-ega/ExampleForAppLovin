using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;
using Company.Client.Presentation.Utils;

namespace Company.Client.Presentation.Controls
{
  [RequireComponent(typeof(PointerClickHandlerProxy))]
  public class ThicknessOptionMenuItem : MonoBehaviour, IOptionMenuItem<AnnotationThickness>
  {
    [SerializeField] private Transform selectionView;

    public IOption<AnnotationThickness> Option { get; private set; }
    
    public void Setup(IOption<AnnotationThickness> option, IOptionMenuItem<AnnotationThickness>.Selected selectHandler)
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