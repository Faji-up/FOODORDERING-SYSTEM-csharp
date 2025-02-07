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
    public partial class SignupFrame : Form
    {
        public SignupFrame()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignupFrame_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String username = usernameText.Text;
            String password = passwordText.Text;
            String confirmPassword = confirmPasswordText.Text;

            if((username == "" &&  password == "" &&  confirmPassword == "") || (password != confirmPassword))
            {
                MessageBox.Show("Error","Please Check Your Username and Password");
            }
            else
            {
                User user = new User();
                user.username = username;
                user.Password  = password;

                User.users[User.userIndex] = user;
                User.userIndex++;
                MessageBox.Show("Successfull", "Account Registered Successfully");
                usernameText.Text = "";
                passwordText.Text = "";
                confirmPasswordText.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFrame loginFrame = new LoginFrame();
            loginFrame.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void showHide_Click(object sender, EventArgs e)
        {
            if (showHide2.Text == "Show")
            {
                confirmPasswordText.PasswordChar = '\0';
                showHide2.Text = "Hide";
            }
            else
            {
                confirmPasswordText.PasswordChar = '*';
                showHide2.Text = "Show";
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (showHide1.Text == "Show")
            {
                passwordText.PasswordChar = '\0';
                showHide1.Text = "Hide";
            }
            else
            {
                passwordText.PasswordChar = '*';
                showHide1.Text = "Show";
            }
        }
    }
}
