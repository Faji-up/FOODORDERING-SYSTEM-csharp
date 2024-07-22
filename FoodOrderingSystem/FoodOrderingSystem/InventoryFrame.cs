using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrderingSystem
{
    public partial class InventoryFrame : Form
    {
        String ImagePath = "";
        public InventoryFrame()
        {
            InitializeComponent();
            dataView.Rows.Clear();
            
            dataView.CellFormatting += (sender, e) =>
            {
                
            if (e.Value != null && e.ColumnIndex == 0 && e.RowIndex >= 0 && dataView[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell)
            {
              
                Image originalImage = (Image)e.Value;
                Image resizedImage = ResizeImage(originalImage, 100, 100);

                // Set the resized image back to the cell
                e.Value = resizedImage;
            }
            };
            add_to_table();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ImagePath = openFileDialog.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product.productID++;
            int _id = Product.productID;
            int price = (int) priceValue.Value;
            int stock = (int)stockValue.Value;
            Product product = new Product(ImagePath, product_name.Text,price,stock,_id);

            Product.productList.Add(product);
            dataView.Rows.Clear();
            add_to_table();

        }
        private Image load_image(String path)
        {
            string imagePath = Path.Combine(Application.StartupPath, "Images", path);
            return Image.FromFile(imagePath);

       }
        private void add_to_table()
        {
            dataView.Rows.Clear();
            foreach (var item in Product.productList)
            {
                if (item != null)
                {
                    Image image;
                    if (item.getProductImage().Contains("/"))
                    {
                        image = Image.FromFile(item.getProductImage());
                    }
                    else
                    {
                        image = load_image(item.getProductImage());
                    }
                    

                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.HeaderText = "";
                    deleteButtonColumn.Text = "Done";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    dataView.Rows.Add(image, item.getProductName(), item.getProductPrice(), item.getProductStack(), deleteButtonColumn);
                }
            }       
        }
        private void dataView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataView.Columns.Count - 1 && e.RowIndex >= 0)
            {
              
                Product productToRemove = Product.productList.Find(p => p.getProductName() == dataView.Rows[e.RowIndex].Cells[1].Value.ToString());
                if (productToRemove != null)
                {
                    Product.productList.Remove(productToRemove);
                    add_to_table(); 
                }
            }
        }
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }

}
