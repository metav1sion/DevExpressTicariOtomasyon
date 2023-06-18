using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            string servername = "DESKTOP-JTNUQFE\\SQLEXPRESS"; //Eğer uygulamamı çalıştırmak istiyorsanız, buraya kendi database isminizi yazınız.
            string databasename = "DboTicariOtomasyon"; //Buraya ise dosyanın içinde yolladığım .bac uzantılı veritabanını yükledikten sonra veritabanının ismini yazınız.
            SqlConnection baglan = new SqlConnection(@"Data Source=" + servername + ";Initial Catalog=" + databasename + ";Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
