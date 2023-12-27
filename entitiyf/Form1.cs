using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entitiyf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PersoneloEntities ent = new PersoneloEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Tbl_Personel.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Personel perso = new Tbl_Personel();
            perso.PerAd = txtAd.Text;
            perso.PerSoyad = txtSoyad.Text;
            perso.PerSehir = txtSehir.Text;
            perso.PerMaas = Convert.ToInt16(txtMaas.Text);
            ent.Tbl_Personel.Add(perso);
            ent.SaveChanges();
            MessageBox.Show("Personel Sisteme Kaydedildi");
            dataGridView1.DataSource = ent.Tbl_Personel.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtId.Text);
            Tbl_Personel per = ent.Tbl_Personel.First(f => f.Perid == id);
            ent.Tbl_Personel.Remove(per);
            ent.SaveChanges();
            MessageBox.Show("Personel Silindi");
            dataGridView1.DataSource = ent.Tbl_Personel.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtId.Text);
            Tbl_Personel tbl = ent.Tbl_Personel.First(f => f.Perid == id);
            tbl.PerAd = txtAd.Text;
            tbl.PerSoyad = txtSoyad.Text;
            ent.SaveChanges();
            MessageBox.Show("Personel Güncellendi");
            dataGridView1.DataSource = ent.Tbl_Personel.ToList();
        }

        
    }
}
