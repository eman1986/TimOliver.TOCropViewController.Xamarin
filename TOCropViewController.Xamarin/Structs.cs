using System;
using ObjCRuntime;

namespace TimOliver.TOCropViewController.Xamarin
{
	[Native]
	public enum TOCropViewCroppingStyle : long
	{
		Default,
		Circular
	}

	[Native]
	public enum TOCropViewControllerAspectRatioPreset : long
	{
		Original,
		Square,
		TOCropViewControllerAspectRatioPreset3x2,
		TOCropViewControllerAspectRatioPreset5x3,
		TOCropViewControllerAspectRatioPreset4x3,
		TOCropViewControllerAspectRatioPreset5x4,
		TOCropViewControllerAspectRatioPreset7x5,
		TOCropViewControllerAspectRatioPreset16x9,
		Custom
	}

	[Native]
	public enum TOCropViewControllerToolbarPosition : long
	{
		Bottom,
		Top
	}
}
