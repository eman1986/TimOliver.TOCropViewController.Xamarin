using System;
using CoreGraphics;
using UIKit;

namespace TimOliver.TOCropViewController.Xamarin.Demo
{
    public class ImageCroppingDelegate : TOCropViewControllerDelegate
    {
        public EventHandler<UIImage> OnFinishCropping;

        public override void DidCropImageToRect(TOCropViewController cropViewController, CGRect cropRect, nint angle)
        {
            cropViewController.PresentingViewController.DismissViewController(true, () =>
            {
                OnFinishCropping?.Invoke(this, cropViewController.Image);
            });
        }
    }
}