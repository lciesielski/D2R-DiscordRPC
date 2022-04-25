using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace D2RRPCWinForms
{
	public class LauncherHelper
	{
		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("User32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("User32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("User32.dll")]
		static extern bool GetWindowRect(IntPtr hwnd, out System.Drawing.Rectangle lpRect);

		[DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("User32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

		[DllImport("User32.dll")]
		static extern bool ClientToScreen(IntPtr hWnd, ref System.Drawing.Point lpPoint);

		[DllImport("User32.dll")]
		internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

		[DllImport("User32.dll")]
		private static extern bool ShowWindow(IntPtr handle, int nCmdShow);

		[DllImport("User32.dll")]
		private static extern bool IsIconic(IntPtr handle);

		internal struct INPUT
		{
			public uint Type;
			public MOUSEKEYBDHARDWAREINPUT Data;
		}

		[StructLayout(LayoutKind.Explicit)]
		internal struct MOUSEKEYBDHARDWAREINPUT
		{
			[FieldOffset(0)]
			public MOUSEINPUT Mouse;
		}

#pragma warning disable 0649
		internal struct MOUSEINPUT
		{
			public int X;
			public int Y;
			public uint MouseData;
			public uint Flags;
			public uint Time;
			public IntPtr ExtraInfo;
		}
#pragma warning restore 0649

		public const int MOUSEEVENTF_LEFTDOWN = 0x02;
		public const int MOUSEEVENTF_LEFTUP = 0x04;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		public const int MOUSEEVENTF_RIGHTUP = 0x10;

		public D2RRPCMainForm mainForm;

		private readonly int divider = Screen.PrimaryScreen.Bounds.Width switch
		{
			1024 => 2,
			1280 => 2,
			1360 => 2,
			1366 => 2,
			1920 => 2,
			2048 => 1,
			2560 => 1,
			3440 => 1,
			3840 => 1,
			4096 => 1,
			_ => 2,
		};

		public LauncherHelper(D2RRPCMainForm mainForm)
		{
			this.mainForm = mainForm;
		}

		public void HandleDiabloProcess()
		{
			Process diabloProcess = null;
			Process battleNetProcess = null;
			Process[] currentDiabloProcess = Process.GetProcessesByName(mainForm.settingsHelper.DEFAULT_DIABLO_EXE_FILE_NAME);
			Process[] currentBattleNetProcess = Process.GetProcessesByName(mainForm.settingsHelper.DEFAULT_BATTLE_NET_EXE_FILE_NAME);

			if (currentDiabloProcess.Length > 0)
			{
				diabloProcess = currentDiabloProcess[0];
			}
			else if (currentBattleNetProcess.Length > 0)
			{
				battleNetProcess = currentBattleNetProcess[0];
			}

			if (diabloProcess == null && battleNetProcess == null)
			{
				battleNetProcess = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = mainForm.GetBattleNetExePath()
					}
				};
				battleNetProcess.Start();
				Thread.Sleep(8000);
			}

			if (diabloProcess != null)
			{
				StopClientOnDiabloExit(diabloProcess);
			}
			else
			{
				LaunchDiabloViaBattleNet();

				do
				{
					currentDiabloProcess = Process.GetProcessesByName(mainForm.settingsHelper.DEFAULT_DIABLO_EXE_FILE_NAME);
					if (currentDiabloProcess.Length > 0)
					{
						diabloProcess = currentDiabloProcess[0];
					}
					Thread.Sleep(100);
				} while (diabloProcess == null);

				StopClientOnDiabloExit(diabloProcess);
			}
		}

		private void StopClientOnDiabloExit(Process diabloProcess)
		{
			diabloProcess.EnableRaisingEvents = true;
			diabloProcess.Exited += (sender, e) =>
			{
				mainForm.presenceHelper.StopClient();
				Debug.WriteLine("Process exited with exit code " + diabloProcess.ExitCode.ToString());
			};
		}

		private void LaunchDiabloViaBattleNet()
		{
			if (!BattleNetWindowForeground()) return;
			Rectangle desktop = Screen.GetBounds(System.Drawing.Point.Empty);

			using Bitmap desktopScreenshoot = new Bitmap(desktop.Width, desktop.Height);
			using (Graphics graphics = Graphics.FromImage(desktopScreenshoot))
			{
				graphics.CopyFromScreen(new System.Drawing.Point(desktop.Left, desktop.Top), System.Drawing.Point.Empty, desktop.Size);
			}

			using MemoryStream memory = new MemoryStream();
			desktopScreenshoot.Save(memory, ImageFormat.Jpeg);
			memory.Position = 0;

			BitmapImage desktopImage = new BitmapImage();
			desktopImage.BeginInit();
			desktopImage.StreamSource = memory;
			desktopImage.CacheOption = BitmapCacheOption.OnLoad;
			desktopImage.EndInit();
			desktopImage.Freeze();

			string imagesPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

			ClickOnImage(desktopImage, new BitmapImage(new Uri(@$"{imagesPath}\Images\BNetGamesBtn.JPG")));
			ClickOnImage(desktopImage, new BitmapImage(new Uri(@$"{imagesPath}\Images\BNetD2RIcon.JPG")));
			ClickOnImage(desktopImage, new BitmapImage(new Uri(@$"{imagesPath}\Images\BNetPlayBtn.JPG")));
		}

		private void ClickOnImage(BitmapImage desktopImage, BitmapImage templateImage)
		{
			using Mat source = BitmapSourceConverter.ToMat(desktopImage);
			using Mat template = BitmapSourceConverter.ToMat(templateImage);
			Mat match = source.MatchTemplate(template, TemplateMatchModes.CCoeff);

			if (match != null)
			{
				match.MinMaxLoc(out _, out OpenCvSharp.Point maxLoc);
				Cursor.Position = new System.Drawing.Point(maxLoc.X + (int)(templateImage.Width / divider), maxLoc.Y + (int)(templateImage.Height) / divider);
				ClickOnPoint(Cursor.Position);
			}
		}

		private void ClickOnPoint(System.Drawing.Point clientPoint)
		{
			Cursor.Position = new System.Drawing.Point(clientPoint.X, clientPoint.Y);

			INPUT inputMouseDown = new INPUT
			{
				Type = 0
			};
			inputMouseDown.Data.Mouse.Flags = 0x0002;

			INPUT inputMouseUp = new INPUT
			{
				Type = 0
			};
			inputMouseUp.Data.Mouse.Flags = 0x0004;

			INPUT[] inputs = new INPUT[] { inputMouseDown, inputMouseUp };
			SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
		}

		private bool BattleNetWindowForeground()
		{
			const int SW_RESTORE = 0x09;

			IntPtr handle = FindWindow(null, mainForm.settingsHelper.DEFAULT_BATTLE_NET_EXE_FILE_NAME);

			if (handle == IntPtr.Zero)
			{
				return false;
			}

			if (IsIconic(handle))
			{
				ShowWindow(handle, SW_RESTORE);
			}
			else
			{
				SetForegroundWindow(handle);
			}

			Thread.Sleep(500);

			return true;
		}
	}
}
