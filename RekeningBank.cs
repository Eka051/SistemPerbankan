using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPerbankan
{
    public class RekeningBank
    {
        public string namaNasabah, nomorRekening;
        public decimal saldo;
        public RekeningBank(string namaNasabah, string nomorRekening, decimal saldo)
        {
            this.namaNasabah = namaNasabah;
            this.nomorRekening = nomorRekening;
            this.saldo = saldo;
        }
        public virtual void TarikSaldo()
        {
            Console.Write("Masukkan Jumlah Penarikan : ");
            decimal jumlah = decimal.Parse(Console.ReadLine());
            if (jumlah < saldo)
            {
                saldo -= jumlah;
                Console.WriteLine($"Penarikan sebesar Rp.{jumlah} Berhasil. Sisa saldo Rp.{saldo}");
            }
            else if (jumlah == 0 && jumlah < 0)
            {
                Console.WriteLine("Penarikan INVALID. Masukkan nominal yang benar!");
            }
            else
            {
                Console.WriteLine("Penarikan GAGAL. Saldo tidak cukup");
            }
        }
        public virtual void Setor()
        {
            Console.Write("Masukkan Jumlah Setoran : ");
            decimal jumlah = decimal.Parse(Console.ReadLine());
            saldo += jumlah;
            Console.WriteLine($"Setoran berhasil. Total saldo sekarang Rp.{saldo}");

        }
        public virtual void CekSaldo()
        {
            Console.WriteLine("Rekening Tabungan");
            this.Info();
            Console.WriteLine($"Saldo saat ini : Rp.{saldo}");
        }
        public void Info()
        {
            Console.WriteLine($"Nama Nasabah : {namaNasabah}"
                + $"\nNomor Rekening : {nomorRekening}");
        }
        
    }

    public class RekeningTabungan : RekeningBank
    {
        public decimal bunga;
        public RekeningTabungan(string namaNasabah, string nomorRekening, decimal saldo, decimal bunga) : base(namaNasabah, nomorRekening, saldo)
        {
            this.bunga = bunga;
        }

        public void HitungBunga()
        {
            saldo += saldo * 0.005m;
            Console.WriteLine($"Bunga bulanan {saldo * 0.005m} berhasil ditambahkan. Saldo sekarang Rp.{saldo}");
        }
        public override void TarikSaldo()
        {
            base.TarikSaldo();
        }
        public override void Setor()
        {
            base.Setor();
        }
        public override void CekSaldo()
        {
            base.CekSaldo();
        }
    }

    public class RekeningGiro : RekeningBank
    {
        public decimal batasSaldo;
        public RekeningGiro(string namaNasabah, string nomorRekening, decimal saldo, decimal batasSaldo) : base(namaNasabah, nomorRekening, saldo)
        {
            this.batasSaldo = batasSaldo;
        }
        public override void TarikSaldo()
        {
            Console.Write("Masukkan Jumlah Penarikan Giro : ");
            decimal jumlah = decimal.Parse(Console.ReadLine());
            if (saldo < batasSaldo)
            {
                Console.WriteLine("Penarikan GAGAL karena belum melebihi batas saldo!");
            }
            else if (jumlah == 0)
            {
                Console.WriteLine("Nominal INVALID!");
            }
            else
            {
                saldo -= jumlah;
                Console.WriteLine($"Penarikan sebesar Rp.{jumlah} BERHASIL. Sisa saldo Rp.{saldo}");
            }
        }
        public override void CekSaldo()
        {
            Console.WriteLine("\nRekening Giro");
            base.CekSaldo();
        }
    }
}
