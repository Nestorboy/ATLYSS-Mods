﻿using Nessie.ATLYSS.EasySettings.Extensions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Nessie.ATLYSS.EasySettings.UIElements;

public class AtlyssAdvancedSlider : BaseAtlyssLabelElement
{
    public Text ValueText;

    private Slider _slider;
    private Button _resetButton;

    public Slider Slider
    {
        get => _slider;
        set
        {
            if (_slider) _slider.onValueChanged.RemoveListener(ValueChanged);
            _slider = value;
            if (_slider) _slider.onValueChanged.AddListener(ValueChanged);
        }
    }

    public Button ResetButton
    {
        get => _resetButton;
        set
        {
            if (_resetButton) _resetButton.onClick.RemoveListener(ResetClicked);
            _resetButton = value;
            if (_resetButton) _resetButton.onClick.AddListener(ResetClicked);
        }
    }

    public UnityEvent<float> OnValueChanged { get; } = new();
    public UnityEvent OnResetClicked { get; } = new();

    public void Initialize()
    {
        Label.text = "Advanced Slider";
        ValueText.text = $"{0f}";

        Slider.onValueChanged.RemoveAndDisableAllListeners();
        Slider.onValueChanged.AddListener(ValueChanged);
        Slider.wholeNumbers = false;
        Slider.minValue = 0f;
        Slider.maxValue = 1f;
        Slider.SetValueWithoutNotify(0f);

        ResetButton.onClick.RemoveAndDisableAllListeners();
        ResetButton.onClick.AddListener(ResetClicked);
    }

    public void SetValue(float value) => _slider.value = value;

    private void ValueChanged(float newValue) => OnValueChanged.Invoke(newValue);
    private void ResetClicked() => OnResetClicked.Invoke();
}