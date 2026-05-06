List<Kendaraan> data_Kendaraan = new List<Kendaraan>()
{
    new Kendaraan("Beat", 125000, "B 5431 A"),
    new Kendaraan("Vario", 150000, "D 6542 C"),
    new Mobil("Civic", 500000, "F 7653 E"),
    new Mobil("Pajero", 100000, "H 8764 G"),
    new MiniBus("Elf", 800000, "J 9875 I"),
    new MiniBus("HiAce", 600000, "L 1086 K"),
};

while (true)
{
    Console.Clear();

    Console.WriteLine("-----Rental Kendaraan-----");
    Console.WriteLine("\nDaftar Kendaraan");

    foreach (var dk in data_Kendaraan)
    {
        dk.tampilkanInfo();
    }

    Console.WriteLine("\nPilih Menu");
    Console.WriteLine("1.Sewa \n2.Kembali \n3.Keluar");
    Console.WriteLine("Pilihan Anda: ");
    string pilihan = Console.ReadLine();

    if (pilihan == "1")
    {
        Console.Write("Masukkan nama kendaraan:");
        string nama_kendaraan = Console.ReadLine();

        var cari_kendaraan = data_Kendaraan.FirstOrDefault(ck => string.Equals(ck.NamaKendaraan, nama_kendaraan, StringComparison.OrdinalIgnoreCase));

        if (cari_kendaraan == null)
        {
            Console.WriteLine("Kendaraan tidak ditemukan");
        }
        else if (cari_kendaraan.IsAvailable)
        {
            Console.Write("Input jumlah hari sewa:");
            int hari = int.Parse(Console.ReadLine());

            cari_kendaraan.hitungTotal(hari);

            double total_sewa = cari_kendaraan.hitungTotal(hari);

            cari_kendaraan.ubahStatus();

            Console.WriteLine($"Total pembayaran sewa: Rp {total_sewa}");
        }
        else
        {
            Console.WriteLine("Kendaraan Tidak Tersedia!!");
        }

    }
    else if (pilihan == "2")
    {
        Console.Write("\nInput nama kendaraan: ");
        string namaKendaraan = Console.ReadLine();

        var cari_kendaran = data_Kendaraan.FirstOrDefault(ck => string.Equals(namaKendaraan, ck.NamaKendaraan, StringComparison.OrdinalIgnoreCase));

        if (cari_kendaran == null)
        {
            Console.WriteLine("\nKendaraan tidak ditemukan");
        }
        else if (!cari_kendaran.IsAvailable)
        {
            cari_kendaran.ubahStatus();
            Console.WriteLine("\nKendaraan berhasil dikembalikan");
        }
        else
        {
            Console.WriteLine("\nProses pengembalian tidak bisa dilakukan");
        }
    }
    else if (pilihan == "3")
    {
        Console.WriteLine("\nTekan ENTER untuuk menutup aplikasi...");
        Console.ReadLine();
        break;
    }
    else
    {
        Console.WriteLine("\nPilihan Invalid");
    }

    Console.WriteLine("\nTekan ENTER untuk mengulang");
    Console.ReadLine() ;
}
    class Kendaraan
{
    protected string _namaKendaraan;
    protected double _hargaSewaPerHari;
    protected string _nomorPolisi;
    protected bool _isAvailable;

    public Kendaraan(string nama_kendaraan, double harga_sewa, string nomor_polisi)
    {
        _namaKendaraan = nama_kendaraan;
        _hargaSewaPerHari = harga_sewa;
        _nomorPolisi = nomor_polisi;
        _isAvailable = true;
    }

    public string NamaKendaraan
    {
        get { return _namaKendaraan; }
        set { _namaKendaraan = value; }
    }
    public double HargaSewaPerHari
    {
        get { return _hargaSewaPerHari; }
        set
        {
            if (value > 0)
            {
                _hargaSewaPerHari = value;
            }
            else
            {
                Console.WriteLine("Harga Sewa Harus Lebih Besar Dari 0.");
            }
        }
    }
    public string NomorPolisi
    {
        get { return _nomorPolisi; }
    }
    public bool IsAvailable
    {
        get { return _isAvailable; }
    }

    public void tampilkanInfo()
    {
        //Console.WriteLine($"Nama Kendaraan: {_namaKendaraan}");
        //Console.WriteLine($"Harga Sewa PerHari: {_hargaSewaPerHari}");
        //Console.WriteLine($"Nomor Polisi: {_nomorPolisi}");
        //Console.WriteLine($"Ketersediaan: {(_isAvailable? "Tersedia" : "Tidak Tersedia")}");

        Console.WriteLine($"{_namaKendaraan} | {_nomorPolisi} | Rp {_hargaSewaPerHari} / hari | {(_isAvailable ? "Tersedia" : "Tidak tersedia")} ");
    }

    public void ubahStatus()
    {
        _isAvailable = !_isAvailable;
    }

    public virtual double hitungTotal(int jumlahHari)
    {
        return _hargaSewaPerHari * jumlahHari;
    }
}

class Mobil : Kendaraan
{
    private double _biayaAsuransi;
    public Mobil(string nama_kendaraan, double harga_sewa, string nomor_polisi) : base(nama_kendaraan, harga_sewa, nomor_polisi)
    {
        _hargaSewaPerHari += 50000;
    }
    public override double hitungTotal(int jumlahHari)
    {
        return base.hitungTotal(jumlahHari) + _biayaAsuransi;
    }
}
class MiniBus : Kendaraan
{
    private double _biayaSopir;
    public MiniBus(string nama_kendaraan, double harga_sewa, string nomor_polisi) : base(nama_kendaraan, harga_sewa, nomor_polisi)
    {
        _biayaSopir += 1000000;
    }
    public override double hitungTotal(int jumlahHari)
    {
        return base.hitungTotal(jumlahHari) + _biayaSopir * jumlahHari;
    }
}

