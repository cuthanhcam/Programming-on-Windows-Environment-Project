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
            //lstProduct.BeginUpdate(); // Tạm dừng cập nhật giao diện
            //imageListProducts.Images.Clear();
            //lstProduct.Items.Clear();

            //foreach (var product in products)
            //{
            //    var item = new ListViewItem();

            //    string imagePath = Path.Combine("Images", product.Category, product.Model + ".jpg");
            //    if (File.Exists(imagePath))
            //    {
            //        imageListProducts.Images.Add(Image.FromFile(imagePath));
            //        item.ImageIndex = imageListProducts.Images.Count - 1;
            //    }
            //    else
            //    {
            //        item.ImageIndex = -1;
            //    }

            //    item.SubItems.Add(product.ProductID.ToString());
            //    item.SubItems.Add(product.Model);
            //    item.SubItems.Add(product.Price.ToString("C"));
            //    item.SubItems.Add(product.StockQuantity.ToString());
            //    item.SubItems.Add(product.Promotion.ToString());
            //    item.SubItems.Add(product.Warranty.ToString());

            //    lstProduct.Items.Add(item);
            //}

            //lstProduct.EndUpdate(); // Kích hoạt cập nhật giao diện
            lstProduct.BeginUpdate(); // Tạm dừng cập nhật giao diện
            imageListProducts.Images.Clear();
            lstProduct.Items.Clear();
            lstProduct.Groups.Clear(); // Xóa các nhóm cũ

            // Tạo các nhóm dựa trên Category
            var categories = products.Select(p => p.Category).Distinct();
            foreach (var category in categories)
            {
                lstProduct.Groups.Add(new ListViewGroup(category, category));
            }

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

                // Gán sản phẩm vào nhóm tương ứng
                item.Group = lstProduct.Groups[product.Category];

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
            lstProduct.ShowGroups = true;
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
            ApplyFilters();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            string searchText = txtSearch.Text.Trim();
            string selectedPriceSort = cmbPrice.SelectedItem?.ToString();

            var filteredProducts = _productService.FilterProducts(selectedCategory, selectedBrand, searchText, selectedPriceSort);
            LoadProducts(filteredProducts);
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
                var product = _productService.GetProductById(productId);
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt lại các bộ lọc về mặc định
                cmbCategory.SelectedIndex = 0;
                cmbBrand.SelectedIndex = 0;
                txtSearch.Clear();
                cmbPrice.SelectedIndex = 0;

                // Tải lại danh sách sản phẩm
                _allProducts = _productService.GetAllProducts();
                LoadProducts(_allProducts);
                ClearForm(); // Xóa form nhập liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnAddUpdatePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string category = cmbCategory.Text;
                    string model = txtModel.Text;

                    if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(model))
                    {
                        try
                        {
                            string destinationFolder = Path.Combine("Images", category);
                            if (!Directory.Exists(destinationFolder))
                            {
                                Directory.CreateDirectory(destinationFolder);
                            }

                            string destinationPath = Path.Combine(destinationFolder, model + ".jpg");
                            File.Copy(selectedImagePath, destinationPath, overwrite: true);

                            // Cập nhật ảnh trong PictureBox
                            pbProduct.ImageLocation = destinationPath;

                            // Cập nhật đường dẫn ảnh trong cơ sở dữ liệu
                            var product = _allProducts.FirstOrDefault(p => p.Model == model);
                            if (product != null)
                            {
                                _productService.UpdateProductImage(product.ProductID, destinationPath);
                            }

                            MessageBox.Show("Image added/updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saving image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a category and enter a model name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string category = cmbCategory.SelectedItem.ToString();
                string model = txtModel.Text.Trim();
                string brand = cmbBrand.SelectedItem.ToString();
                decimal price = decimal.Parse(txtPrice.Text.Trim());
                int stockQuantity = int.Parse(txtStockQuantity.Text.Trim());
                string specifications = richTextBoxDetail.Text.Trim();
                string imagePath = SaveProductImage(pbProduct.Image, model); // Lưu ảnh vào thư mục
                int promotion = int.Parse(txtPromotion.Text.Trim());
                int warranty = int.Parse(txtWarranty.Text.Trim());

                productService.AddProduct(category, model, brand, price, stockQuantity, specifications, imagePath, promotion, warranty);
                LoadProductsToListView(); // Load lại danh sách
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(txtProductID.Text);
                string details = richTextBoxDetail.Text.Trim();

                productService.UpdateProduct(productId, details);
                LoadProductsToListView(); // Load lại danh sách
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(txtProductID.Text);

                var confirmResult = MessageBox.Show("Are you sure to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    productService.DeleteProduct(productId);
                    LoadProductsToListView(); // Load lại danh sách
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
