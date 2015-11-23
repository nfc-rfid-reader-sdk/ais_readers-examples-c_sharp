using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DL_AIS_Readers
{
    public static class Helper
    {
        static readonly string str_RegexStart = "^";
        static readonly string str_RegexEnd = "$";
        static readonly string str_RegexOr = "|";
        static readonly string str_RegexHex = @"0x[0-9A-Fa-f]+";
        static readonly string str_RegexHexPair = @"^[0-9A-Fa-f]{2}$";
        static readonly string str_RegexBin = @"0b[01]+";
        static readonly string str_RegexOct = @"0[0-7]*";
        static readonly string str_RegexDecAll = @"((?!0)|[-+]|(?=0+\.))(\d*\.)?\d+(e\d+)?";
        static readonly string str_RegexNumericAll = str_RegexStart + "("
                                                    + str_RegexHex + str_RegexOr
                                                    + str_RegexBin + str_RegexOr
                                                    + str_RegexOct + str_RegexOr
                                                    + str_RegexDecAll + ")" + str_RegexEnd;
        static readonly string str_RegexNumericDigits = @"^\d+$";

        public static void SetAutoDropDownWidth(ComboBox combo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in combo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), combo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            combo.DropDownWidth = maxWidth;
        }

        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }

        public static void SetStatusLabel(ToolStripStatusLabel label, string text, Color color)
        {
            label.Text = text;
            label.ForeColor = color;
        }

        public static void SetStatusLabel(ToolStripStatusLabel label, string text)
        {
            label.Text = text;
            label.ForeColor = Color.FromName("ControlText");
        }

        public static void SetStatusOk(ToolStripStatusLabel label) 
        {
            SetStatusLabel(label, "Status Ok", Color.Green);
        }

        public static void SetStatusErr(ToolStripStatusLabel label)
        {
            SetStatusLabel(label, "Error", Color.Red);
        }

        public static void SetStatusInputWarning(ToolStripStatusLabel label)
        {
            SetStatusLabel(label, "Input Warning", Color.Purple);
        }

        public static void SetStatusWarning(ToolStripStatusLabel label)
        {
            SetStatusLabel(label, "Warning", Color.Purple);
        }

        public static void PadTextBoxLeft(ref TextBox tb, Int32 padding_spaces)
        {
            tb.Text = tb.Text.PadLeft(tb.Text.Length + padding_spaces);
        }

        public static bool IsStringNumericDigitsOnly(string s) 
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, str_RegexNumericDigits);
        }

        public static bool IsStringHexPair(string s)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, str_RegexHexPair);
        }

        public static TimeSpan getDaylightDeltaOnSpecificDateTime(TimeZoneInfo timeZoneInfo, DateTime dateTime)
        {
            TimeSpan delta = TimeSpan.Zero;

            if (timeZoneInfo.IsDaylightSavingTime(dateTime))
            {
                foreach (var adjustmentRule in timeZoneInfo.GetAdjustmentRules())
                {
                    if (adjustmentRule.DateStart <= dateTime && adjustmentRule.DateEnd >= dateTime)
                    {
                        delta = adjustmentRule.DaylightDelta;
                        break;
                    }
                }
            }

            return delta;
        }
        
        public static TimeSpan getDaylightDeltaForSpecificYear(TimeZoneInfo timeZoneInfo, Int32 year)
        {
            TimeSpan delta = TimeSpan.Zero;

            foreach (var adjustmentRule in timeZoneInfo.GetAdjustmentRules())
            {
                if ((adjustmentRule.DateStart.Year <= year) && (adjustmentRule.DateEnd.Year >= year))
                {
                    delta = adjustmentRule.DaylightDelta;
                    break;
                }
            }

            return delta;
        }
    }

    public class AlphanumComparatorFast : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string s1 = x as string;
            if (s1 == null)
            {
                return 0;
            }
            string s2 = y as string;
            if (s2 == null)
            {
                return 0;
            }

            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            while (marker1 < len1 && marker2 < len2)
            {
                char ch1 = s1[marker1];
                char ch2 = s2[marker2];

                // Some buffers we can build up characters in for each chunk.
                char[] space1 = new char[len1];
                int loc1 = 0;
                char[] space2 = new char[len2];
                int loc2 = 0;

                // Walk through all following characters that are digits or
                // characters in BOTH strings starting at the appropriate marker.
                // Collect char arrays.
                do
                {
                    space1[loc1++] = ch1;
                    marker1++;

                    if (marker1 < len1)
                    {
                        ch1 = s1[marker1];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                do
                {
                    space2[loc2++] = ch2;
                    marker2++;

                    if (marker2 < len2)
                    {
                        ch2 = s2[marker2];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                // If we have collected numbers, compare them numerically.
                // Otherwise, if we have strings, compare them alphabetically.
                string str1 = new string(space1);
                string str2 = new string(space2);

                int result;

                if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                {
                    int thisNumericChunk = int.Parse(str1);
                    int thatNumericChunk = int.Parse(str2);
                    result = thisNumericChunk.CompareTo(thatNumericChunk);
                }
                else
                {
                    result = str1.CompareTo(str2);
                }

                if (result != 0)
                {
                    return result;
                }
            }
            return len1 - len2;
        }
    }
}
