using System;
using CoreGraphics;
using UIKit;

namespace TimOliver.TOCropViewController.Xamarin.Demo
{
    public class ImageCroppingDelegate : TOCropViewControllerDelegate
    {
        public EventHandler<UIImage> OnFinishCropping;

        public override void DidCropToImage(TOCropViewController cropViewController, UIImage image, CGRect cropRect, nint angle)
        {
            cropViewController.DismissViewController(true, () =>
            {
                OnFinishCropping?.Invoke(this, image);
            });
        }
    }
}