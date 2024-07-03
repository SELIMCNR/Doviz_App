using System.Xml;

namespace doviz_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
        private void Form1_Load(object sender, EventArgs e)
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(bugun);

            string dolarAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolarAl��.Text = dolarAlis;

            string dolarSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarSat��.Text = dolarSatis;

            string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroAl��.Text = euroAlis;

            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSat��.Text = euroSatis;
        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblDolarAl��.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblEuroSat��.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblEuroAl��.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblEuroSat��.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void Btn_Sat��_Click(object sender, EventArgs e)
        {

            double kur, miktar, tutar;
            kur = Convert.ToDouble(Txt_Kur.Text);
            miktar = Convert.ToDouble(Txt_Miktar.Text);
            tutar = kur * miktar;
            Txt_Tutar.Text = tutar.ToString();
            Txt_Kalan.Text = "";


        }

        private void Txt_Kur_TextChanged(object sender, EventArgs e)
        {
            Txt_Kur.Text = Txt_Kur.Text.Replace(".", ",");

        }

        private void Btn_Sat��2_Click(object sender, EventArgs e)
        {
           
            double kur = Convert.ToDouble(Txt_Kur.Text);
            int miktar = Convert.ToInt32(Txt_Miktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            Txt_Tutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            Txt_Kalan.Text = kalan.ToString();
        }
    }
}
