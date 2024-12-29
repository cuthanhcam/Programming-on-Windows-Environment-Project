using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ProductManagement : UserControl
    {
        private readonly ProductService _productService;
        private List<Product> _allProducts;

        public ProductManagement(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            _allProducts = _productService.GetAllProducts(); // Lưu trữ danh sách sản phẩm
            InitializeListViewColumns();
            LoadCategories();
            LoadBrands();
            LoadProducts(_allProducts);
            ClearForm();

            richTextBoxDetail.ReadOnly = true;
            richTextBoxDetail.BackColor = Color.White;

            cmbPrice.Items.Add("All");
            cmbPrice.Items.Add("Price Ascending"); // Giá tăng dần
            cmbPrice.Items.Add("Price Descending"); // Giá giảm dần
            cmbPrice.SelectedIndex = 0;

            // Đăng ký sự kiện SelectedIndexChanged cho cmbCategory và cmbBrand
            //cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            //cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;

            // Đăng ký sự kiện KeyPress cho txtProductID
            txtProductID.KeyPress += txtProductID_KeyPress;
        }

        private void LoadProducts(List<Product> products)
        {
            lstProduct.BeginUpdate(); // Tạm dừng cập nhật giao diện
            imageListProducts.Images.Clear();
            lstProduct.Items.Clear();

            foreach (var product in products)
            {
                var item = new ListViewItem();

                string imagePath = Path.Combine("Images", product.Category, product.Model + ".jpg");
                if (File.Exists(imagePath))
                {
                    imageListProducts.Images.Add(Image.FromFile(imagePath));
                    item.ImageIndex = imageListProducts.Images.Count - 1;
                }
                else
                {
                    item.ImageIndex = -1;
                }

                item.SubItems.Add(product.ProductID.ToString());
                item.SubItems.Add(product.Model);
                item.SubItems.Add(product.Price.ToString("C"));
                item.SubItems.Add(product.StockQuantity.ToString());
                item.SubItems.Add(product.Promotion.ToString());
                item.SubItems.Add(product.Warranty.ToString());

                lstProduct.Items.Add(item);
            }

            lstProduct.EndUpdate(); // Kích hoạt cập nhật giao diện
        }

        private void InitializeListViewColumns()
        {
            lstProduct.Columns.Clear();
            lstProduct.Columns.Add("Image", 70);
            lstProduct.Columns.Add("ID", 50);
            lstProduct.Columns.Add("Model", 250);
            lstProduct.Columns.Add("Price", 100);
            lstProduct.Columns.Add("Quantity", 100);
            lstProduct.Columns.Add("Promotion", 100);
            lstProduct.Columns.Add("Warranty", 100);
            lstProduct.SmallImageList = imageListProducts;
        }
        private void LoadCategories()
        {
            var categories = _allProducts
                            .Select(p => p.Category)
                            .Distinct()
                            .ToList();

            // Thêm mục "All" vào đầu danh sách
            categories.Insert(0, "All");

            cmbCategory.DataSource = categories;
            cmbCategory.SelectedIndex = 0; // Chọn mục "All" mặc định
        }

        private void LoadBrands()
        {
            var brands = _allProducts
                        .Select(p => p.Brand)
                        .Distinct()
                        .ToList();

            // Thêm mục "All" vào đầu danh sách
            brands.Insert(0, "All");

            cmbBrand.DataSource = brands;
            cmbBrand.SelectedIndex = 0; // Chọn mục "All" mặc định
        }
        // Tính năng ràng buộc phụ thuộc tìm kiếm giữa hai cmbCategories và cmbBrand
        /*
        private void LoadCategories(string brand = null)
        {
            // Tạm thời vô hiệu hóa sự kiện SelectedIndexChanged
            cmbCategory.SelectedIndexChanged -= cmbCategory_SelectedIndexChanged;

            var categories = _allProducts
                            .Where(p => brand == null || p.Brand == brand)
                            .Select(p => p.Category)
                            .Distinct()
                            .ToList();

            // Thêm mục "All" vào đầu danh sách
            categories.Insert(0, "All");

            cmbCategory.DataSource = categories;
            cmbCategory.SelectedIndex = 0; // Chọn mục "All" mặc định

            // Kích hoạt lại sự kiện SelectedIndexChanged
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
        }

        private void LoadBrands(string category = null)
        {
            // Tạm thời vô hiệu hóa sự kiện SelectedIndexChanged
            cmbBrand.SelectedIndexChanged -= cmbBrand_SelectedIndexChanged;

            var brands = _allProducts
                        .Where(p => category == null || p.Category == category)
                        .Select(p => p.Brand)
                        .Distinct()
                        .ToList();

            // Thêm mục "All" vào đầu danh sách
            brands.Insert(0, "All");

            cmbBrand.DataSource = brands;
            cmbBrand.SelectedIndex = 0; // Chọn mục "All" mặc định

            // Kích hoạt lại sự kiện SelectedIndexChanged
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
        }
        */
        private void lstProduct_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                var selected = lstProduct.SelectedItems[0];
                if (int.TryParse(selected.SubItems[1].Text, out int productId))
                {
                    var product = _allProducts.FirstOrDefault(p => p.ProductID == productId);
                    if (product != null)
                    {
                        PopulateProductDetails(product);
                    }
                }
            }
        }

        private void PopulateProductDetails(Product product)
        {
            // Cập nhật Product ID
            txtProductID.Text = product.ProductID.ToString();

            // Hiển thị thông tin chi tiết trong richTextBoxDetails
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Category: {product.Category}");
            sb.AppendLine($"Model: {product.Model}");
            sb.AppendLine($"Brand: {product.Brand}");
            sb.AppendLine($"Price: {product.Price.ToString("C")}");
            sb.Append(DisplaySpecifications(product.Specifications));

            richTextBoxDetail.Text = sb.ToString();
                
            // Hiển thị ảnh sản phẩm
            string imagePath = Path.Combine("Images", product.Category, product.Model + ".jpg");
            if (File.Exists(imagePath))
            {
                pbProduct.Image = Image.FromFile(imagePath);
            }
            else
            {
                pbProduct.Image = null;
            }
        }
        private string DisplaySpecifications(string jsonSpecs)
        {
            try
            {
                var specs = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonSpecs);
                StringBuilder sb = new StringBuilder();

                // Thêm các thông số kỹ thuật
                foreach (var key in specs.Keys)
                {
                    sb.AppendLine($"{key}: {specs[key]}");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "Invalid specifications format.";
            }
        }
        private void ClearForm()
        {
            txtProductID.Clear();
            richTextBoxDetail.Clear();
            pbProduct.Image = null;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedCategory = cmbCategory.SelectedItem?.ToString();
            //LoadBrands(selectedCategory == "All" ? null : selectedCategory);
            ApplyFilters();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedBrand = cmbBrand.SelectedItem?.ToString();
            //LoadCategories(selectedBrand == "All" ? null : selectedBrand);
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            string selectedBrand = cmbBrand.SelectedItem?.ToString();
            string searchText = txtSearch.Text.Trim().ToLower();
            string productIdText = txtProductID.Text.Trim();
            string selectedPriceSort = cmbPrice.SelectedItem?.ToString();

            var filteredProducts = _allProducts.AsQueryable(); // Sử dụng IQueryable để tối ưu hóa truy vấn

            // Lọc theo danh mục
            if (selectedCategory != "All")
            {
                filteredProducts = filteredProducts.Where(p => p.Category == selectedCategory);
            }

            // Lọc theo thương hiệu
            if (selectedBrand != "All")
            {
                filteredProducts = filteredProducts.Where(p => p.Brand == selectedBrand);
            }

            // Tìm kiếm theo tên hoặc mã sản phẩm
            if (!string.IsNullOrEmpty(searchText))
            {
                filteredProducts = filteredProducts.Where(p => p.Model.ToLower().Contains(searchText));
            }

            // Sắp xếp theo giá
            if (selectedPriceSort == "Price Ascending")
            {
                filteredProducts = filteredProducts.OrderBy(p => p.Price);
            }
            else if (selectedPriceSort == "Price Descending")
            {
                filteredProducts = filteredProducts.OrderByDescending(p => p.Price);
            }

            // Chuyển kết quả thành danh sách và tải vào ListView
            LoadProducts(filteredProducts.ToList());
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchProductByID();
                e.Handled = true; // Ngăn không cho phát ra tiếng bíp khi nhấn Enter
            }
        }
        private void SearchProductByID()
        {
            if (int.TryParse(txtProductID.Text, out int productId))
            {
                var product = _allProducts.FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    PopulateProductDetails(product);
                }
                else
                {
                    MessageBox.Show("Product not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Product ID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
