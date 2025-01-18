using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

class PerformanceOptimizer
{
    // Importando funções da API do Windows
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SetPriorityClass(IntPtr hProcess, uint dwPriorityClass);

    [DllImport("kernel32.dll")]
    public extern static IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    // Prioridade de execução (high)
    const uint HIGH_PRIORITY_CLASS = 0x80;

    public static void Main(string[] args)
    {
        Console.WriteLine("Iniciando otimizações...");

        // 1. Alterar o plano de energia para "Alto Desempenho"
        SetHighPerformancePowerPlan();

        // 2. Fechar Programas em Segundo Plano
        CloseBackgroundPrograms();

        // 3. Alterar a Prioridade do Processo do Fortnite
        SetFortniteHighPriority();

        // 4. Desabilitar Efeitos Visuais do Windows
        DisableWindowsVisualEffects();

        // 5. Desabilitar Indexação de Arquivos
        DisableFileIndexing();

        // 6. Habilitar Modo de Jogo
        EnableGameMode();

        // 7. Ajuste de Rede para Melhor Desempenho
        OptimizeNetworkSettings();

        // 8. Otimizações Específicas para Placa de Vídeo AMD
        OptimizeAMDGraphics();

        Console.WriteLine("Otimizações Concluídas.");
    }

    // Função para alterar o plano de energia para "Alto Desempenho"
    public static void SetHighPerformancePowerPlan()
    {
        try
        {
            Console.WriteLine("Alterando plano de energia para 'Alto Desempenho'...");
            Process.Start("powercfg", "/setactive SCHEME_HIGH_PERFORMANCE");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao alterar plano de energia: " + ex.Message);
        }
    }

    // Função para fechar programas desnecessários
    public static void CloseBackgroundPrograms()
    {
        Console.WriteLine("Fechando programas em segundo plano...");
        var processes = Process.GetProcesses();
        foreach (var process in processes)
        {
            try
            {
                // Fechar programas comuns que podem não ser necessários enquanto joga
                if (process.ProcessName != "explorer" && process.ProcessName != "Fortnite" && !process.MainWindowTitle.Contains("Game"))
                {
                    process.Kill();
                    Console.WriteLine($"Fechando {process.ProcessName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fechar {process.ProcessName}: {ex.Message}");
            }
        }
    }

    // Função para alterar a prioridade do processo do Fortnite
    public static void SetFortniteHighPriority()
    {
        try
        {
            Console.WriteLine("Alterando a prioridade do Fortnite para 'Alta'...");
            var fortniteProcesses = Process.GetProcessesByName("FortniteClient-Win64-Shipping"); // Nome do processo do Fortnite
            foreach (var process in fortniteProcesses)
            {
                IntPtr handle = OpenProcess(0x1F0FFF, false, process.Id); // 0x1F0FFF é o código para acesso total ao processo
                SetPriorityClass(handle, HIGH_PRIORITY_CLASS);
                Console.WriteLine($"Prioridade do {process.ProcessName} alterada para alta.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao alterar prioridade do Fortnite: " + ex.Message);
        }
    }

    // Função para desabilitar efeitos visuais do Windows
    public static void DisableWindowsVisualEffects()
    {
        try
        {
            Console.WriteLine("Desabilitando efeitos visuais do Windows...");
            Process.Start("SystemPropertiesPerformance.exe", "/pagefile");
            // A seguir pode-se configurar para desmarcar as opções de efeitos visuais
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao desabilitar efeitos visuais: " + ex.Message);
        }
    }

    // Função para desabilitar a indexação de arquivos
    public static void DisableFileIndexing()
    {
        try
        {
            Console.WriteLine("Desabilitando indexação de arquivos...");
            Process.Start("services.msc");
            // Procurar pelo serviço "Windows Search" e configurá-lo para manual ou desabilitado
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao desabilitar indexação de arquivos: " + ex.Message);
        }
    }

    // Função para habilitar o modo de jogo do Windows
    public static void EnableGameMode()
    {
        try
        {
            Console.WriteLine("Habilitando modo de jogo do Windows...");
            Process.Start("ms-settings:gaming-gameMode");
            // O usuário pode ser direcionado para ativar a opção de "Modo de Jogo"
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao habilitar o Modo de Jogo: " + ex.Message);
        }
    }

    // Função para otimizar configurações de rede
    public static void OptimizeNetworkSettings()
    {
        try
        {
            Console.WriteLine("Otimizar configurações de rede...");
            // Desabilitar a limitação de TCP/UDP e outras configurações de rede
            Process.Start("netsh", "interface tcp set global autotuninglevel=normal");
            Process.Start("netsh", "interface tcp set global rss=enabled");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao otimizar configurações de rede: " + ex.Message);
        }
    }

    // Função para otimizar configurações específicas de placa de vídeo AMD
    public static void OptimizeAMDGraphics()
    {
        try
        {
            Console.WriteLine("Otimizações específicas para placa de vídeo AMD...");

            // Desabilitar V-Sync globalmente
            Process.Start("C:\\Program Files\\AMD\\CNext\\CNext\\RadeonSettings.exe", "-vsync off");
            Console.WriteLine("Desabilitando V-Sync globalmente no driver AMD.");

            // Ativar o Anti-Lag
            Process.Start("C:\\Program Files\\AMD\\CNext\\CNext\\RadeonSettings.exe", "-AntiLag on");
            Console.WriteLine("Ativando o AMD Radeon Anti-Lag.");

            // Configurar o driver para priorizar desempenho
            Process.Start("C:\\Program Files\\AMD\\CNext\\CNext\\RadeonSettings.exe", "-performance");
            Console.WriteLine("Forçando o driver AMD a priorizar desempenho.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao otimizar configurações da placa de vídeo AMD: " + ex.Message);
        }
    }
}
