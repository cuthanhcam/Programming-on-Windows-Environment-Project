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
        private List<Product> _filteredProducts;

        public ProductManagement(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            _allProducts = _productService.GetAllProducts();
            _filteredProducts = _allProducts;
            InitializeListViewColumns();
            LoadProducts(_filteredProducts);
            InitializeComboBoxes();
            InitializeSearch();

            rtbDetail.KeyPress += rtbDetail_KeyPress;
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
            rtbDetail.Text = _productService.GetEmptySpecifications(selectedCategory);

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
            lstProduct.Columns.Add("Warranty", 100);
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
            txtProductID.Text = product.ProductID.ToString();
            StringBuilder sb = new StringBuilder();

            var specifications = _productService.GetDefaultSpecifications(product.Category);
            var specValues = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(product.Specifications);

            foreach (var spec in specifications)
            {
                string value = specValues.ContainsKey(spec) ? specValues[spec] : "";
                sb.AppendLine($"{spec}: {value}");
            }

            rtbDetail.Text = sb.ToString();

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

        

        private void ClearForm()
        {
            txtProductID.Clear();
            rtbDetail.Clear();
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
            int cursorPosition = rtbDetail.SelectionStart;

            int lineIndex = rtbDetail.GetLineFromCharIndex(cursorPosition);
            string line = rtbDetail.Lines[lineIndex];

            int colonIndex = line.IndexOf(':');
            if (colonIndex != -1 && cursorPosition <= rtbDetail.GetFirstCharIndexFromLine(lineIndex) + colonIndex)
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ rtbDetail
                var lines = rtbDetail.Lines;
                var details = new Dictionary<string, string>();

                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        details[parts[0].Trim()] = parts[1].Trim();
                    }
                }

                // Lấy các thông tin cần thiết
                string category = details.ContainsKey("Category") ? details["Category"] : string.Empty;
                string model = details.ContainsKey("Model") ? details["Model"] : string.Empty;
                string brand = details.ContainsKey("Brand") ? details["Brand"] : string.Empty;
                decimal price = details.ContainsKey("Price") && decimal.TryParse(details["Price"], out decimal p) ? p : 0;
                string specifications = Newtonsoft.Json.JsonConvert.SerializeObject(details);
                string imagePath = SaveImage(category, model);

                // Thêm sản phẩm mới
                _productService.AddProduct(category, model, brand, price, specifications, imagePath, 0, 0);

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

        private string SaveImage(string category, string model)
        {
            if (pbProduct.Image != null)
            {
                string imagePath = Path.Combine("Images", category, model + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                using (var bitmap = new Bitmap(pbProduct.Image))
                {
                    // Giải phóng ảnh đang sử dụng
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

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

                var lines = rtbDetail.Lines;
                var details = new Dictionary<string, string>();

                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        details[parts[0].Trim()] = parts[1].Trim();
                    }
                }

                string category = details.ContainsKey("Category") ? details["Category"] : string.Empty;
                string model = details.ContainsKey("Model") ? details["Model"] : string.Empty;
                string brand = details.ContainsKey("Brand") ? details["Brand"] : string.Empty;
                decimal price = details.ContainsKey("Price") && decimal.TryParse(details["Price"], out decimal p) ? p : 0;
                string specifications = Newtonsoft.Json.JsonConvert.SerializeObject(details);

                // Giải phóng hình ảnh trước khi ghi đè
                pbProduct.Image?.Dispose();
                pbProduct.Image = null;

                string imagePath = SaveImage(category, model);

                _productService.UpdateProduct(productId, category, model, brand, price, specifications, imagePath, 0, 0);
                _allProducts = _productService.GetAllProducts();
                LoadProducts(_allProducts);

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProductID.Text, out int productId))
                    throw new Exception("Invalid Product ID.");

                // Xóa sản phẩm
                _productService.DeleteProduct(productId);

                // Cập nhật danh sách sản phẩm
                _allProducts = _productService.GetAllProducts();
                LoadProducts(_allProducts);
                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUpdatePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbProduct.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}
