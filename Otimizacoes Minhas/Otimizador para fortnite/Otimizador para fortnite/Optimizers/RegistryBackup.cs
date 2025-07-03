using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class RegistryBackup
    {
        public static void Backup(string backupPath = "reg_backup.reg")
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = $"export HKCU {backupPath} /y",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine($"Backup do registro salvo em {backupPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fazer backup do registro: " + ex.Message);
            }
        }
        public static void Restore(string backupPath = "reg_backup.reg")
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = $"import {backupPath}",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine($"Registro restaurado de {backupPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao restaurar o registro: " + ex.Message);
            }
        }
    }
}
