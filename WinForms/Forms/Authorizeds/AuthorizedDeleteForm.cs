﻿using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.Entity_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms.Forms.Authorized
{
    public partial class AuthorizedDeleteForm : Form
    {
        public AuthorizedDeleteForm()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void headerpnl_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void headerpnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void headerpnl_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AuthorizedManager manager = new AuthorizedManager(new EfAuthorizedDAL());
                manager.Delete(new Entities.Concrete.Authorized { IdentificationNumber = Convert.ToInt32(notxb.Text) });
                MessageBox.Show(Messages.DeleteSuccess);

                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tbox = (TextBox)item;
                        tbox.Clear();
                    }
                }
            }
            catch
            {

                MessageBox.Show(Messages.Error);
            }



        }
        public string no, name, surname, salary, datestart, dateout;

        private void headerpnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AuthorizedDeleteForm_Load(object sender, EventArgs e)
        {
            notxb.Text = no;
            nametxb.Text = name;
            surnametxb.Text = surname;
            salarytxb.Text = salary;
            dateofstarttxb.Text = datestart;
            dateofouttxb.Text = dateout;
        }
    }
}
