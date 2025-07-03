using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class DriverChecker
    {
        public static void CheckDrivers()
        {
            try
            {
                Process.Start("devmgmt.msc");
                Console.WriteLine("Verifique se todos os drivers estão atualizados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir Gerenciador de Dispositivos: " + ex.Message);
            }
        }
    }
}
