using System.Globalization;

namespace MauiMaskedEntryDemo;

/// <summary>
/// Converter to help set an internal Label FormattedString to make it render like an Entry.
/// </summary>
public class LabelFormattedStringConverter : IMultiValueConverter
{
	const string unicodeCombiningLongVerticalOverlay = "\u20d2";

	/// <summary>
	/// Converts values describing Entry properties to a FormattedString that can be used to render a Label like an Entry.
	/// </summary>
	/// <param name="values"></param>
	/// <param name="targetType"></param>
	/// <param name="parameter"></param>
	/// <param name="culture"></param>
	/// <returns></returns>
	public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values[1] is Color textColor
			&& values[2] is int cursorPosition
			&& values[3] is int selectionLength
			&& values[4] is bool isFocused
			&& values[5] is bool isReadOnly
			&& values[6] is bool isEnabled
			&& values[7] is string fontFamily)
		{
			string text = (values[0] is string _text) ? _text : "";
			var formattedString = new FormattedString();
			if (!isEnabled)
			{
				formattedString.Spans.Add(new Span { Text = text, TextColor = Colors.Gray, FontFamily = fontFamily });
				return formattedString;
			}
			if (isReadOnly || (cursorPosition < 0 || cursorPosition + selectionLength > text.Length))
			{
				formattedString.Spans.Add(new Span { Text = text, TextColor = textColor, FontFamily = fontFamily });
				return formattedString;
			}
			if (selectionLength > 0)
			{
				if (cursorPosition > 0)
				{
					formattedString.Spans.Add(new Span { Text = text.Substring(0, cursorPosition), TextColor = textColor, FontFamily = fontFamily });
				}
				formattedString.Spans.Add(new Span { Text = text.Substring(cursorPosition, selectionLength), TextColor = Colors.White, BackgroundColor = Colors.SteelBlue, FontFamily = fontFamily });
				if (cursorPosition + selectionLength < text.Length)
				{
					formattedString.Spans.Add(new Span { Text = text.Substring(cursorPosition + selectionLength), TextColor = textColor, FontFamily = fontFamily });
				}
				return formattedString;
			}
			if (isFocused)
			{
				formattedString.Spans.Add(new Span { Text = text.Substring(0, cursorPosition) + unicodeCombiningLongVerticalOverlay + text.Substring(cursorPosition), TextColor = Colors.Black, FontFamily = fontFamily });
				return formattedString;
			}
			formattedString.Spans.Add(new Span { Text = text, TextColor = textColor, FontFamily = fontFamily });
			return formattedString;
		}
		return null;
	}

	/// <summary>
	/// Not implemented.
	/// </summary>
	/// <param name="value"></param>
	/// <param name="targetTypes"></param>
	/// <param name="parameter"></param>
	/// <param name="culture"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}