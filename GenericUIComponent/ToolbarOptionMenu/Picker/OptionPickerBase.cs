using System;

namespace Company.Client.Presentation.Controls
{
  public abstract class OptionPickerBase
  {
    private static uint _indexCounter;
    
    private readonly uint _globalIndex;
    private readonly Type _optionsType;
    public readonly string Tag;

    public Action<string> LoggingDelegate { get; set; }
    
    protected OptionPickerBase(Type optionsType, string tag)
    {
      _globalIndex = ++_indexCounter;
      
      _optionsType = optionsType;
      Tag = tag;
    }

    public override string ToString()
    {
      return $"[{_globalIndex:D2}]{(string.IsNullOrEmpty(Tag) ? "---" : $"[{Tag}]")} Options<{_optionsType.Name}>: ";
    }
  }
}