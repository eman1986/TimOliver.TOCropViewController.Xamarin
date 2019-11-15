using System;
using CoreGraphics;
using TimOliver.TOCropViewController.Xamarin;

namespace TOCropViewController_Xamarin_Demo
{
    public class ImageCroppingDelegate : TOCropViewControllerDelegate
    {
        public override void DidCropImageToRect(TOCropViewController cropViewController, CGRect cropRect, nint angle)
        {
            cropViewController.PresentingViewController.DismissViewController(true, null);
        }
    }
}
