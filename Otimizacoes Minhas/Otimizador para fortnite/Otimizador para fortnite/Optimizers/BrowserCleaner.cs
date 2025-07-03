using System;
using System.IO;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class BrowserCleaner
    {
        public static void CleanCache()
        {
            string logPath = "otimizador_log.txt";
            void Log(string msg)
            {
                File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {msg}\n");
            }
            try
            {
                // Chrome
                string chromeCache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data", "Default", "Cache");
                if (Directory.Exists(chromeCache))
                {
                    Directory.Delete(chromeCache, true);
                    Console.WriteLine("Cache do Chrome limpo.");
                    Log("Cache do Chrome limpo.");
                }
                // Edge
                string edgeCache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Edge", "User Data", "Default", "Cache");
                if (Directory.Exists(edgeCache))
                {
                    Directory.Delete(edgeCache, true);
                    Console.WriteLine("Cache do Edge limpo.");
                    Log("Cache do Edge limpo.");
                }
                // Firefox
                string firefoxPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla", "Firefox", "Profiles");
                if (Directory.Exists(firefoxPath))
                {
                    foreach (var dir in Directory.GetDirectories(firefoxPath))
                    {
                        string cache2 = Path.Combine(dir, "cache2");
                        if (Directory.Exists(cache2))
                        {
                            Directory.Delete(cache2, true);
                            Console.WriteLine($"Cache do Firefox limpo em {dir}.");
                            Log($"Cache do Firefox limpo em {dir}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao limpar cache dos navegadores: " + ex.Message);
                Log($"Erro ao limpar cache dos navegadores: {ex.Message}");
            }
        }
    }
}
