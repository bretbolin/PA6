﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6_AudioBook
{
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;

        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book)tempBook;
            mode = tempMode;
            cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if (mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtLengthData.Text = myBook.length.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;

                pbCover.Load(myBook.cover);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            MessageBox.Show("Content was saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
