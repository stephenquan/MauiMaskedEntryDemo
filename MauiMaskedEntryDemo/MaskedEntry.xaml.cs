using System.Text.RegularExpressions;

namespace MauiMaskedEntryDemo;

/// <summary>
/// Custom Entry component with a mask.
/// </summary>
public partial class MaskedEntry : ContentView, IEntry, IBorderStroke
{
	/// <summary>
	/// Bindable property for <see cref="BlinkIndex"/>.
	/// </summary>
	public static readonly BindableProperty BlinkIndexProperty = BindableProperty.Create(nameof(BlinkIndex), typeof(int), typeof(MaskedEntry), 0);

	/// <summary>
	/// Gets or sets the blink index.
	/// </summary>
	public int BlinkIndex
	{
		get => (int)GetValue(BlinkIndexProperty);
		set => SetValue(BlinkIndexProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="BlinkInterval"/>.
	/// </summary>
	public static readonly BindableProperty BlinkIntervalProperty = BindableProperty.Create(nameof(BlinkInterval), typeof(int), typeof(MaskedEntry), 700);

	/// <summary>
	/// Gets or sets the blink interval in milliseconds.
	/// </summary>
	public int BlinkInterval
	{
		get => (int)GetValue(BlinkIntervalProperty);
		set => SetValue(BlinkIntervalProperty, value);
	}

	#region IEntry
	/// <summary>
	/// Bindable property for <see cref="CharacterSpacing"/>.
	/// </summary>
	public static BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(double), typeof(MaskedEntry), 0.0);

	/// <summary>
	/// Gets or sets the character spacing.
	/// </summary>
	public double CharacterSpacing
	{
		get => (double)GetValue(CharacterSpacingProperty);
		set => SetValue(CharacterSpacingProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="ClearButtonVisibility"/>.
	/// </summary>
	public static BindableProperty ClearButtonVisibilityProperty = BindableProperty.Create(nameof(ClearButtonVisibility), typeof(ClearButtonVisibility), typeof(MaskedEntry), ClearButtonVisibility.WhileEditing);

	/// <summary>
	/// Gets or sets the clear button visibility.
	/// </summary>
	public ClearButtonVisibility ClearButtonVisibility
	{
		get => (ClearButtonVisibility)GetValue(ClearButtonVisibilityProperty);
		set => SetValue(ClearButtonVisibilityProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="CursorPosition"/>.
	/// </summary>
	public static BindableProperty CursorPositionProperty = BindableProperty.Create(nameof(CursorPosition), typeof(int), typeof(MaskedEntry), 0);

	/// <summary>
	/// Gets or sets the cursor position.
	/// </summary>
	public int CursorPosition
	{
		get => (int)GetValue(CursorPositionProperty);
		set => SetValue(CursorPositionProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="SelectionLength"/>.
	/// </summary>
	public static BindableProperty SelectionLengthProperty = BindableProperty.Create(nameof(SelectionLength), typeof(int), typeof(MaskedEntry), 0);

	/// <summary>
	/// Gets or sets the selection length.
	/// </summary>
	public int SelectionLength
	{
		get => (int)GetValue(SelectionLengthProperty);
		set => SetValue(SelectionLengthProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="Font"/>.
	/// </summary>
	public static BindableProperty FontProperty = BindableProperty.Create(nameof(Font), typeof(Microsoft.Maui.Font), typeof(MaskedEntry), Microsoft.Maui.Font.Default);

	/// <summary>
	/// Gets or sets the font.
	/// </summary>
	public Microsoft.Maui.Font Font
	{
		get => (Microsoft.Maui.Font)GetValue(FontProperty);
		set => SetValue(FontProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="HorizontalTextAlignment"/>.
	/// </summary>
	public static BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(MaskedEntry), TextAlignment.Start);

	/// <summary>
	/// Gets or sets the horizontal text alignment.
	/// </summary>
	public TextAlignment HorizontalTextAlignment
	{
		get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
		set => SetValue(HorizontalTextAlignmentProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="IsPassword"/>.
	/// </summary>
	public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaskedEntry), false);

	/// <summary>
	/// Gets or sets a value indicating whether the text is a password.
	/// </summary>
	public bool IsPassword
	{
		get => (bool)GetValue(IsPasswordProperty);
		set => SetValue(IsPasswordProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="IsReadOnly"/>.
	/// </summary>
	public static BindableProperty IsReadOnlyProperty = BindableProperty.Create(nameof(IsReadOnly), typeof(bool), typeof(MaskedEntry), false);

	/// <summary>
	/// Gets or sets a value indicating whether the text is read-only.
	/// </summary>
	public bool IsReadOnly
	{
		get => (bool)GetValue(IsReadOnlyProperty);
		set => SetValue(IsReadOnlyProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="IsTextPredictionEnabled"/>.
	/// </summary>
	public static BindableProperty IsSpellCheckEnabledProperty = BindableProperty.Create(nameof(IsSpellCheckEnabled), typeof(bool), typeof(MaskedEntry), true);

	/// <summary>
	/// Gets or sets a value indicating whether text prediction is enabled.
	/// </summary>
	public bool IsSpellCheckEnabled
	{
		get => (bool)GetValue(IsSpellCheckEnabledProperty);
		set => SetValue(IsSpellCheckEnabledProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="IsTextPredictionEnabled"/>.
	/// </summary>
	public static BindableProperty IsTextPredictionEnabledProperty = BindableProperty.Create(nameof(IsTextPredictionEnabled), typeof(bool), typeof(MaskedEntry), true);

	/// <summary>
	/// Gets or sets a value indicating whether text prediction is enabled.
	/// </summary>
	public bool IsTextPredictionEnabled
	{
		get => (bool)GetValue(IsTextPredictionEnabledProperty);
		set => SetValue(IsTextPredictionEnabledProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="Keyboard"/>.
	/// </summary>
	public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaskedEntry), Keyboard.Default);

	/// <summary>
	/// Gets or sets the keyboard type.
	/// </summary>
	public Keyboard Keyboard
	{
		get => (Keyboard)GetValue(KeyboardProperty);
		set => SetValue(KeyboardProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="MaxLength"/>.
	/// </summary>
	public static BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaskedEntry), int.MaxValue);

	/// <summary>
	/// Gets or sets the maximum length of the text.
	/// </summary>
	public int MaxLength
	{
		get => (int)GetValue(MaxLengthProperty);
		set => SetValue(MaxLengthProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="Placeholder"/>.
	/// </summary>
	public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaskedEntry), string.Empty);

	/// <summary>
	/// Gets or sets the placeholder text.
	/// </summary>
	public string Placeholder
	{
		get => (string)GetValue(PlaceholderProperty);
		set => SetValue(PlaceholderProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="PlaceholderColor"/>.
	/// </summary>
	public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaskedEntry), Colors.Gray);

	/// <summary>
	/// Gets or sets the placeholder color.
	/// </summary>
	public Color PlaceholderColor
	{
		get => (Color)GetValue(PlaceholderColorProperty);
		set => SetValue(PlaceholderColorProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="ReturnType"/>.
	/// </summary>
	public static BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaskedEntry), ReturnType.Default);

	/// <summary>
	/// Gets or sets the return type.
	/// </summary>
	public ReturnType ReturnType
	{
		get => (ReturnType)GetValue(ReturnTypeProperty);
		set => SetValue(ReturnTypeProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="Text"/>.
	/// </summary>
	public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaskedEntry), string.Empty);

	/// <summary>
	/// Gets or sets the text.
	/// </summary>
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="TextColor"/>.
	/// </summary>
	public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaskedEntry), Colors.Black);

	/// <summary>
	/// Gets or sets the text color.
	/// </summary>
	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="VerticalTextAlignment"/>.
	/// </summary>
	public static BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(MaskedEntry), TextAlignment.Start);

	/// <summary>
	/// Gets or sets the vertical text alignment.
	/// </summary>
	public TextAlignment VerticalTextAlignment
	{
		get => (TextAlignment)GetValue(VerticalTextAlignmentProperty);
		set => SetValue(VerticalTextAlignmentProperty, value);
	}
	#endregion

	#region IBorderView
	/// <summary>
	/// Bindable property for <see cref="Stroke"/>.
	/// </summary>
	public static BindableProperty StrokeProperty = BindableProperty.Create(nameof(Stroke), typeof(Paint), typeof(MaskedEntry), DefaultStroke);

	/// <summary>
	/// Default stroke color.
	/// </summary>
	static Paint DefaultStroke => new SolidPaint { Color = Colors.Red };

	/// <summary>
	/// Gets or sets the stroke.
	/// </summary>
	public Paint? Stroke
	{
		get => (Paint?)GetValue(StrokeProperty);
		set => SetValue(StrokeProperty, value);
	}

	/// <summary>
	/// Not implemented Shape property.
	/// </summary>
	public IShape? Shape => throw new NotImplementedException();

	/// <summary>
	/// Not implemented StrokeThickness property.
	/// </summary>
	public double StrokeThickness => throw new NotImplementedException();

	/// <summary>
	/// Not implemented StrokeLineCap property.
	/// </summary>
	public LineCap StrokeLineCap => throw new NotImplementedException();

	/// <summary>
	/// Not implemented StrokeLineJoin property.
	/// </summary>
	public LineJoin StrokeLineJoin => throw new NotImplementedException();

	/// <summary>
	/// Not implemented StrokeMiterLimit property.
	/// </summary>
	public float[]? StrokeDashPattern => throw new NotImplementedException();

	/// <summary>
	/// Not implemented StrokeDashOffset property.
	/// </summary>
	public float StrokeDashOffset => throw new NotImplementedException();

	/// <summary>
	/// Not implemented StrokeMiterLimit property.
	/// </summary>
	public float StrokeMiterLimit => throw new NotImplementedException();

	#endregion

	[GeneratedRegex(@"^[0-9A-Za-z]{0,10}$")]
	public static partial Regex ValidRegex();

	/// <summary>
	/// Bindable property for <see cref="RegexMask"/>.
	/// </summary>
	public static BindableProperty RegexMaskProperty = BindableProperty.Create(nameof(RegexMask), typeof(string), typeof(MaskedEntry), string.Empty);

	/// <summary>
	/// Gets or sets the regex mask.
	/// </summary>
	public string RegexMask
	{
		get => (string)GetValue(RegexMaskProperty);
		set => SetValue(RegexMaskProperty, value);
	}

	IDispatcherTimer? blinkTimer = null;

	/// <summary>
	/// Initializes a new instance of the <see cref="MaskedEntry"/> class.
	/// </summary>
	public MaskedEntry()
	{
		InitializeComponent();

		entry.PropertyChanged += (s, e) =>
		{
			switch (e.PropertyName)
			{
				case nameof(IEntry.CursorPosition):
					this.CursorPosition = entry.CursorPosition;
					break;
				case nameof(IEntry.SelectionLength):
					this.SelectionLength = entry.SelectionLength;
					break;
				case nameof(IEntry.Text):
					if (string.IsNullOrEmpty(RegexMask))
					{
						this.Text = entry.Text;
					}
					else if (Regex.Match(entry.Text, RegexMask).Success)
					{
						this.Text = entry.Text;
					}
					else
					{
						this.Dispatcher.Dispatch(() => { entry.Text = this.Text; });
					}
					break;
			}
		};

		this.PropertyChanged += (s, e) =>
		{
			switch (e.PropertyName)
			{
				case nameof(IEntry.CursorPosition):
					entry.CursorPosition = this.CursorPosition;
					break;
				case nameof(IEntry.SelectionLength):
					entry.SelectionLength = this.SelectionLength;
					break;
				case nameof(IEntry.Text):
					entry.Text = this.Text;
					break;
			}
		};

		blinkTimer = this.Dispatcher.CreateTimer();
		blinkTimer.Interval = TimeSpan.FromMilliseconds(BlinkInterval);
		blinkTimer.Tick += (s, e) =>
		{
			BlinkIndex = (BlinkIndex + 1) % 2;
		};
		blinkTimer.Start();
	}

	/// <summary>
	/// Event handler for when the entry text changes.
	/// </summary>
	/// <exception cref="NotImplementedException"></exception>
	public void Completed()
	{
		// Not implemented.
	}
}
