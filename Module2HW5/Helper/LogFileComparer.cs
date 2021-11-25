using System.Collections;
using System.IO;

namespace Module2HW5.Helper
{
    public class LogFileComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var itemX = x as string;
            var itemY = y as string;
            var dateTimeX = File.GetCreationTimeUtc(itemX);
            var dateTimeY = File.GetCreationTimeUtc(itemY);
            return dateTimeX.CompareTo(dateTimeY);
        }
    }
}
