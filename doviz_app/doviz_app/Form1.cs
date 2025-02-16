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
            LblDolarAlış.Text = dolarAlis;

            string dolarSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarSatış.Text = dolarSatis;

            string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroAlış.Text = euroAlis;

            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSatış.Text = euroSatis;
        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblDolarAlış.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblEuroSatış.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblEuroAlış.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            Txt_Kur.Text = LblEuroSatış.Text;
            Txt_Tutar.Text = "";
            Txt_Miktar.Text = "";
            Txt_Kalan.Text = "";
        }

        private void Btn_Satış_Click(object sender, EventArgs e)
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

        private void Btn_Satış2_Click(object sender, EventArgs e)
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
