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

        public ProductManagement(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            InitializeListViewColumns();
            LoadCategories();
            LoadBrands();
            LoadProducts(_productService.GetAllProducts());
            ClearForm();
        }

        private void LoadProducts(List<Product> products)
        {
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
            var categories = _productService.GetAllProducts()
                                            .Select(p => p.Category)
                                            .Distinct()
                                            .ToList();
            categories.Insert(0, "All");
            cmbCategory.DataSource = categories;
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadBrands()
        {
            var brands = _productService.GetAllProducts().Select(p => p.Brand).Distinct().ToList();
            cmbBrand.DataSource = brands;
        }

        private void lstProduct_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                var selected = lstProduct.SelectedItems[0];
                if (int.TryParse(selected.SubItems[1].Text, out int productId))
                {
                    var product = _productService.GetAllProducts()
                                                 .FirstOrDefault(p => p.ProductID == productId);
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
            txtModel.Text = product.Model;
            txtPrice.Text = product.Price.ToString();
            cmbCategory.Text = product.Category;
            cmbBrand.Text = product.Brand;
            nudPromition.Value = product.Promotion;
            nudWarranty.Value = product.Warranty;
            DisplaySpecifications(product.Specifications);

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

        private void DisplaySpecifications(string jsonSpecs)
        {
            try
            {
                var specs = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonSpecs);
                StringBuilder sb = new StringBuilder();

                foreach (var key in specs.Keys)
                {
                    sb.AppendLine($"{key}: {specs[key]}");
                }

                richTextBoxSpecs.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                richTextBoxSpecs.Text = "Invalid specifications format.";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out Product newProduct))
            {
                _productService.AddProduct(newProduct);
                LoadProducts(_productService.GetAllProducts());
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out Product updatedProduct) && int.TryParse(txtProductID.Text, out int productId))
            {
                updatedProduct.ProductID = productId;
                _productService.UpdateProduct(updatedProduct);

                if (!string.IsNullOrEmpty(pbProduct.ImageLocation))
                {
                    _productService.UpdateProductImage(productId, pbProduct.ImageLocation);
                }

                LoadProducts(_productService.GetAllProducts());
                ClearForm();
            }
            else
            {
                MessageBox.Show("Invalid data or product selection.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProductID.Text, out int productId))
            {
                _productService.DeleteProduct(productId);
                LoadProducts(_productService.GetAllProducts());
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please select a valid product to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateInputs(out Product product)
        {
            product = null;
            if (decimal.TryParse(txtPrice.Text, out decimal price) && !string.IsNullOrEmpty(txtModel.Text) &&
                !string.IsNullOrEmpty(cmbCategory.Text) && !string.IsNullOrEmpty(cmbBrand.Text))
            {
                int stockQuantity = 0;
                if (int.TryParse(txtProductID.Text, out int productId))
                {
                    var existingProduct = _productService.GetAllProducts()
                                                        .FirstOrDefault(p => p.ProductID == productId);
                    if (existingProduct != null)
                    {
                        stockQuantity = existingProduct.StockQuantity;
                    }
                }

                product = new Product
                {
                    Category = cmbCategory.Text,
                    Model = txtModel.Text,
                    Brand = cmbBrand.Text,
                    Price = price,
                    StockQuantity = stockQuantity,
                    Promotion = (int)nudPromition.Value,
                    Warranty = (int)nudWarranty.Value,
                    Specifications = richTextBoxSpecs.Text,
                    Image = pbProduct.ImageLocation
                };
                return true;
            }
            return false;
        }

        private void ClearForm()
        {
            txtProductID.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbBrand.SelectedIndex = -1;
            nudPromition.Value = 0;
            nudWarranty.Value = 0;
            richTextBoxSpecs.Clear();
            pbProduct.Image = null;
        }

        private void bntAddPic_Click(object sender, EventArgs e)
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
                        string destinationFolder = Path.Combine("Images", category);
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                        string destinationPath = Path.Combine(destinationFolder, model + ".jpg");
                        File.Copy(selectedImagePath, destinationPath, overwrite: true);

                        pbProduct.ImageLocation = destinationPath;
                    }
                    else
                    {
                        MessageBox.Show("Please select a category and enter a model name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                List<Product> filteredProducts;
                if (selectedCategory == "All")
                {
                    filteredProducts = _productService.GetAllProducts();
                }
                else
                {
                    filteredProducts = _productService.GetProductsByCategory(selectedCategory);
                }

                LoadProducts(filteredProducts);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            var allProducts = _productService.GetAllProducts();
            var filteredProducts = allProducts.Where(p => p.Model.ToLower().Contains(searchText)).ToList();
            LoadProducts(filteredProducts);
        }

    }
}
