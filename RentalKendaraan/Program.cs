List<Kendaraan> data_Kendaraan = new List<Kendaraan>()
{
    new Kendaraan("Beat", 125000, "B 5431 A"),
    new Kendaraan("Vario", 150000, "D 6542 C"),
    new Mobil("Civic", 500000, "F 7653 E"),
    new Mobil("Pajero", 100000, "H 8764 G"),
    new MiniBus("Elf", 800000, "J 9875 I"),
    new MiniBus("HiAce", 600000, "L 1086 K"),
};
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
        Console.WriteLine($"Nama Kendaraan: {_namaKendaraan}");
        Console.WriteLine($"Harga Sewa PerHari: {_hargaSewaPerHari}");
        Console.WriteLine($"Nomor Polisi: {_nomorPolisi}");
        Console.WriteLine($"Ketersediaan: {(_isAvailable? "Tersedia" : "Tidak Tersedia")}");
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

