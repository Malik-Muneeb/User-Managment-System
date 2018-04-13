using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Management_System
{
    public partial class newUserForm : Form
    {
        public newUserForm()
        {
            InitializeComponent();
        }

        private void newUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var result = userPicDialog.ShowDialog();
            if(result==System.Windows.Forms.DialogResult.OK)
            {
                var filePath = userPicDialog.FileName;
                userPicBox.Image = Image.FromFile(filePath);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            user userObj=new user();
            userObj.name=txtName.Text.Trim();
            userObj.login = txtLogin.Text.Trim();
            userObj.password = txtPassowrd.Text.Trim();
            userObj.email = txtEmail.Text.Trim();
            userObj.gender = cmbGender.SelectedIndex.ToString();
            userObj.address = txtAddress.Text.Trim();
            userObj.age = Convert.ToInt32(upDownAge.Value);
            userObj.nic = mTxtNic.Text.Trim();
            userObj.dob = Convert.ToDateTime(dtDob.Value);
            userObj.isCricket = (chkCricket.Checked == true ? '1' : '0');
            userObj.isHockey = (chkHockey.Checked == true ? '1' : '0');
            userObj.isChess = (chkChess.Checked == true ? '1' : '0');
            userObj.imageName = saveImage();
            new userDAO().save(userObj);
        }


        private String saveImage()
        {
            if (userPicBox.Image != null)
            {
                String imageName;
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                String pathToSaveImage = applicationBasePath + @"\image\";
                imageName = Guid.NewGuid().ToString() + ".jpg";
                String imagePath = pathToSaveImage + imageName;
                userPicBox.Image.Save(imagePath);
                return imageName;
            }
            return null;
        }
        private void newUserForm_Load(object sender, EventArgs e)
        {
            String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.Directory.CreateDirectory(applicationBasePath + @"\image\");
        }

        
    }
}
