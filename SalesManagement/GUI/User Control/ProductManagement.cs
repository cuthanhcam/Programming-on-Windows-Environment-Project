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
    public partial class ProductManagement : UserControl
    {
        private readonly ProductService _productService;

        public ProductManagement(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();
            lstProduct.Items.Clear();
            foreach (var product in products)
            {
                var item = new ListViewItem(product.ProductID.ToString())
                {
                    SubItems =
                {
                    product.Model,
                    product.Price.ToString("C"),
                    product.StockQuantity.ToString(),
                    product.Promotion.ToString(),
                    product.Warranty.ToString()
                }
                };
                lstProduct.Items.Add(item);
            }
        }

        private void lstProduct_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                var selected = lstProduct.SelectedItems[0];
                if (int.TryParse(selected.SubItems[0].Text, out int productId))
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
            richTextBoxSpecs.Text = product.Specifications;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out Product newProduct))
            {
                _productService.AddProduct(newProduct);
                LoadProducts();
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
                LoadProducts();
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
                LoadProducts();
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
                product = new Product
                {
                    Category = cmbCategory.Text,
                    Model = txtModel.Text,
                    Brand = cmbBrand.Text,
                    Price = price,
                    StockQuantity = 0,
                    Promotion = (int)nudPromition.Value,
                    Warranty = (int)nudWarranty.Value,
                    Specifications = richTextBoxSpecs.Text
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
        }
    }

}
