using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private readonly string _role;
        private readonly ProductService _productService;
        private static readonly string ImagesBasePath = @"D:\SourceCode\VisualStudio\CSharp\Programming-on-Windows-Environment-Project\Images";
        //private static readonly string ImagesBasePath = Path.Combine(Application.StartupPath, "Images");
        private List<Product> _allProducts;
        private List<Product> _filteredProducts;

        public ProductManagement(ProductService productService, string role)
        {
            InitializeComponent();
            _productService = productService;
            _role = role;
            _allProducts = _productService.GetAllProducts();
            _filteredProducts = _allProducts;
            InitializeListViewColumns();
            LoadProducts(_filteredProducts);
            InitializeComboBoxes();
            InitializeSearch();

            rtbSpecs.KeyPress += rtbDetail_KeyPress;
            ApplyRoleBasedAccessControl();
        }

        private void ApplyRoleBasedAccessControl()
        {
            if (_role == "Staff")
            {
                btnDelete.Enabled = false; // Ẩn nút Delete
            }
        }

        private void InitializeComboBoxes()
        {
            // Khởi tạo cmbCategory và cmbBrand
            var categories = _allProducts.Select(p => p.Category).Distinct().ToList();
            var brands = _allProducts.Select(p => p.Brand).Distinct().ToList();

            cmbCategory.Items.Add("All");
            cmbCategory.Items.AddRange(categories.ToArray());

            cmbBrand.Items.Add("All");
            cmbBrand.Items.AddRange(brands.ToArray());

            // Đặt SelectedIndex = 0 mà không kích hoạt sự kiện
            UnsubscribeEvents();
            cmbCategory.SelectedIndex = 0;
            cmbBrand.SelectedIndex = 0;
            SubscribeEvents();

            // Khởi tạo cmbPrice    
            cmbPrice.Items.Add("All");
            cmbPrice.Items.Add("Price Ascending");
            cmbPrice.Items.Add("Price Descending");
            cmbPrice.SelectedIndex = 0;
            cmbPrice.SelectedIndexChanged += cmbPrice_SelectedIndexChanged;
        }

        private void SubscribeEvents()
        {
            // Đăng ký sự kiện SelectedIndexChanged
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            txtProductID.KeyDown += txtProductID_KeyDown;
        }

        private void UnsubscribeEvents()
        {
            // Hủy đăng ký sự kiện SelectedIndexChanged
            cmbCategory.SelectedIndexChanged -= cmbCategory_SelectedIndexChanged;
            cmbBrand.SelectedIndexChanged -= cmbBrand_SelectedIndexChanged;
            txtProductID.KeyDown -= txtProductID_KeyDown;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            // Lấy danh sách brands theo category
            var brands = selectedCategory == "All"
                ? _productService.GetAllBrands()
                : _productService.GetBrandsByCategory(selectedCategory);

            UnsubscribeEvents();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("All");
            cmbBrand.Items.AddRange(brands.ToArray());
            cmbBrand.SelectedIndex = 0;
            SubscribeEvents();

            // Hiển thị thông số trống
            rtbSpecs.Text = _productService.GetEmptySpecifications(selectedCategory);

            // Lọc danh sách sản phẩm
            FilterProducts();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lọc danh sách sản phẩm
            FilterProducts();
        }

        private void cmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lọc danh sách sản phẩm theo giá
            FilterProducts();
        }

        private void InitializeSearch()
        {
            // Thêm sự kiện TextChanged cho txtSearch
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Lọc danh sách sản phẩm theo model
            FilterProducts();
        }

        private void FilterProducts()
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();
            string selectedBrand = cmbBrand.SelectedItem.ToString();
            string selectedPriceSort = cmbPrice.SelectedItem.ToString();
            string searchText = txtSearch.Text.Trim();

            // Lọc sản phẩm từ ProductService
            _filteredProducts = _productService.FilterProducts(selectedCategory, selectedBrand, searchText, selectedPriceSort);

            // Cập nhật danh sách sản phẩm
            LoadProducts(_filteredProducts);
        }

        private void LoadProducts(List<Product> products)
        {
            lstProduct.BeginUpdate();
            imageListProducts.Images.Clear();
            lstProduct.Items.Clear();
            lstProduct.Groups.Clear();

            var categories = products.Select(p => p.Category).Distinct();
            foreach (var category in categories)
            {
                lstProduct.Groups.Add(new ListViewGroup(category, category));
            }

            foreach (var product in products)
            {
                var item = new ListViewItem();

                string imagePath = Path.Combine(ImagesBasePath, product.Category, product.Model + ".jpg");
                if (File.Exists(imagePath))
                {
                    using (var img = Image.FromFile(imagePath))
                    {
                        imageListProducts.Images.Add(new Bitmap(img)); // Tạo bản sao của ảnh
                    }
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

                item.Group = lstProduct.Groups[product.Category];

                lstProduct.Items.Add(item);
            }

            lstProduct.EndUpdate();
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
            lstProduct.Columns.Add("Warranty", 80);
            lstProduct.SmallImageList = imageListProducts;
            lstProduct.ShowGroups = true;
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
            try
            {
                txtProductID.Text = product.ProductID.ToString();
                txtCategory.Text = product.Category;
                txtModel.Text = product.Model;
                txtBrand.Text = product.Brand;
                txtOriginalPrice.Text = product.OriginalPrice.ToString("N2"); // ToString("C") // ("N2")
                txtPromotion.Text = product.Promotion.ToString();
                txtWarranty.Text = product.Warranty.ToString();
                dtpCreatedAt.Value = product.CreatedAt;
                dtpUpdatedAt.Value = product.UpdatedAt;

                StringBuilder sb = new StringBuilder();

                var specifications = _productService.GetDefaultSpecifications(product.Category);
                var specValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(product.Specifications);

                foreach (var spec in specifications)
                {
                    string value = specValues.ContainsKey(spec) ? specValues[spec] : "";
                    sb.AppendLine($"{spec}: {value}");
                }

                rtbSpecs.Text = sb.ToString();

                // Hiển thị ảnh sản phẩm
                string imagePath = Path.Combine(ImagesBasePath, product.Category, product.Model + ".jpg");
                LoadImageToPictureBox(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtProductID.Clear();
            txtCategory.Clear();
            txtModel.Clear();
            txtBrand.Clear();
            txtOriginalPrice.Clear();
            txtPromotion.Clear();
            txtWarranty.Clear();
            dtpCreatedAt.Value = DateTime.Now;
            dtpUpdatedAt.Value = DateTime.Now;
            rtbSpecs.Clear();
            pbProduct.Image = null;
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

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                e.Handled = true;
            }
        }

        private void rtbDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPosition = rtbSpecs.SelectionStart;

            int lineIndex = rtbSpecs.GetLineFromCharIndex(cursorPosition);
            string line = rtbSpecs.Lines[lineIndex];

            int colonIndex = line.IndexOf(':');
            if (colonIndex != -1 && cursorPosition <= rtbSpecs.GetFirstCharIndexFromLine(lineIndex) + colonIndex)
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string category = txtCategory.Text;
                string model = txtModel.Text;
                string brand = txtBrand.Text;
                decimal originalPrice = decimal.TryParse(txtOriginalPrice.Text, out decimal p) ? p : 0;
                int promotion = int.TryParse(txtPromotion.Text, out int promo) ? promo : 0;
                int warranty = int.TryParse(txtWarranty.Text, out int war) ? war : 0;

                // Tính toán giá sau khuyến mãi
                decimal price = originalPrice * (100 - promotion) / 100;

                // Lấy dữ liệu từ rtbSpecs
                var lines = rtbSpecs.Lines;
                var specifications = new Dictionary<string, string>();

                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        specifications[parts[0].Trim()] = parts[1].Trim();
                    }
                }

                // Chuyển đổi specifications thành JSON
                string specificationsJson = Newtonsoft.Json.JsonConvert.SerializeObject(specifications);

                // Lưu ảnh sản phẩm nếu có ảnh mới được chọn
                string imagePath = null;
                if (pbProduct.Image != null)
                {
                    imagePath = SaveImage(category, model, pbProduct.Image);
                }

                // Thêm sản phẩm mới
                _productService.AddProduct(category, model, brand, originalPrice, specificationsJson, imagePath, promotion, warranty);

                // Cập nhật danh sách sản phẩm
                _allProducts = _productService.GetAllProducts();
                LoadProducts(_allProducts);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveImage(string category, string model, Image image)
        {
            if (image != null)
            {
                string imagePath = Path.Combine(ImagesBasePath, category, model + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                // Xóa ảnh cũ nếu tồn tại
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                // Lưu ảnh mới
                using (var bitmap = new Bitmap(image))
                {
                    bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                return imagePath;
            }
            return null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductID.Text, out int productId))
                    throw new Exception("Invalid Product ID.");

                // Lấy dữ liệu từ các TextBox
                string category = txtCategory.Text;
                string model = txtModel.Text;
                string brand = txtBrand.Text;
                decimal originalPrice = decimal.TryParse(txtOriginalPrice.Text, out decimal p) ? p : 0;
                int promotion = int.TryParse(txtPromotion.Text, out int promo) ? promo : 0;
                int warranty = int.TryParse(txtWarranty.Text, out int war) ? war : 0;

                // Tính toán giá sau khuyến mãi
                decimal price = originalPrice * (100 - promotion) / 100;

                // Kiểm tra giá trị hợp lệ
                if (originalPrice <= 0)
                    throw new Exception("Original price must be greater than zero.");
                if (promotion < 0 || promotion > 100)
                    throw new Exception("Promotion must be between 0 and 100.");
                if (warranty < 0)
                    throw new Exception("Warranty must be a non-negative value.");

                // Lấy dữ liệu từ rtbSpecs
                var lines = rtbSpecs.Lines;
                var specifications = new Dictionary<string, string>();

                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        specifications[parts[0].Trim()] = parts[1].Trim();
                    }
                }

                // Chuyển đổi specifications thành JSON
                string specificationsJson = Newtonsoft.Json.JsonConvert.SerializeObject(specifications);

                // Không lưu ảnh ở đây, chỉ cập nhật thông tin sản phẩm
                _productService.UpdateProduct(productId, category, model, brand, originalPrice, specificationsJson, null, promotion, warranty);

                // Cập nhật danh sách sản phẩm
                _allProducts = _productService.GetAllProducts();
                LoadProducts(_allProducts);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImageToPictureBox(string imagePath)
        {
            if (pbProduct.Image != null)
            {
                pbProduct.Image.Dispose(); // Giải phóng ảnh cũ
                pbProduct.Image = null;
            }

            if (File.Exists(imagePath))
            {
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    pbProduct.Image = new Bitmap(Image.FromStream(stream)); // Tạo bản sao của ảnh
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductID.Text, out int productId))
                    throw new Exception("Invalid Product ID.");

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lấy thông tin sản phẩm
                    var product = _productService.GetProductById(productId);
                    if (product != null)
                    {
                        // Xóa ảnh sản phẩm nếu tồn tại
                        string imagePath = Path.Combine(ImagesBasePath, product.Category, product.Model + ".jpg");
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                // Giải phóng ảnh trong PictureBox
                                if (pbProduct.Image != null)
                                {
                                    pbProduct.Image.Dispose();
                                    pbProduct.Image = null;
                                }

                                // Xóa file ảnh
                                File.Delete(imagePath);
                                Debug.WriteLine($"Deleted image at: {imagePath}");
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show($"Error deleting image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Xóa sản phẩm trong cơ sở dữ liệu
                        _productService.DeleteProduct(productId);

                        // Cập nhật danh sách sản phẩm
                        _allProducts = _productService.GetAllProducts();
                        LoadProducts(_allProducts);
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUpdatePic_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở hộp thoại chọn ảnh
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy thông tin từ các TextBox
                        string category = txtCategory.Text;
                        string model = txtModel.Text;

                        // Kiểm tra tính hợp lệ của file ảnh
                        if (!IsImageValid(openFileDialog.FileName))
                        {
                            MessageBox.Show("Invalid image file. Please select a valid image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Tạo đường dẫn lưu ảnh
                        string imagePath = Path.Combine(ImagesBasePath, category, model + ".jpg");
                        Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                        // Xóa ảnh cũ nếu tồn tại
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                // Giải phóng ảnh trong PictureBox
                                if (pbProduct.Image != null)
                                {
                                    pbProduct.Image.Dispose();
                                    pbProduct.Image = null;
                                }

                                // Xóa file ảnh
                                File.Delete(imagePath);
                                Debug.WriteLine($"Deleted old image at: {imagePath}");
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show($"Error deleting old image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Lưu ảnh mới
                        using (var bitmap = new Bitmap(openFileDialog.FileName))
                        {
                            bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        Debug.WriteLine($"Saved new image at: {imagePath}");

                        // Kiểm tra sản phẩm đã tồn tại hay chưa
                        bool isExistingProduct = int.TryParse(txtProductID.Text, out int productId);
                        if (isExistingProduct)
                        {
                            _productService.UpdateProductImage(productId, imagePath);
                            MessageBox.Show("Product image updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Image added successfully! Please save the product to complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Hiển thị ảnh mới trên PictureBox
                        LoadImageToPictureBox(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsImageValid(string filePath)
        {
            try
            {
                using (var img = Image.FromFile(filePath))
                {
                    return img != null;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}