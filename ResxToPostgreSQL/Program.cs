// See https://aka.ms/new-console-template for more information
using Npgsql;
using System.Configuration;
using System.Xml;

public class Program
{
    private static void Main(string[] args)
    {

        // PostgreSQL bağlantı dizesini alın
        string connectionString = ConfigurationManager.ConnectionStrings["RootEFConnection"].ConnectionString;


        // Veritabanı bağlantısı
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // Verileri ekleme
            string sql = "INSERT INTO \"NEMS_COMMON\".\"MENU_RESOURCES\" (\"KEY\", \"VALUE\" , \"LANGUAGE_KEY\", \"TENANT_ID\" ) VALUES (@key, @value , 'default' , 1)";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                // Language.resx dosyasını okuma
                var doc = new XmlDocument();
                doc.Load(@"D:\Dev\Git\onent\onent_core\spa\Resources\Language.resx");
                XmlNodeList dataNodes = doc.SelectNodes("//data");

                foreach (XmlNode dataNode in dataNodes)
                {
                    string key = dataNode.Attributes["name"].Value;
                    string value = dataNode.SelectSingleNode("value").InnerText;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@KEY", key);
                    command.Parameters.AddWithValue("@VALUE", value);

                    command.ExecuteNonQuery();
                }
            }

            // Veritabanı bağlantısını kapatma
            connection.Close();
        }


        // Veritabanı bağlantısı
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // Verileri ekleme
            string sql = "INSERT INTO \"NEMS_COMMON\".\"MENU_RESOURCES\" (\"KEY\", \"VALUE\" , \"LANGUAGE_KEY\", \"TENANT_ID\" ) VALUES (@key, @value , 'tr' , 1)";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                // Language.resx dosyasını okuma
                var doc = new XmlDocument();
                doc.Load(@"D:\Dev\Git\onent\onent_core\spa\Resources\Language.tr-TR.resx");
                XmlNodeList dataNodes = doc.SelectNodes("//data");

                foreach (XmlNode dataNode in dataNodes)
                {
                    string key = dataNode.Attributes["name"].Value;
                    string value = dataNode.SelectSingleNode("value").InnerText;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@KEY", key);
                    command.Parameters.AddWithValue("@VALUE", value);

                    command.ExecuteNonQuery();
                }
            }

            // Veritabanı bağlantısını kapatma
            connection.Close();
        }
    }
}