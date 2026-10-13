using System;
using System.Windows.Forms;

namespace StudentManagementApp
{
    internal static class UiFeedback
    {
        public static void Run(IWin32Window owner, Action operation)
        {
            try { operation(); }
            catch (Exception ex)
            {
                MessageBox.Show(owner, ex.Message, "Student Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool TryGetSelectedId(DataGridView grid, string columnName, out int id)
        {
            id = 0;
            if (grid.SelectedRows.Count == 0) return false;
            var value = grid.SelectedRows[0].Cells[columnName].Value;
            if (value == null || value == DBNull.Value) return false;
            id = Convert.ToInt32(value);
            return true;
        }
    }
}