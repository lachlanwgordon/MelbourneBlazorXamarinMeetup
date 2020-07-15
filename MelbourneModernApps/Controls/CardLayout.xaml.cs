using System;
using Xamarin.Forms;
using MelbourneModernApps.Controls;


namespace MelbourneModernApps.Controls
{
    public partial class CardLayout : Frame
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CardLayout), string.Empty, propertyChanged: TitleChanged);

        private static void TitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as CardLayout;
            control.TitleLabel.Text = (string)newValue;
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }



        public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(CardLayout), string.Empty, propertyChanged: ImageUrlChanged);

        private static void ImageUrlChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as CardLayout;
            control.CircleImage.Source = (string)newValue;
        }

        public string ImageUrl
        {
            get
            {
                return (string)GetValue(ImageUrlProperty);
            }

            set
            {
                SetValue(ImageUrlProperty, value);
                CircleImage.Source = value;
            }
        }

        public object Clicked { get; set; }

        

        public void OnItemSelected(object sender, EventArgs e)
        {
            if (Clicked is EventHandler clickedEvent)
            {
                clickedEvent.Invoke(sender, e);
            }
        }

        public CardLayout()
        {
            InitializeComponent();
        }
    }
}