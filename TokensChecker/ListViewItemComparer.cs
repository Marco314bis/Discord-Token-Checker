using System;
using System.Collections;
using System.Windows.Forms;

/// <summary>
/// This class is an implementation of the 'IComparer' interface.
/// </summary>
public class ListViewColumnSorter : IComparer
{
    /// <summary>
    /// Specifies the column to be sorted
    /// </summary>
    private int ColumnToSort;

    /// <summary>
    /// Specifies the order in which to sort (i.e. 'Ascending').
    /// </summary>
    private SortOrder OrderOfSort;

    /// <summary>
    /// Case insensitive comparer object
    /// </summary>
    private CaseInsensitiveComparer ObjectCompare;

    /// <summary>
    /// Class constructor. Initializes various elements
    /// </summary>
    public ListViewColumnSorter()
    {
        ColumnToSort = 0;
        OrderOfSort = SortOrder.None;
        ObjectCompare = new CaseInsensitiveComparer();
    }

    public int Compare(object x, object y)
    {
        try
        {
            int returnVal;
            int result;
            DateTime dt1;
            DateTime dt2;
            string formats = "MMM dd yyyy - HH:mm:ss";
            if (int.TryParse(((ListViewItem)x).SubItems[ColumnToSort].Text.Replace("+", ""), out result) &&
                int.TryParse(((ListViewItem)y).SubItems[ColumnToSort].Text.Replace("+", ""), out result))
            {
                returnVal = Convert.ToInt32(((ListViewItem)x).SubItems[ColumnToSort].Text).CompareTo(Convert.ToInt32(((ListViewItem)y).SubItems[ColumnToSort].Text));
            }
            else if (DateTime.TryParseExact(((ListViewItem)x).SubItems[ColumnToSort].Text, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt1) &&
                DateTime.TryParseExact(((ListViewItem)y).SubItems[ColumnToSort].Text, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt2))
            {
                returnVal = DateTime.Compare(dt1, dt2);
            }
            else
            {
                returnVal = string.Compare(((ListViewItem)x).SubItems[ColumnToSort].Text, ((ListViewItem)y).SubItems[ColumnToSort].Text);
            }

            if (OrderOfSort == SortOrder.Descending)
            {
                returnVal *= -1;
            }

            return returnVal;
        }
        catch (Exception)
        {
            return 1;
        }
    }

    public int SortColumn
    {
        set
        {
            ColumnToSort = value;
        }
        get
        {
            return ColumnToSort;
        }
    }

    public SortOrder Order
    {
        set
        {
            OrderOfSort = value;
        }
        get
        {
            return OrderOfSort;
        }
    }

}