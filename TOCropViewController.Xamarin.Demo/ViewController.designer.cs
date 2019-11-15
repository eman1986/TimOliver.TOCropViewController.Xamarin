// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TOCropViewController_Xamarin_Demo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCamera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnChoosePhoto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivMain { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCamera != null) {
                btnCamera.Dispose ();
                btnCamera = null;
            }

            if (btnChoosePhoto != null) {
                btnChoosePhoto.Dispose ();
                btnChoosePhoto = null;
            }

            if (ivMain != null) {
                ivMain.Dispose ();
                ivMain = null;
            }
        }
    }
}