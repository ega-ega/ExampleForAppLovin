using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public class OptionPicker<TValue> : OptionPickerBase, IOptionPicker
  {
    private readonly List<IOption<TValue>> _options = new List<IOption<TValue>>();

    public IEnumerable<IOption<TValue>> Options => _options;
    public IOption<TValue> SelectedOption { get; private set; }
    
    public event Action SelectionChanged;
    public event Action<IOption<TValue>> SelectionOptionChanged;

    public OptionPicker(IEnumerable<TValue> optionsValues, IOptionFactory optionFactory, string tag = "")
      : base(typeof(TValue), tag)
    {
      foreach (var context in optionsValues)
      {
        _options.Add(optionFactory.Create(context));
      }

      SelectedOption = _options.FirstOrDefault();
    }

    public OptionPicker(IEnumerable<TValue> optionsValues, IOptionFactory optionFactory, TValue initialValue, Func<TValue, TValue, bool> comparer = null, string tag = "")
      : this(optionsValues, optionFactory, tag)
    {
      foreach (var option in _options)
      {
        if (comparer != null && comparer(option.Value, initialValue) ||
            comparer == null && option.Value.Equals(initialValue))
        {
          SelectedOption = option;
          return;
        }
      }
    }

    public void Pick(IOption<TValue> option)
    {
      SelectedOption = option;

      LoggingDelegate?.Invoke($"Options Pick! {this}");

      SelectionChanged?.Invoke();
      SelectionOptionChanged?.Invoke(SelectedOption);
    }
    
    public override string ToString()
    {
      return base.ToString() + $"{SelectedOption.Value}";
    }
    
    // Factory from enum-type
    public static OptionPicker<TValue> FromEnum(IOptionFactory optionFactory,bool reverseOrderElements = false,  TValue initialValue = default, string tag = "")
    {
      if (!typeof(TValue).IsEnum)
      {
        Debug.LogError($"Creation OptionPicker from enum failed: type:'{typeof(TValue)}' not enum");
        return null;
      }

      IEnumerable<TValue> GetValues()
      {
        var values = Enum.GetValues(typeof(TValue)).Cast<TValue>();
        if (reverseOrderElements)
        {
          values = values.Reverse();
        }
        
        foreach (var value in values)
        {
          yield return value;
        }
      }

      return new OptionPicker<TValue>(GetValues(), optionFactory, initialValue,null, tag);
    }
  }
}
