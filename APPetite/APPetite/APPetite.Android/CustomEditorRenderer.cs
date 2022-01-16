using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using APPetite.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinEditor.Droid;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace XamarinEditor.Droid
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}