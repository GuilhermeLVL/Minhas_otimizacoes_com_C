using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class DiskTweaks
    {
        public static void Apply()
        {
            // Desfragmentar HDD (não SSD)
            try
            {
                Process.Start("dfrgui.exe");
                System.Console.WriteLine("Desfragmente o disco rígido (HDD) manualmente. Não recomendado para SSD.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Erro ao abrir desfragmentador: " + ex.Message);
            }
            // Instrução para desabilitar indexação/compressão
            System.Console.WriteLine("Desabilite indexação e compressão nas propriedades da pasta do jogo.");
        }
    }
}
