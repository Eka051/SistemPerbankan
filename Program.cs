using SistemPerbankan;
using System;
class Program
{
    public static void Main(string[] args)
    {
        RekeningTabungan tabungan = new RekeningTabungan("Dian Eka Raharjo", "232410102004", 250000, 0.005m);
        tabungan.CekSaldo();
        tabungan.Setor();
        tabungan.HitungBunga();

        RekeningGiro giro = new RekeningGiro("Edwin", "232410102045", 120000, 500000);
        giro.CekSaldo();
        giro.TarikSaldo();
        giro.Setor();
        giro.TarikSaldo();
        Console.ReadKey();
    }
}