// Type: Sistema.ListViewItemComparer
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using System.Collections;
using System.Windows.Forms;

namespace Sistema
{
  public class ListViewItemComparer : IComparer
  {
    private int col;

    public ListViewItemComparer()
    {
      this.col = 0;
    }

    public ListViewItemComparer(int column)
    {
      this.col = column;
    }

    public int Compare(object x, object y)
    {
      try
      {
        return string.Compare(((ListViewItem) x).SubItems[this.col].Text, ((ListViewItem) y).SubItems[this.col].Text);
      }
      catch
      {
        return 0;
      }
    }
  }
}
