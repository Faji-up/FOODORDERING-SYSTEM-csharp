﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrderingSystem
{
    public partial class HistoryFrame : Form
    {
        public HistoryFrame()
        {
            InitializeComponent();
            add_row();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == dataView.Columns.Count - 1 && e.RowIndex >= 0)
            {

               
                foreach(var item in Order.orderList)
                {
                    if(item.get_customer_name().ToString() == dataView.Rows[e.RowIndex].Cells[1].Value.ToString())
                    {
                        Order.orderList.Remove(item);
                        add_row();
                    }
                }
               
            }
        }
        private void add_row()
        {
            dataView.Rows.Clear();
            if(Order.orderList.Count > 0 )
            {
                foreach (var item in Order.orderList)
                {
                    if (item != null)
                    {
                        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                        deleteButtonColumn.HeaderText = "";
                        deleteButtonColumn.Text = "Delete";
                        deleteButtonColumn.UseColumnTextForButtonValue = true;

                        dataView.Rows.Add(item.get_datetime(), item.get_customer_name(), item.getTotalItem(), item.getTotalPrice(), deleteButtonColumn);

                    }

                }
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            OderFrame oderFrame  = new OderFrame();
            oderFrame.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        private void HistoryFrame_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryFrame inventoryFrame = new InventoryFrame();
            inventoryFrame.ShowDialog();
        }
    }
}
