using tpmodul8_1302210006;

CovidConfig_1302210006 con = new CovidConfig_1302210006();
con.UbahSatuan();

Console.WriteLine("Berapa suhu badan anda saat ini?" + " " + con.config.satuan_suhu);
string suhuBadan = Console.ReadLine();
int suhu = (int)Convert.ToInt32(suhuBadan);

Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
string hariDemam = Console.ReadLine();
int hari = (int)Convert.ToInt32(hariDemam);

if (con.config.satuan_suhu == "celcius")
{
    if (suhu > 37.5)
    {
        if (hari > con.config.batas_hari_deman)
        {
            Console.WriteLine(con.config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(con.config.pesan_diterima);
        }
    }
    else {
        Console.WriteLine(con.config.pesan_diterima);
    }
} else if(con.config.satuan_suhu == "fanreinheit")
{
    if (suhu > 99.5)
    {
        if (hari > con.config.batas_hari_deman)
        {
            Console.WriteLine(con.config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(con.config.pesan_diterima);
        }
    }
    else {
        Console.WriteLine(con.config.pesan_diterima);
    }
}

