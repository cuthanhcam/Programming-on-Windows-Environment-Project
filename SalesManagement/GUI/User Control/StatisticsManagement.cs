using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace GUI.User_Control
{
    public partial class StatisticsManagement : UserControl
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsManagement(StatisticsService statisticsService)
        {
            InitializeComponent();
            _statisticsService = statisticsService;
            InitializeRevenueTab();
            LoadProductCategories();
            InitializeSummaryReportsTab();

            btnRevenueFilter.Click += (s, e) => FilterRevenueData(dtpRevenueStartDate.Value, dtpRevenueEndDate.Value, cmbRevenueProductCategory.SelectedItem?.ToString());
            btnReloadRevenueStatistics.Click += (s, e) => ReloadRevenueStatistics();
        }

        #region tpRevenueStatistics
        private void LoadProductCategories()
        {
            try
            {
                // Lấy danh sách danh mục từ StatisticsService
                var categories = _statisticsService.GetProductCategories();

                // Thêm danh mục vào ComboBox
                cmbRevenueProductCategory.Items.Clear();
                cmbRevenueProductCategory.Items.Add("All"); // Thêm tùy chọn "All"
                cmbRevenueProductCategory.Items.AddRange(categories.ToArray());

                // Đặt mục mặc định là "All"
                cmbRevenueProductCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeRevenueTab()
        {
            lstRevenueDetails.Clear();
            lstRevenueDetails.Columns.Add("Order ID", 100);
            lstRevenueDetails.Columns.Add("Customer Name", 150);
            lstRevenueDetails.Columns.Add("Product Name", 150);
            lstRevenueDetails.Columns.Add("Quantity", 80);
            lstRevenueDetails.Columns.Add("Unit Price", 100);
            lstRevenueDetails.Columns.Add("Total Amount", 120);
            lstRevenueDetails.View = View.Details;

            chartRevenue.Series.Clear(); // Xóa tất cả series cũ
            chartRevenue.Series.Add("Revenue"); // Thêm series "Revenue"
            chartRevenue.ChartAreas.Add("ChartArea"); // Thêm ChartArea nếu chưa có    
       
        }

        private void FilterRevenueData(DateTime startDate, DateTime endDate, string category)
        {
            try
            {
                // Lấy dữ liệu từ StatisticsService
                var revenueData = _statisticsService.GetRevenueData(startDate, endDate, category);

                // Kiểm tra dữ liệu trả về
                if (revenueData == null || revenueData.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Hiển thị dữ liệu trong ListView
                lstRevenueDetails.Items.Clear();
                foreach (var item in revenueData)
                {
                    var listViewItem = new ListViewItem(item.OrderID.ToString());
                    listViewItem.SubItems.Add(item.CustomerName);
                    listViewItem.SubItems.Add(item.ProductName);
                    listViewItem.SubItems.Add(item.Quantity.ToString());
                    listViewItem.SubItems.Add(item.UnitPrice.ToString("C"));
                    listViewItem.SubItems.Add(item.TotalAmount.ToString("C"));
                    lstRevenueDetails.Items.Add(listViewItem);
                }

                // Hiển thị dữ liệu trong biểu đồ
                chartRevenue.Series["Revenue"].Points.Clear();
                foreach (var item in revenueData.GroupBy(r => r.ProductName))
                {
                    chartRevenue.Series["Revenue"].Points.AddXY(item.Key, item.Sum(i => i.TotalAmount));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering revenue data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadRevenueStatistics()
        {
            // Đặt lại DateTimePicker về ngày hiện tại
            dtpRevenueStartDate.Value = DateTime.Today;
            dtpRevenueEndDate.Value = DateTime.Today;

            // Đặt lại ComboBox về "All"
            cmbRevenueProductCategory.SelectedIndex = 0;

            // Xóa dữ liệu trong ListView và Chart
            lstRevenueDetails.Items.Clear();
            chartRevenue.Series["Revenue"].Points.Clear();
        }
        #endregion

        private void InitializeSummaryReportsTab()
        {
            // Khởi tạo DateTimePicker
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;

            // Khởi tạo ComboBox
            cmbTable.Items.AddRange(new string[] { "Customers", "Employees", "Products", "Orders", "OrderDetails", "StockTransactions" });
            cmbTable.SelectedIndex = 0;

            // Khởi tạo ListView
            lstSummary.View = View.Details;
            lstSummary.FullRowSelect = true;
            lstSummary.GridLines = true;
            lstSummary.Width = 1120;
            lstSummary.Scrollable = true;

            // Gán sự kiện cho ComboBox và Button
            cmbTable.SelectedIndexChanged += (s, e) => LoadTableData();
            btnExportToExcel.Click += (s, e) => ExportToExcel();
        }
        private void LoadTableData()
        {
            try
            {
                // Lấy tên bảng được chọn
                var tableName = cmbTable.SelectedItem.ToString();

                // Lấy dữ liệu từ bảng
                var dataTable = _statisticsService.GetTableData(tableName, dtpStart.Value, dtpEnd.Value);

                // Kiểm tra dữ liệu trả về
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Hiển thị dữ liệu trong ListView
                lstSummary.Clear();
                lstSummary.Columns.Clear();

                // Thêm cột vào ListView
                foreach (DataColumn column in dataTable.Columns)
                {
                    lstSummary.Columns.Add(column.ColumnName, 150); // Đặt chiều rộng cột là 150 (có thể điều chỉnh)
                }

                // Thêm dữ liệu vào ListView
                foreach (DataRow row in dataTable.Rows)
                {
                    var listViewItem = new ListViewItem(row[0].ToString());
                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        listViewItem.SubItems.Add(row[i].ToString());
                    }
                    lstSummary.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportToExcel()
        {
            try
            {
                // Lấy tên bảng được chọn
                var tableName = cmbTable.SelectedItem.ToString();

                // Tạo một workbook mới
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(tableName);

                // Xuất tiêu đề cột
                for (int i = 0; i < lstSummary.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = lstSummary.Columns[i].Text;
                }

                // Xuất dữ liệu từ ListView
                for (int i = 0; i < lstSummary.Items.Count; i++)
                {
                    for (int j = 0; j < lstSummary.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = lstSummary.Items[i].SubItems[j].Text;
                    }
                }

                // Lưu file Excel vào Desktop
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filePath = Path.Combine(desktopPath, $"{tableName}_Report.xlsx");

                // Kiểm tra nếu file đã tồn tại
                if (File.Exists(filePath))
                {
                    var result = MessageBox.Show("File already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // Không ghi đè, thoát khỏi phương thức
                    }
                }

                workbook.SaveAs(filePath);
                MessageBox.Show($"Exported successfully to {filePath}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReloadSummaryReports_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt lại DateTimePicker về ngày hiện tại
                dtpStart.Value = DateTime.Today;
                dtpEnd.Value = DateTime.Today;

                // Đặt lại ComboBox về mục mặc định
                cmbTable.SelectedIndex = 0;

                // Xóa dữ liệu trong ListView
                lstSummary.Clear();
                lstSummary.Columns.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading summary reports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
