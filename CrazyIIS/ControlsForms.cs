using System.Windows.Forms;

namespace CrazyIIS
{
    /// <summary>
    ///双缓冲DataGridView，解决闪烁
    /// </summary>
    class DoubleBufferListView : DataGridView
    {
        public DoubleBufferListView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

        }
    }

}
