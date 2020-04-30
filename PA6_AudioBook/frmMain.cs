using System;
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
    public partial class frmMain : Form
    {
        // class variables
        string cwid;
        List<Book> myBooks;

        // constructor
        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // reloads the list of books
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        // reloads list of books
        private void LoadList() 
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        // closes app
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // sets txt data equal to myBook data
        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtIsbnData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            try 
            {
                pbCover.Load(myBook.cover);
            }
            catch 
            {
            
            }
        }

        // user clicks rent
        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        // user clicks return
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        // user clicks delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }
        }

        // user clicks edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else 
            {
                LoadList();
            }
        }

        // user clicks new
        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book();
            frmEdit myForm = new frmEdit(myBook, "new", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}
