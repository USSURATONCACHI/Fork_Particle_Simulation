using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UFO.Enums_Structs;

namespace UFO {
	/// <summary> ����������� �����. �������� ���������������� ������: �����������, �����������, �������������� � �.�. </summary>
	static class Converter {
		/// <summary> ���������� ������ � ������� ���������� ������ ��� �����-���� ��������������. <br/>
		/// <b>Bounds:</b> <inheritdoc cref="Screen.Bounds"/> </summary>
		/// <returns> ���������� ������ �������� ���������� ������. </returns>
		public static Size ScreenBounds_Size() { return Screen.PrimaryScreen.Bounds.Size; }
		/// <summary> ���������� ������������� � ������� ���������� ������ ��� �����-���� ��������������. <br/>
		/// <b>Bounds:</b> <inheritdoc cref="Screen.Bounds"/> </summary>
		/// <returns> ���������� ������������� �������� ���������� ������. </returns>
		public static Rectangle Screen_Bounds() { return Screen.PrimaryScreen.Bounds; }
		/// <summary> ���������� ������ � ������� ���������� ������ ��� �����-���� ��������������. <br/>
		///		<b>WorkingArea:</b> <inheritdoc cref="Screen.WorkingArea"/> </summary>
		/// <returns> ���������� ������� ���������� ������. </returns>
		public static Size ScreenWorkingArea_Size() { return Screen.PrimaryScreen.WorkingArea.Size;	}
		/// <summary> ���������� ������������� � ������� ���������� ������ ��� �����-���� ��������������. <br/>
		///		<b>WorkingArea:</b> <inheritdoc cref="Screen.WorkingArea"/> </summary>
		/// <returns> ���������� ������� ���������� ������. </returns>
		public static Rectangle Screen_WorkingArea() { return Screen.PrimaryScreen.WorkingArea; }
		/// <summary>
		/// <b>C</b>urrent <b>S</b>creen <b>R</b>esolution - ������� ���������� ������. <br/>
		/// ������� ��������������� �������� <b> NUM </b> ���������� � ���������� ������ 1920�1080 � ������ ���������� ������. <br/>
		/// ������� ���� ������������ ����� ������� ��������. �������: <b>NUM / 1080.0 * Screen...Height;</b>
		/// </summary>
		/// <returns> ���������� ��������������� <b> NUM </b> � ������� ���������� ������. </returns>
		public static int ToCSR(int NUM) { return (int)(NUM / 1080.0 * Screen.PrimaryScreen.Bounds.Size.Height); }
		/// <summary> <inheritdoc cref="ToCSR"/> </summary> <returns> <inheritdoc cref="ToCSR"/> </returns>
		public static float ToCSR(float NUM) { return (float)(NUM / 1080.0 * Screen.PrimaryScreen.Bounds.Size.Height);	}
		/// <summary> <inheritdoc cref="ToCSR"/> </summary> <returns> <inheritdoc cref="ToCSR"/> </returns>
		public static double ToCSR(double NUM) { return (double)(NUM / 1080.0 * Screen.PrimaryScreen.Bounds.Size.Height); }
		/// <summary> ����� ��������������� ���������� �������� <b>per</b> � ���������� �������� � �������� �������� � ������ �������� ���������� ������. <br/> ������: per = 50% - ������� ������ �������� ������; per = 100% - ������� ������ ���� ������ ������. </summary>		
		/// <value>	<b><paramref name="per"/>:</b> ������� ����� ���� <b>double</b> � ���������, � ��������� [0..100]. <br/> </value>
		/// <returns> ���������� ��������������� �������� � �������� �������� ������������ ��� <b>������</b> Width. </returns>
		public static int PercentToPixelWidth(double per) { return (int)(per / 100 * Screen.PrimaryScreen.Bounds.Size.Width); }
		/// <summary> <inheritdoc cref="PercentToPixelWidth"/> </summary>
		/// <value> <inheritdoc cref="PercentToPixelWidth"/> </value>
		/// <returns> ���������� ��������������� �������� � �������� �������� ������������ ��� <b>������</b> Height. </returns>
		public static int PercentToPixelHeight(double per) { return (int)(per / 100 * Screen.PrimaryScreen.Bounds.Size.Height); }
		/// <summary> ����� ��������������� ����������� �������� <b>coefficient</b> � ���������� �������� � �������� �������� � ������ �������� ���������� ������. <br/> ������: coefficient = 0.5 - ������� ������ �������� ������; coefficient = 1.0 - ������� ������ ���� ������ ������. </summary>
		/// <value>	<b><paramref name="coefficient"/>:</b> ������� ����� ���� <b>double</b> ���������� ����������� ��������, � ��������� [0..1]. <br/> </value>
		/// <returns> <inheritdoc cref="PercentToPixelWidth"/> </returns>
		public static int CoefficientToPixelWidth(double coefficient) { return (int)(coefficient * Screen.PrimaryScreen.Bounds.Size.Width); }
		/// <summary> <inheritdoc cref="CoefficientToPixelWidth"/> </summary>
		/// <value> <inheritdoc cref="CoefficientToPixelWidth"/> </value>
		/// <returns> <inheritdoc cref="PercentToPixelHeight"/> </returns>
		public static int CoefficientToPixelHeight(double coefficient) { return (int)(coefficient * Screen.PrimaryScreen.Bounds.Size.Height); }

		/// <summary> 
		///		������� ��������������� ���������� ����� � ������� (� ������ 86'400 ������ = [0..86'399]). <br/>
		///		��������� - ��� ����. �������� ���� � ��������� ����� 48.��� - ��� ����� 48 �����, 2 ������. <br/>
		///		�������� - ��� �������� �� ����. ������� 0.1428 = 60/100 * 14,28% = 8,568 = 8 ����� + 56,8% ����� = 60/100 * 56,8 = 34 ������ + 0,8% �������.
		/// </summary>
		/// <returns> ���������� ����� � ��������. <br/>
		///		���� �������� <b> Double </b> �������� 24.��� ����, �� ������� ����� ����� ����������� 86'399.
		/// </returns>
		public static int ToTimeSecond(double Double) { return (int)(Double * 3600); }

		/// <summary> 
		///		������� ��������������� ���������� ����� � ����������� (� ������ 86'400'000 ����������� = [0..86'399'999]). <br/>
		///		��������� - ��� ����. �������� ���� � ��������� ����� 48.��� - ��� ����� 48 �����, 2 ������. <br/>
		///		�������� - ��� �������� �� ����. ������� 0.1428 = 60/100 * 14,28% = 8,568 = 8 ����� + 56,8% ����� = 60/100 * 56,8 = 34 ������ + 0,8% ������� = 1000/100 * 8 = 80 �������.
		/// </summary>
		/// <returns> ���������� ����� � ������������. <br/>
		///		���� �������� <b> Double </b> �������� 24.��� ����, �� ������� ����� ����� ����������� 86'399'999.
		/// </returns>
		public static int ToTimeMilliSecond(double Double) { return (int)(Double * 3600000); }

		/// <summary> ������� ��������������� ���������� ������� � ������� (� ������ 86'400 ������ = [0..86'399]). </summary>
		/// <remarks> <b> hour: </b> ����. <br/> <b> min: </b> ������. <br/> <b> sec: </b> �������. <br/> </remarks>
		/// <returns> ���������� ����� � ��������. <br/>
		///		���� �������� <b> hour </b> �������� 24 ����, �� ������� ����� ����� ����������� 86'399.
		/// </returns>
		public static uint ToTimeSecond(uint hour, uint min, uint sec) {
			return hour * 3600 + min * 60 + sec;
		}

		/// <summary> ������� ��������������� ���������� ������� � ������������ (� ������ 86'400'000 ����������� = [0..86'399'999]). </summary>
		/// <remarks> <b> hour: </b> ����. <br/> <b> min: </b> ������. <br/> <b> sec: </b> �������. <br/> <b> msec: </b> ������������. <br/> </remarks>
		/// <returns> ���������� ����� � �������������. <br/>
		///		���� �������� <b> hour </b> �������� 24 ����, �� ������� ����� ����� ����������� 86'399'999.
		/// </returns>
		public static uint ToTimeMilliSecond(uint hour, uint min, uint sec, uint msec) {
			return hour * 3600000 + min * 60000 + sec * 1000 + msec;
		}

		/// <summary> ������� ��������������� ����� ["��:��:��"] � �������. </summary>
		/// <remarks> <b> time: </b> ������ ������� <b> string </b> ������� ["��:��:��"]. <br/> </remarks>
		/// <returns> ���������� ����� � �������������. <br/>
		///		���� �������� <b> time </b> �������� 24 ����, �� ������� ����� ����� ����������� 86'399'999.
		/// </returns>
		public static int ToTimeSecond(string time) {
			int x = 0, hour = 0, min = 0, sec = 0; string tmp = ""; time += ":";
            for (int i = 0; i < time.Length; i++) if (time[i] != ':') tmp += time[i]; else {
				try { 
					if (x == 0) hour = Convert.ToInt32(tmp);
					if (x == 1) min = Convert.ToInt32(tmp);
					if (x == 2) sec = Convert.ToInt32(tmp);
				}
				catch (FormatException) {
					MessageBox.Show("������. class Convert;\n������ time = '" + time + "' ����� �� ������ ������.\n" +
						"���������� ������ ��� ���������: '��:��:��'. ������: time = '12:36:28'.\n return 0;"
					);
					return 0;
                }
				x++; tmp = "";
            }
			return hour * 3600 + min * 60 + sec;
		}

		/// <summary> ������� ��������������� ������� ������� <b>int</b> � ������ ["��:��:��"] (� ������ 86'400 ������ = [0..86'399]). </summary>
		/// <remarks> <b> second: </b> ����� � ��������. <br/> <b> h: </b> ��������� ����������� "�" - ���� �� ��������� �����. <br/> <b> m: </b> ��������� ����������� "�" - ������ �� ��������� �����. <br/> <b> s: </b> ��������� ����������� "�" - ������� �� ��������� �����. <br/> </remarks>
		/// <returns> ���������� ����� ��� ������ <b>["��:��:��"]</b>. � ������������� �� ��������� �����, <br/>
		///		������: <b>03�:12�:47�</b>. ���� ����������� �� ���������, ������ ����� ����� ���: <b>03:12:47</b> <br/>
		///		���� �������� <b>second</b> �������� <b>86'399</b>, �� ������� ����� ����� ����������� <b>"23:59:59"</b>. <br/>
		///		���� �������� <b>second</b> ����� �������������, �� ������� �����: <b>"?:?:?"</b>
		/// </returns>
		public static string ToTimeString(int second, string h = "", string m = "", string s = "") { return SecondToTimeString(second, h, m, s);	}
		/// <summary> ������� ��������������� ������� ������� <b>long</b> � ������ ["��:��:��"] (� ������ 86'400 ������ = [0..86'399]). </summary>
		/// <remarks> <inheritdoc cref="ToTimeString"/> </remarks> <returns> <inheritdoc cref="ToTimeString"/> </returns>
		public static string ToTimeString(long second, string h = "", string m = "", string s = "") { return SecondToTimeString(second, h, m, s);	}
		private static string SecondToTimeString(long second, string h = "", string m = "", string s = "") {
			if (second < 0) return "?:?:?";	string time = "";
			long hour = second / 3600; if (hour < 10) time = "0";	time += hour + h + ":";
			long min = second / 60 % 60; if (min < 10) time += "0";	time += min + m + ":";
			long sec = second % 60; if (sec < 10) time += "0";		if (sec < 0) time += "?"; else time += sec + s;
			return time;
        }
		/// <summary> ������� ��������������� ������������ � ������ ["��:��:��:��"] (� ������ 86'400'000 ����������� = [0..86'399'999]). </summary>
		/// <remarks> <b> millisecond: </b> ����� � �������������. <br/> <b> h: </b> ��������� ����������� "�" - ���� �� ��������� �����. <br/> <b> m: </b> ��������� ����������� "�" - ������ �� ��������� �����. <br/> <b> s: </b> ��������� ����������� "�" - ������� �� ��������� �����. <br/> <b> ms: </b> ��������� ����������� "��" - ����������� �� ��������� �����. <br/> </remarks>
		/// <returns> ���������� ����� ��� ������ ["��:��:��:��"]. <br/>
		///		���� �������� <b> millisecond </b> �������� 86'399'999, �� ������� ����� ����� ����������� "23:59:59:999". <br/>
		///		���� �������� <b>millisecond</b> ����� �������������, �� ������� �����: <b>"??:??:??:???"</b>
		/// </returns>
		public static string msToTimeString(int millisecond, string h = "", string m = "", string s = "", string ms = "") {
			if (millisecond < 0) return "??:??:??:???";	string time = "";
			int hour = millisecond / 3600000; if (hour < 10) time = "0";
			time += hour + h + ":";
			int min = millisecond / 60000 % 60000; if (min < 10) time += "0";
			time += min + m + ":";
			int sec = millisecond / 1000 % 60;	if (sec < 10) time += "0";
			time += sec + s + ":";
			int msec = millisecond % 1000;	if (msec < 10) time += "00"; else if (msec < 100) time += "0";
			time += msec + ms;
			return time;
		}

		/// <summary> ����� ����������� ����� <b>value</b> �������� ������� ����� ���������. ������: 1'000'000'000. <br/> ����� �������� � ������ � �������� ����������. </summary>
		/// <value>	
		///		<b><paramref name="value"/>:</b> ����� � ������� string. <br/>
		///		<b><paramref name="tab"/>:</b> �����������. �� ��������� ������ ����������� ���������. <br/>
		/// </value>
		/// <returns> ���������� ����������������� ����� � ���� ������ � ��������� ����� ���������: xx'xxx'xxx'xxx. </returns>
		public static string toTABString(string value, string tab = " ") {
			if (value.Length < 4) return value; else { List<char> CHR = new List<char>(); int counter = 0;
				for (int i = value.Length - 1; i >= 0; i--) { counter++;
					if (value[i] == '.' || value[i] == ',') { CHR.Add('.'); counter = 0; }
					else if (counter == 4) { CHR.Add(tab[0]); counter = 0; i++;	} 
					else CHR.Add(value[i]);
				} CHR.Reverse(); return new string(CHR.ToArray());
			}
		}

		/// <summary> �������� ���� ������������� ���������� ������. <br/> ����� ���������: ������ �� ������� ������ ������ � �������� ��������. <br/>	��� ���������� ������ �� ��������, ����� �������� ������ ������ ��� ������� �������. </summary>
		/// <value>	<b><paramref name="min"/>:</b> ����������� ������ ������. <br/>	<b><paramref name="max"/>:</b> ������������ ������ ������. </value>
		/// <returns> ���������� <b>true</b> ���� ������ ������ �������� ���������� �������� � ���������. <br/> ���������� <b>false</b> ���� ��� ��������� ��������� <b>default</b> ��� �������� ��� ���������. </returns>
		public static bool SCREEN(int min = -1, int max = -1) {
			if (min <= -1 && max <= -1) return false;
			else {
				if (max <= -1) { if (Screen.PrimaryScreen.Bounds.Size.Height < min) return true; } 
					else if (min <= -1) { if (Screen.PrimaryScreen.Bounds.Size.Height >= max) return true; }
						else if (Screen.PrimaryScreen.Bounds.Size.Height < max &&
								 Screen.PrimaryScreen.Bounds.Size.Height >= min) return true;
						return false;
			}
		}

		/// <summary> ����� ����������� ���������������� ����� � ���������� ����� <b>RGB</b>. <br/> ����� ��������� ������ � ������� ������� ���������������� �����. </summary>
		/// <returns> ���������� ���������� ����� <b>RGB</b> � ��������� [0..255]. </returns>
		public static byte ToRGB<T> (T cl) {
			byte result = 0; ulong unsigned_cl = 0; long signed_cl = -1;
			if (cl is ulong) unsigned_cl = (ulong)(object)cl;	if (cl is long) signed_cl = (long)(object)cl;
			if (cl is uint) unsigned_cl = (uint)(object)cl;		if (cl is int) signed_cl = (int)(object)cl;
			if (cl is ushort) unsigned_cl = (ushort)(object)cl;	if (cl is short) signed_cl = (short)(object)cl;
			if (cl is sbyte) unsigned_cl = (byte)(object)cl;	if (cl is byte) signed_cl = (byte)(object)cl;
			if (cl is ulong || cl is uint || cl is ushort || cl is sbyte)
				if (unsigned_cl <= 0) result = 0; else if (unsigned_cl >= 255) result = 255; else result = (byte)unsigned_cl;
			if (typeof(T) == typeof(long) || typeof(T) == typeof(int) || typeof(T) == typeof(short) || typeof(T) == typeof(byte)) 
				if (signed_cl <= 0) result = 0; else if (signed_cl >= 255) result = 255; else result = (byte)signed_cl;
			return result;
		}

		/// <summary> ����� ��������� ������/������� ������� ���������� ����� � ������������ � ������ �����������. </summary>
		/// <remarks> ��������� �������� <b>cl</b> �������� ���������� � ���� ���������� ����. </remarks>
		public static void toRGB(ref int cl) { if (cl < 0) cl = byte.MinValue; else if (cl > 255) cl = byte.MaxValue; }
		/// <summary> ����� ��������� ������/������� ������� ������ ���������� ����� � ������������ � ������ �����������. </summary>
		/// <remarks> ��������� �������� �������� ����������� � ���� ���������� ����. </remarks>
		public static void toRGB(ref int R, ref int G, ref int B, ref int A) {
			if (R < 0) R = 0; else if (R > 255) R = 255;	if (G < 0) G = 0; else if (G > 255) G = 255;
			if (B < 0) B = 0; else if (B > 255) B = 255;	if (A < 0) A = 0; else if (A > 255) A = 255;
		}
		/// <summary> ����� ��������� ������/������� ������� ������ ���������� ����� � ������������ � ������ �����������. </summary>
		/// <remarks> ��������� �������� �������� ����������� � ���� ���������� ����. </remarks>
		public static void toRGB (ref int R, ref int G, ref int B) {
			if (R < 0) R = 0; else if (R > 255) R = 255;	if (G < 0) G = 0; else if (G > 255) G = 255;
			if (B < 0) B = 0; else if (B > 255) B = 255;
		}
		/// <summary> ����� ��������� ����� ������������� �������� �� ���� ����� � ������ <b>Alpha</b>. <br/> ��� ���������� ����� ���� ��� ���������� �����, ��� � ������ ��������, ��� ����� ������������. <br/> �������� <paramref name="Alpha"/> ����������� �� ���������� ��������, � ������ ������ �� ���������, ���������� � ������ ��� ������� �������. </summary>
		/// <value>
		///		<b><paramref name="First"/>:</b> ������ ��������, ��� �������� ����������� ������������ <b>Alpha</b>. <br/> <b><paramref name="Second"/>:</b> ������ ��������, �� �������� ���������� ������������. <br/>
		///		<b><paramref name="Alpha"/>:</b> �������� ������������ ��� ������������ ��� �������� <paramref name="First"/>, ��������: <b>[0..1],</b> <br/> ��� 0 - ��������� ����������, 1 - 100% �� ����������, 0.5 - �������������� (���� ��������� �������� ������������ �����). <br/>
		/// </value>
		/// <returns> ���������� ����� ������������� �������� � ������ <b>Alpha</b>. </returns>
		public static double Interpolate(double First, double Second, double Alpha) {
			Alpha = Alpha < 0 ? 0 : Alpha > 1 ? 1 : Alpha;//[0..1]
			//return First * (Alpha / 255) + Second * (1 - (Alpha / 255));
			return First * Alpha + Second * (1.0 - Alpha);
		}

		/// <summary> ����� ��������� ����� <b>NUM</b> �� ������������ ��������� <b>[MIN..MAX],</b> <br/> � ������ ������ �� ���������, ����� ���������� � ������� ��� ������ �������. </summary>
		/// <value>
		///		<b><paramref name="MIN"/>/<paramref name="MAX"/>:</b> ������/������� ������� ���������. <br/>
		///		<b><paramref name="NUM"/>:</b> ����������� �����. <br/>
		/// </value>
		/// <returns> ���������� ����� <b>NUM</b> (��������� ��� �������������). </returns>
		public static float NumToMinMax(float MIN, float MAX, float NUM) {
            return System.Math.Min(MAX, System.Math.Max(MIN, NUM));//�������� NUM � ��������� [MIN..MAX]
		}

		/// <summary> ����� ������������ �������� ������ <b>RGB</b> (Color) � �������� ������ <b>HSV.</b> </summary>
		/// <returns> ���������� ��������������� �������� ������ <b>HSV.</b> </returns>
		public static HSV ColorToHSV(this Color color) {
			int max = System.Math.Max(color.R, System.Math.Max(color.G, color.B));
			int min = System.Math.Min(color.R, System.Math.Min(color.G, color.B));
			double hue = color.GetHue();
			double saturation = (max == 0) ? 0 : 1.0 - (1.0 * min / max);
			double value = max / 255.0;
			return new HSV(hue, saturation, value);
		}
		/// <summary> ����� ������������ �������� ������ <b>HSV</b> � �������� ������ <b>RGB</b> (Color). </summary>
		/// <returns> ���������� ��������������� �������� ������ <b>RGB</b> (Color). </returns>
		public static Color HSVToColor(this HSV hsv) {
			int hi = Convert.ToInt32(System.Math.Floor(hsv.Hue / 60)) % 6;
			double f = hsv.Hue / 60 - System.Math.Floor(hsv.Hue / 60);
			double value = hsv.Value * 255;
			int v = Convert.ToInt32(value);
			int p = Convert.ToInt32(value * (1 - hsv.Saturation));
			int q = Convert.ToInt32(value * (1 - f * hsv.Saturation));
			int t = Convert.ToInt32(value * (1 - (1 - f) * hsv.Saturation));
			return (hi == 0) ? Color.FromArgb(255, v, t, p) : (hi == 1) ? Color.FromArgb(255, q, v, p) :
				(hi == 2) ? Color.FromArgb(255, p, v, t) : (hi == 3) ? Color.FromArgb(255, p, q, v) :
					(hi == 4) ? Color.FromArgb(255, t, p, v) : Color.FromArgb(255, v, p, q);
		}

		/// <summary> ����� ������������ ����� ����� � ������� ������� ���������� � ��������� [0..3'999] = 4000. </summary>
		/// <remarks> ����� ���������� <b><paramref name="ArgumentException"/></b> ���� <b>num</b> ��� ��������� ���������� ��������. </remarks>
		/// <returns> ���������� ��������� ���������� ������ ����� <b>num</b> � ������� ������� ����������. </returns>
		public static string IntToRoman(int num) {
			if (num < 0 || num > 3999) throw new ArgumentException("������. �������� ������ ���� � ��������� [0..3'999].");
			if (num == 0) return "N";
			int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
			string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < 13; i++) { while (num >= values[i]) { num -= values[i]; result.Append(numerals[i]); }}
			return result.ToString();
		}

		/// <summary> ����� ������������ ������ <b>str</b> � ������������������ ������ � ��������� <b>ASCII</b>, <br/> ������ ASCII ��� ������� �������� <b>separator</b>. </summary>
		/// <returns> ���������� ���������� ������ <b>str</b> ��� ����� ������ <b>ASCII</b>. </returns>
		public static string ToASCII(string str, string separator) { 
			return string.Join(separator, Encoding.Default.GetBytes(str));
		}

		/// <summary> ����� �������� ������ ������� ����������� <b>originalImage</b> ������� ��� ������� �� <b>newColor</b>. <br/> ���������� ������� (100%) - �� ���������! </summary>
		/// <value>	<b><paramref name="originalImage"/>:</b> �����������, ������� ��������� ��������. <br/>
		/// <b><paramref name="newColor"/>:</b> ����, ������� ����� ���������� �� ������ ������� ����������� <b>originalImage</b>. <br/>
		/// </value>
		/// <returns> ���������� ��������� <b>Bitmap</b> ����������� ��������� ����������� <b>originalImage</b>. </returns>
		public static Bitmap ChangeImageColor(Bitmap originalImage, Color newColor)	{
			Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);//����� ����������� ������ �� �������
			Rectangle rect = new Rectangle(0, 0, originalImage.Width, originalImage.Height);
			BitmapData originalData = originalImage.LockBits(rect, ImageLockMode.ReadOnly, originalImage.PixelFormat);
			BitmapData newData = newImage.LockBits(rect, ImageLockMode.WriteOnly, newImage.PixelFormat);
			int bytesPerPixel = Image.GetPixelFormatSize(originalImage.PixelFormat) / 8;
			int byteCount = originalData.Stride * originalImage.Height;
			// ������� ������ ��� �������� ������ �����������
			byte[] originalBuffer = new byte[byteCount];
			byte[] newBuffer = new byte[byteCount];
			Marshal.Copy(originalData.Scan0, originalBuffer, 0, byteCount);
			// ������������ ������ ������� �����������
			Parallel.For(0, rect.Height, y => {
				for (int x = 0; x < rect.Width; x++) {
					int index = y * originalData.Stride + x * bytesPerPixel;
					if (originalBuffer[index + 3] == 0) continue;//���������� ������� �� �������
					// ��������� ���� �������
					byte blue = originalBuffer[index];
					byte green = originalBuffer[index + 1];
					byte red = originalBuffer[index + 2];
					byte alpha = originalBuffer[index + 3];
					// ��������� ����� ���� �������
					byte newBlue = (byte)((blue + newColor.B) / 2);
					byte newGreen = (byte)((green + newColor.G) / 2);
					byte newRed = (byte)((red + newColor.R) / 2);
					byte newAlpha = (byte)((alpha + newColor.A) / 2);
					// ���������� ����� ���� � ����� ������ �����������
					newBuffer[index] = newBlue;
					newBuffer[index + 1] = newGreen;
					newBuffer[index + 2] = newRed;
					newBuffer[index + 3] = newAlpha;
				}
			});
			Marshal.Copy(newBuffer, 0, newData.Scan0, byteCount);//�������� ������ �� ������ ������ ����������� ������� � �����������
			originalImage.UnlockBits(originalData); newImage.UnlockBits(newData);//������������ �����������
			return newImage;
		}
	}
}