using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class OptionPickerDisplayAnnotationOrientation : OptionPickerDisplayBase<AnnotationOrientation>
  {
    protected override void Display(AnnotationOrientation optionValue)
    {
      transform.EnumViewerUpdateState(optionValue);
    }
  }
}