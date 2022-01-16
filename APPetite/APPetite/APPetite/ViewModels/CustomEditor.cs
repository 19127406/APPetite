using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APPetite.ViewModels
{
    public class CustomEditor : Editor
    {
        public static BindableProperty IsExpandableProperty
        = BindableProperty.Create(nameof(IsExpandable), typeof(bool), typeof(CustomEditor), false);

        public bool IsExpandable
        {
            get { return (bool)GetValue(IsExpandableProperty); }
            set { SetValue(IsExpandableProperty, value); }
        }

        public CustomEditor()
        {
            TextChanged += OnTextChanged;
        }

        ~CustomEditor()
        {
            TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsExpandable) InvalidateMeasure();
        }
    }
}
