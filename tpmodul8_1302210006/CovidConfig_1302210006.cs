using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302210006
{

    internal class CovidConfig_1302210006
    {
        public appConfig_1302210006 config;
        public const string cFile = @"covid_config.json";

        public CovidConfig_1302210006()
        {
            try
            {
                ReadConfigFile_1302210006();
                Console.WriteLine("Membaca config file JSON");
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("Membuat config file default");
                setDefault_1302210006();
                WriteConfig_1302210006();
            }
        }

        public void ReadConfigFile_1302210006()
        {
            string jsontxt = File.ReadAllText(cFile);
            config = JsonSerializer.Deserialize<appConfig_1302210006>(jsontxt);
        }
        public void WriteConfig_1302210006()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonText = JsonSerializer.Serialize(config, options);
            File.WriteAllText(cFile, jsonText);
        }

        public void setDefault_1302210006()
        {
            config = new appConfig_1302210006();
            config.satuan_suhu = "celcius";
            config.batas_hari_deman = 14;
            config.pesan_ditolak = "Anda tidak diperbolehkan masuk kedalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk kedalam gedung ini";
        }


        public void UbahSatuan()
        {
            string ressRead = File.ReadAllText(cFile);
            config = JsonSerializer.Deserialize<appConfig_1302210006>(ressRead);

            if (config.satuan_suhu.Contains("celcius"))
            {
                config.satuan_suhu = "fanrenheit";
            }
            else if (config.satuan_suhu.Contains("fanrenheit"))
            {
                config.satuan_suhu = "celcius";
            }

            string newJsonTxt = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(cFile, newJsonTxt);
        }

    }

    public class appConfig_1302210006
    {
        public string satuan_suhu { set; get; }
        public int batas_hari_deman { set; get; }
        public string pesan_ditolak { set; get; }
        public string pesan_diterima { set; get; }

        public appConfig_1302210006() { }
        public appConfig_1302210006(string satuan_suhu, int batas_hari_deman, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_deman = batas_hari_deman;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }

    
}
