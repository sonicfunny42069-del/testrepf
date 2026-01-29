using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace V2.UI;

public class UIPanelButton : UIElement
{
	private object _text;

	private MouseEvent _leftClickAction;

	private UIPanel _uiPanel;

	private UIText _uiText;

	public string Text
	{
		get
		{
			UIText uiText = _uiText;
			return ((uiText != null) ? uiText.Text : null) ?? string.Empty;
		}
		set
		{
			_text = value;
		}
	}

	public UIPanelButton(object text, MouseEvent leftClickAction)
	{
		_text = text?.ToString();
		_leftClickAction = leftClickAction;
	}

	public override void OnInitialize()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		_uiPanel = new UIPanel();
		((UIElement)_uiPanel).Width = StyleDimension.Fill;
		((UIElement)_uiPanel).Height = StyleDimension.Fill;
		_uiText = new UIText("", 1f, false);
		((UIElement)_uiText).VAlign = (((UIElement)_uiText).HAlign = 0.5f);
		((UIElement)_uiPanel).OnLeftClick += _leftClickAction;
		((UIElement)_uiPanel).Append((UIElement)(object)_uiText);
		((UIElement)this).Append((UIElement)(object)_uiPanel);
	}

	public override void Update(GameTime gameTime)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (_text != null)
		{
			_uiText.SetText(_text.ToString());
			_text = null;
			((UIElement)this).Recalculate();
			base.MinWidth = ((UIElement)_uiText).MinWidth;
			base.MinHeight = ((UIElement)_uiText).MinHeight;
		}
	}
}
