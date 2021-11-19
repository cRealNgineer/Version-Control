using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            btnAdd.Text = Resource1.Add;
            lblFllName.Text = Resource1.FullName;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User u = new User();
            //u.LastName = txtLastName.Text;
            //u.FirstName = txtFirstName.Text;
            u.FullName = txtFullName.Text;
            users.Add(u);
        }
    }
}
