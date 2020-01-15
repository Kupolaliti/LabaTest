using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace Laba1
{
    public partial class Form4lab : Form
    {
        public Form4lab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Получить все значения
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64195/");
                HttpResponseMessage response = client.GetAsync("api/products").Result;
                var setting = response.Content.ReadAsAsync<IEnumerable<Settings>>().Result;
                serviceGrid.DataSource = setting;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Добавить
        {
            try
            {
                AddProduct(textBox2.Text, textBox3.Text);
                MessageBox.Show("Успешно добавлено! :3");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AddProduct(string name, string val)
        {
            Settings s = new Settings();
            s.Name = name;
            s.Value = val;
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(s);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:64195/api/products", content);
            };
        }

        private async void DeleteProduct(int delid)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync(String.Format("{0}/{1}", "http://localhost:64195/api/products", delid));
            }
        }

        private void button3_Click(object sender, EventArgs e) //Удалить
        {
            try
            {
                DeleteProduct(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("Успешно удалено! :3");
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) //Загрузить ини
        {
            IniFile ini = new IniFile("my.ini");
            int height = Convert.ToInt32(ini.Read("height"));
            int width = Convert.ToInt32(ini.Read("width"));
            int opacity = Convert.ToInt32(ini.Read("opacity"));
            int locX = Convert.ToInt32(ini.Read("locX"));
            int locY = Convert.ToInt32(ini.Read("locY"));
            AddProduct("height", Convert.ToString(height));
            AddProduct("width", Convert.ToString(width));
            AddProduct("opacity", Convert.ToString(opacity));
            AddProduct("locX", Convert.ToString(locX));
            AddProduct("locY", Convert.ToString(locY));
        }
    }
}
