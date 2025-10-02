using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnalyzerView : AbstractAnalyzerView
{
    [Header("UI")]
    [SerializeField] private Image _displayImage;
    [SerializeField] private TextMeshProUGUI _displayText;
    [Space]
    [SerializeField] private Color _displayOffColor = Color.black;

    private string _template;
    private Color _displayOnColor;

    private void Awake() => Init();

    public override void PowerOn()
    {
        _displayImage.color = _displayOnColor;
        ShowDisplayImage();
        ShowDisplayText();
    }

    public override void PowerOff()
    {
        HideDisplayText();
        HideDisplayImage();
    }

    public override void UpdatePowerOn(float delta)
    {
        Color currentColor = Color.Lerp(_displayOffColor, _displayOnColor, delta);
        _displayImage.color = currentColor;
    }

    public override void UpdatePowerOff(float delta)
    {
        Color currentColor = Color.Lerp(_displayOnColor, _displayOffColor, delta);
        _displayImage.color = currentColor;
    }

    public override void ShowDisplayImage() => _displayImage.gameObject.SetActive(true);

    public override void HideDisplayImage()
    {
        _displayImage.color = _displayOffColor;
        _displayImage.gameObject.SetActive(false);
    }

    public override void ShowDisplayText() => _displayText.gameObject.SetActive(true);

    public override void HideDisplayText()
    {
        _displayText.gameObject.SetActive(false);
        UpdateDistanceText(0f);
    }

    public override void UpdateDistanceText(float distance) => _displayText.text = string.Format(_template, distance);

    private void Init()
    {
        _template = _displayText.text;
        _displayOnColor = _displayImage.color;
        PowerOff();
    }
}