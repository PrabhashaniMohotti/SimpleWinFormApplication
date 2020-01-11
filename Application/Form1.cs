using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var firstName = textBoxFName.Text;
            var lastName = textBoxLName.Text;

            byte[] data = FormatInputData(firstName, lastName);
            string savedFilePath = SaveInputData(data);

            label1.Text = "Data saved directory path:  " + savedFilePath;
            textBoxFName.Text = "";
            textBoxLName.Text = "";
        }

        private byte[] FormatInputData(string firstName, string lastName)
        {
            var fName = "Your first name: " + firstName + "\n";
            var lName = "Your last name: " + lastName;

            return Encoding.ASCII.GetBytes(fName + lName);
        }

        private string SaveInputData(byte[] dataByteArray)
        {
            string rootPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            string filePath = string.Empty;

            try
            {
                if (Directory.Exists(rootPath))
                {
                    rootPath += "TemporyFiles";
                    if (!Directory.Exists(rootPath))
                    {
                        Directory.CreateDirectory(rootPath);
                    }

                    string fileName = @"\Text.txt";
                    filePath = rootPath + fileName;
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Close();
                    }

                    File.WriteAllBytes(filePath, dataByteArray);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }
    }
}
