using System.Text.Json;
using System.Text.RegularExpressions;

namespace Anket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbox_name.Text == string.Empty)
                MessageBox.Show("Name can't be empty");

            if (tbox_surname.Text == string.Empty)
                MessageBox.Show("Surname can't be empty");

            if (tbox_father.Text == string.Empty)
                MessageBox.Show("Father's name can't be empty");

            if (tbox_country.Text == string.Empty)
                MessageBox.Show("Country can't be empty");

            if (tbox_city.Text == string.Empty)
                MessageBox.Show("City can't be empty");

            if (tbox_phone.Text == string.Empty)
                MessageBox.Show("Phone can't be empty");

            if (tbox_phone.Text.ToArray().Count() < 10)
                MessageBox.Show("Phone number can't be less than 10");

            else if (tbox_phone.Text.ToArray().Count() > 10)
                MessageBox.Show("Phone number can't be more than 10");

            if (!(radioButton1.Checked || radioButton2.Checked) )
                MessageBox.Show("Choose Gender");


            string filePath = $"{tbox_name.Text}.json";
            if (File.Exists(filePath))
            {
                MessageBox.Show("File already exists, enter another name");
            }

            var JsonStr = JsonSerializer.Serialize(new Class1(tbox_name.Text,
               tbox_surname.Text, tbox_father.Text, tbox_country.Text, tbox_city.Text,
               tbox_phone.Text, dateTimePicker1.Value, radioButton1.Checked ? Gender.Male : Gender.Female));

            File.WriteAllText(filePath, JsonStr);
            MessageBox.Show("Data Successfully Added");
        }

        private void tbox_name_TextChanged(object sender, EventArgs e)
        {
            if (!tbox_name.Text.All(char.IsLetter))
                MessageBox.Show("Name can't contain digit or symbols");
        }

        private void tbox_surname_TextChanged(object sender, EventArgs e)
        {
            if (!tbox_surname.Text.All(char.IsLetter))
                MessageBox.Show("Surname can't contain digit or symbols");
        }

        private void tbox_father_TextChanged(object sender, EventArgs e)
        {
            if (!tbox_father.Text.All(char.IsLetter))
                MessageBox.Show("Name can't contain digit or symbols");
        }

        private void tbox_country_TextChanged(object sender, EventArgs e)
        {
            if (!tbox_country.Text.All(char.IsLetter))
                MessageBox.Show("Country can't contain digit or symbols");
        }

        private void tbox_city_TextChanged(object sender, EventArgs e)
        {
            if (!tbox_city.Text.All(char.IsLetter))
                MessageBox.Show("City can't contain digit or symbols");
        }

        private void tbox_phone_TextChanged(object sender, EventArgs e)
        {
            if (!tbox_phone.Text.All(char.IsDigit))
                MessageBox.Show("Phone can't contain letters or symbols");
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string filePath = $"{textBox1.Text}.json";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No credentials exist");
                return;
            }

            var readJsonStr = File.ReadAllText(filePath);
            Class1? clas = JsonSerializer.Deserialize<Class1>(readJsonStr) ?? null;

            if (clas == null)
            {
                MessageBox.Show("No data exists");
                return;
            }

            tbox_name.Text = clas.Name;
            tbox_surname.Text = clas.Surname;
            tbox_father.Text = clas.FatherName;

            tbox_country.Text = clas.Country;
            tbox_city.Text = clas.City;
            tbox_phone.Text = clas.PhoneNumber;
            dateTimePicker1.Value = clas.BirthDate;


            if (clas.Gender == Gender.Male)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            MessageBox.Show("Data Successfully Loaded");
        }
    }
}