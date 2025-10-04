using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonEffect
{
	public MaskableGraphic element;

	public ButtonEffectType buttonEffectType = ButtonEffectType.Color;

	public Color defaultColor;

	public Color activeColor;

	public Sprite defaultSprite;

	public Sprite activeSprite;
}


