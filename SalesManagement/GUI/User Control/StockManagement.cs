using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class StockManagement : UserControl
    {
        private readonly StockService _stockService;
        private readonly ProductService _productService;
        private readonly int _employeeID;
        private List<StockTransaction> _allTransactions;
        private List<Product> _allProducts;
        private List<StockTransaction> _filteredTransactions;
        public StockManagement(StockService stockService, ProductService productService, int employeeID)
        {
            InitializeComponent();
            _stockService = stockService;
            _productService = productService;
            _employeeID = employeeID;
            _allTransactions = _stockService.GetAllTransactions();
            _allProducts = _productService.GetAllProducts();
            _filteredTransactions = _allTransactions;
            InitializeListViewColumns();
            InitializeComboBoxes();
            this.Load += StockManagement_Load; 
        }
        private void StockManagement_Load(object sender, EventArgs e)
        {
            LoadTransactionHistory(_allTransactions);
            LoadProducts(_allProducts);
        }

        private void InitializeListViewColumns()
        {
            // lstTransactionHistory - 1100
            lstTransactionHistory.Columns.Clear();
            lstTransactionHistory.Columns.Add("ID", 50);
            lstTransactionHistory.Columns.Add("Employee ID", 110);
            lstTransactionHistory.Columns.Add("Product ID", 110);
            lstTransactionHistory.Columns.Add("Model", 220);
            lstTransactionHistory.Columns.Add("Transaction Type", 160);
            lstTransactionHistory.Columns.Add("Quantity", 100);
            lstTransactionHistory.Columns.Add("Transaction Date", 150);
            lstTransactionHistory.Columns.Add("Note", 200);
            lstTransactionHistory.ShowGroups = true;
            lstTransactionHistory.View = View.Details;

            // lstProduct - 770
            lstProduct.Columns.Clear();
            lstProduct.Columns.Add("Product ID", 100);
            lstProduct.Columns.Add("Model", 250);
            lstProduct.Columns.Add("Category", 150);
            lstProduct.Columns.Add("Brand", 150);
            lstProduct.Columns.Add("Stock Quantity", 120);

            lstProduct.ShowGroups = true;
            lstProduct.View = View.Details;

        }
        private void LoadTransactionHistory(List<StockTransaction> transactions)
        {
            try
            {
                lstTransactionHistory.BeginUpdate();
                lstTransactionHistory.Items.Clear();
                lstTransactionHistory.Groups.Clear();

                var importGroup = new ListViewGroup("Import", HorizontalAlignment.Left);
                var exportGroup = new ListViewGroup("Export", HorizontalAlignment.Left);
                lstTransactionHistory.Groups.Add(importGroup);
                lstTransactionHistory.Groups.Add(exportGroup);

                foreach (var transaction in transactions)
                {
                    var item = new ListViewItem(transaction.TransactionID.ToString());
                    item.SubItems.Add(transaction.EmployeeID.ToString());
                    item.SubItems.Add(transaction.ProductID.ToString());
                    item.SubItems.Add(transaction.Product?.Model);
                    item.SubItems.Add(transaction.TransactionType);
                    item.SubItems.Add(transaction.Quantity.ToString());
                    item.SubItems.Add(transaction.TransactionDate.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(transaction.Note);

                    if (transaction.TransactionType == "Import")
                    {
                        item.Group = importGroup;
                        item.ForeColor = Color.Green;
                    }
                    else if (transaction.TransactionType == "Export")
                    {
                        item.Group = exportGroup;
                        item.ForeColor = Color.Red;
                    }

                    lstTransactionHistory.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transaction history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lstTransactionHistory.EndUpdate();
            }
        }

        private void LoadProducts(List<Product> products)
        {
            lstProduct.BeginUpdate();
            lstProduct.Items.Clear();
            lstProduct.Groups.Clear();

            var categories = products.Select(p => p.Category).Distinct();
            foreach (var category in categories)
            {
                lstProduct.Groups.Add(new ListViewGroup(category, category));
            }

            foreach (var product in products)
            {
                var item = new ListViewItem(product.ProductID.ToString());
                item.SubItems.Add(product.Model);
                item.SubItems.Add(product.Category);
                item.SubItems.Add(product.Brand);
                item.SubItems.Add(product.StockQuantity.ToString());

                item.Group = lstProduct.Groups[product.Category];
                lstProduct.Items.Add(item);
            }

            lstProduct.EndUpdate();
        }

        private void btnReloadTransactionHistory_Click(object sender, EventArgs e)
        {
            try
            {
                txtTransactionID.Clear();
                dtpTransactionDateStart.Value = DateTime.Today;
                dtpTransactionDateEnd.Value = DateTime.Today;
                cmbDate.SelectedIndex = 0;
                _allTransactions = _stockService.GetAllTransactions();
                LoadTransactionHistory(_allTransactions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading transaction history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReloadImportExport_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtModel.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbBrand.SelectedIndex = 0;
            cmbStockQuantity.SelectedIndex = 0;
            cmbTransactionType.SelectedIndex = 0;
            nudQuantity.Value = 0;
            rtbNote.Clear();
            _allProducts = _productService.GetAllProducts();
            LoadProducts(_allProducts);
        }

        private void btnMakeTransaction_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                int productID = int.Parse(lstProduct.SelectedItems[0].Text);
                int quantity = (int)nudQuantity.Value;
                string transactionType = cmbTransactionType.SelectedItem.ToString();
                string note = rtbNote.Text;

                try
                {
                    if (transactionType == "Import")
                    {
                        _stockService.ImportProduct(productID, _employeeID, quantity, note);
                    }
                    else if (transactionType == "Export")
                    {
                        _stockService.ExportProduct(productID, _employeeID, quantity, note);
                    }

                    // Cập nhật lại danh sách giao dịch và sản phẩm
                    _allTransactions = _stockService.GetAllTransactions();
                    _allProducts = _productService.GetAllProducts();
                    LoadTransactionHistory(_allTransactions);
                    LoadProducts(_allProducts);

                    MessageBox.Show("Transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error making transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to make a transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTransactionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FilterTransactionHistory();
            }
        }

        private void dtpTransactionDateStart_ValueChanged(object sender, EventArgs e)
        {
            FilterTransactionHistory();
        }

        private void dtpTransactionDateEnd_ValueChanged(object sender, EventArgs e)
        {
            FilterTransactionHistory();
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTransactionHistory();
        }
        private void FilterTransactionHistory()
        {
            string transactionID = txtTransactionID.Text;
            DateTime startDate = dtpTransactionDateStart.Value;
            DateTime endDate = dtpTransactionDateEnd.Value;
            string sortByDate = cmbDate.SelectedItem?.ToString();

            int id;
            bool isTransactionIDValid = int.TryParse(transactionID, out id);

            _filteredTransactions = _allTransactions
                .Where(t => (isTransactionIDValid ? t.TransactionID == id : true) &&
                            t.TransactionDate >= startDate &&
                            t.TransactionDate <= endDate)
                .ToList();

            if (sortByDate == "Ascending Date")
            {
                _filteredTransactions = _filteredTransactions.OrderBy(t => t.TransactionDate).ToList();
            }
            else if (sortByDate == "Descending Date")
            {
                _filteredTransactions = _filteredTransactions.OrderByDescending(t => t.TransactionDate).ToList();
            }

            LoadTransactionHistory(_filteredTransactions);
        }

        private void FilterProducts()
        {
            string productID = txtProductID.Text;
            string model = txtModel.Text;
            string category = cmbCategory.SelectedItem?.ToString();
            string brand = cmbBrand.SelectedItem?.ToString();
            string sortByStockQuantity = cmbStockQuantity.SelectedItem?.ToString();

            int id;
            bool isProductIDValid = int.TryParse(productID, out id);

            var filteredProducts = _allProducts
                .Where(p => (isProductIDValid ? p.ProductID == id : true) &&
                            (string.IsNullOrEmpty(model) || p.Model.IndexOf(model, StringComparison.OrdinalIgnoreCase) >= 0) &&
                            (category == "All" || p.Category == category) &&
                            (brand == "All" || p.Brand == brand))
                .ToList();

            if (sortByStockQuantity == "Ascending")
            {
                filteredProducts = filteredProducts.OrderBy(p => p.StockQuantity).ToList();
            }
            else if (sortByStockQuantity == "Descending")
            {
                filteredProducts = filteredProducts.OrderByDescending(p => p.StockQuantity).ToList();
            }

            LoadProducts(filteredProducts);
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FilterProducts();
            }
        }

        private void txtModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FilterProducts();
            }
        }

        private void InitializeComboBoxes()
        {
            // Khởi tạo cmbCategory và cmbBrand
            var categories = _allProducts.Select(p => p.Category).Distinct().ToList();
            var brands = _allProducts.Select(p => p.Brand).Distinct().ToList();

            cmbCategory.Items.Add("All");
            if (categories.Any())
            {
                cmbCategory.Items.AddRange(categories.ToArray());
            }

            cmbBrand.Items.Add("All");
            if (brands.Any())
            {
                cmbBrand.Items.AddRange(brands.ToArray());
            }

            // Đặt SelectedIndex = 0 mà không kích hoạt sự kiện
            UnsubscribeEvents();
            cmbCategory.SelectedIndex = 0;
            cmbBrand.SelectedIndex = 0;
            SubscribeEvents();

            // Khởi tạo cmbStockQuantity
            cmbStockQuantity.Items.Add("All");
            cmbStockQuantity.Items.Add("Ascending");
            cmbStockQuantity.Items.Add("Descending");
            cmbStockQuantity.SelectedIndex = 0;

            // Khởi tạo cmbDate
            cmbDate.Items.Add("All");
            cmbDate.Items.Add("Ascending Date");
            cmbDate.Items.Add("Descending Date");
            cmbDate.SelectedIndex = 0;

            // Khởi tạo cmbTransactionType
            cmbTransactionType.Items.Add("Import");
            cmbTransactionType.Items.Add("Export");
            cmbTransactionType.SelectedIndex = 0;
        }

        private void SubscribeEvents()
        {
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            cmbStockQuantity.SelectedIndexChanged += cmbStockQuantity_SelectedIndexChanged;
            cmbDate.SelectedIndexChanged += cmbDate_SelectedIndexChanged;
            txtTransactionID.KeyPress += txtTransactionID_KeyPress;
            txtProductID.KeyPress += txtProductID_KeyPress;
            txtModel.KeyPress += txtModel_KeyPress;
        }

        private void UnsubscribeEvents()
        {
            cmbCategory.SelectedIndexChanged -= cmbCategory_SelectedIndexChanged;
            cmbBrand.SelectedIndexChanged -= cmbBrand_SelectedIndexChanged;
            cmbStockQuantity.SelectedIndexChanged -= cmbStockQuantity_SelectedIndexChanged;
            cmbDate.SelectedIndexChanged -= cmbDate_SelectedIndexChanged;
            txtTransactionID.KeyPress -= txtTransactionID_KeyPress;
            txtProductID.KeyPress -= txtProductID_KeyPress;
            txtModel.KeyPress -= txtModel_KeyPress;
        }

        private void UpdateBrandComboBox()
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            List<string> brands;

            if (selectedCategory == "All")
            {
                brands = _productService.GetAllBrands();
            }
            else
            {
                brands = _productService.GetBrandsByCategory(selectedCategory);
            }

            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("All");
            if (brands.Any())
            {
                cmbBrand.Items.AddRange(brands.ToArray());
            }
            cmbBrand.SelectedIndex = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật cmbBrand khi Category thay đổi
            UpdateBrandComboBox();
            FilterProducts(); // Lọc lại danh sách sản phẩm
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void cmbStockQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }


    }
}
