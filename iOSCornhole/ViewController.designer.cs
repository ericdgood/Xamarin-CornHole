// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSCornhole
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnNewGame { get; set; }

		[Outlet]
		UIKit.UIButton btnNewInning { get; set; }

		[Outlet]
		UIKit.UIButton btnTeam1OnePoint { get; set; }

		[Outlet]
		UIKit.UIButton btnTeam1ThreePoints { get; set; }

		[Outlet]
		UIKit.UIButton btnTeam2OnePoint { get; set; }

		[Outlet]
		UIKit.UIButton btnTeam2ThreePoints { get; set; }

		[Outlet]
		UIKit.UILabel tvInningNumber { get; set; }

		[Outlet]
		UIKit.UILabel tvTeam1GameScore { get; set; }

		[Outlet]
		UIKit.UILabel tvTeam1InningScore { get; set; }

		[Outlet]
		UIKit.UILabel tvTeam1Name { get; set; }

		[Outlet]
		UIKit.UILabel tvTeam2GameScore { get; set; }

		[Outlet]
		UIKit.UILabel tvTeam2InningScore { get; set; }

		[Outlet]
		UIKit.UILabel tvTeam2Name { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnTeam2ThreePoints != null) {
				btnTeam2ThreePoints.Dispose ();
				btnTeam2ThreePoints = null;
			}

			if (btnTeam2OnePoint != null) {
				btnTeam2OnePoint.Dispose ();
				btnTeam2OnePoint = null;
			}

			if (tvTeam2Name != null) {
				tvTeam2Name.Dispose ();
				tvTeam2Name = null;
			}

			if (tvTeam2InningScore != null) {
				tvTeam2InningScore.Dispose ();
				tvTeam2InningScore = null;
			}

			if (tvTeam2GameScore != null) {
				tvTeam2GameScore.Dispose ();
				tvTeam2GameScore = null;
			}

			if (tvTeam1GameScore != null) {
				tvTeam1GameScore.Dispose ();
				tvTeam1GameScore = null;
			}

			if (tvTeam1InningScore != null) {
				tvTeam1InningScore.Dispose ();
				tvTeam1InningScore = null;
			}

			if (tvTeam1Name != null) {
				tvTeam1Name.Dispose ();
				tvTeam1Name = null;
			}

			if (btnTeam1ThreePoints != null) {
				btnTeam1ThreePoints.Dispose ();
				btnTeam1ThreePoints = null;
			}

			if (btnTeam1OnePoint != null) {
				btnTeam1OnePoint.Dispose ();
				btnTeam1OnePoint = null;
			}

			if (tvInningNumber != null) {
				tvInningNumber.Dispose ();
				tvInningNumber = null;
			}

			if (btnNewInning != null) {
				btnNewInning.Dispose ();
				btnNewInning = null;
			}

			if (btnNewGame != null) {
				btnNewGame.Dispose ();
				btnNewGame = null;
			}
		}
	}
}
