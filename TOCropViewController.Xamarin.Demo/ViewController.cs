using Foundation;
using System;
using UIKit;

namespace TimOliver.TOCropViewController.Xamarin.Demo
{
    public partial class ViewController : UIViewController, IUIImagePickerControllerDelegate
    {
        private ImageCroppingDelegate _croppingDelegate;

        public ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _croppingDelegate = new ImageCroppingDelegate();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            btnCamera.TouchUpInside += BtnCameraOnTouchUpInside;
            btnChoosePhoto.TouchUpInside += BtnChoosePhotoOnTouchUpInside;
            _croppingDelegate.OnFinishCropping = OnFinishCropping;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            btnCamera.TouchUpInside -= BtnCameraOnTouchUpInside;
            btnChoosePhoto.TouchUpInside -= BtnChoosePhotoOnTouchUpInside;
        }

        private void ShowAlert(string title, string message, string btnOk = "Ok")
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

                alertController.AddAction(UIAlertAction.Create(btnOk, UIAlertActionStyle.Default, null));

                PresentViewController(alertController, true, null);
            });
        }

        #region IUIImagePickerControllerDelegate
        [Export("imagePickerController:didFinishPickingImage:editingInfo:")]
        private void FinishedPickingImage(UIImagePickerController picker, UIImage image, NSDictionary dic)
        {
            picker.DismissViewController(true, () =>
            {
                var cropViewController =
                    new TOCropViewController(TOCropViewCroppingStyle.Default, image)
                    {
                        AspectRatioLockEnabled = true,
                        AspectRatioPickerButtonHidden = true,
                        AspectRatioPreset = TOCropViewControllerAspectRatioPreset.Square,
                        Delegate = _croppingDelegate,
                        ResetAspectRatioEnabled = false
                    };

                PresentViewController(cropViewController, true, null);
            });
        }

        [Export("imagePickerController:didFinishPickingMediaWithInfo:")]
        private void FinishedPickingMedia(UIImagePickerController picker, NSDictionary dic)
        {
            var img = dic.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;

            picker.DismissViewController(true, () =>
            {
                var cropViewController =
                    new TOCropViewController(TOCropViewCroppingStyle.Default, img)
                    {
                        AspectRatioLockEnabled = true,
                        AspectRatioPickerButtonHidden = true,
                        AspectRatioPreset = TOCropViewControllerAspectRatioPreset.Square,
                        Delegate = _croppingDelegate,
                        ResetAspectRatioEnabled = false
                    };

                PresentViewController(cropViewController, true, null);
            });
        }

        [Export("imagePickerControllerDidCancel:")]
        private void Canceled(UIImagePickerController picker)
        {
            picker.DismissViewController(true, null);
        }
        #endregion

        #region Events
        private void BtnCameraOnTouchUpInside(object sender, EventArgs e)
        {
            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                var picker = new UIImagePickerController
                {
                    SourceType = UIImagePickerControllerSourceType.Camera,
                    CameraCaptureMode = UIImagePickerControllerCameraCaptureMode.Photo,
                    WeakDelegate = this
                };

                PresentViewController(picker,true,null);
            }
            else
            {
                ShowAlert("Error", "Failed to access camera");
            }
        }

        private void BtnChoosePhotoOnTouchUpInside(object sender, EventArgs e)
        {
            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary))
            {
                var picker = new UIImagePickerController
                {
                    SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                    WeakDelegate = this
                };

                PresentViewController(picker,true,null);
            }
            else
            {
                ShowAlert("Error", "Failed to access photo library");
            }
        }

        private void OnFinishCropping(object sender, UIImage e)
        {
            ivMain.Image = e;
        }
        #endregion
    }
}