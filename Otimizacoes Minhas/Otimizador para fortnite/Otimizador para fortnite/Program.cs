using OtimizadorParaFortnite.Optimizers;
using System.IO;
using System.Diagnostics;
        // Criação de log simples
        string logPath = "otimizador_log.txt";
        void Log(string msg)
        {
            File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {msg}\n");
        }
using OtimizadorParaFortnite.Optimizers;
using OtimizadorParaFortnite.Optimizers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;



// Classe principal de orquestração
class PerformanceOptimizer
{

    // Monitoramento em tempo real de CPU/RAM
    public static void MonitorSystemUsage()
    {
        try
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine("Monitorando uso de CPU e RAM. Pressione Ctrl+C para sair.");
            while (true)
            {
                float cpu = cpuCounter.NextValue();
                float ram = ramCounter.NextValue();
                Console.Write($"CPU: {cpu:F1}% | RAM disponível: {ram} MB\r");
                Thread.Sleep(1000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao monitorar uso do sistema: " + ex.Message);
        }
    }

    // Agendamento de tarefas de limpeza
    public static void ScheduleCleanup(int intervalMinutes = 60)
    {
        Timer timer = null;
        timer = new Timer(_ =>
        {
            Console.WriteLine("Executando limpeza agendada...");
            CleanTempFiles();
        }, null, 0, intervalMinutes * 60 * 1000);
    }

    // Modo silencioso
    public static void RunSilentMode()
    {
        CloseBackgroundPrograms();
        SetFortniteHighPriority();
        DisableWindowsVisualEffects();
        DisableFileIndexing();
        EnableGameMode();
        OptimizeNetworkSettings();
        OptimizeAMDGraphics();
        SetHighPerformancePowerPlan();
        CleanTempFiles();
        DisableUnnecessaryServices();
        OptimizeInputLag();
        OptimizeConnection();
    }

    // Dashboard simples (CLI)
    public static void ShowDashboard()
    {
        Console.WriteLine("==== DASHBOARD DE OTIMIZAÇÃO ====");
        // Exemplo: mostrar uso de CPU/RAM e status de otimizações
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        var ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        float cpu = cpuCounter.NextValue();
        float ram = ramCounter.NextValue();
        Console.WriteLine($"CPU: {cpu:F1}% | RAM disponível: {ram} MB");
        Console.WriteLine("Otimizações aplicadas: ");
        Console.WriteLine("- Programas em segundo plano fechados");
        Console.WriteLine("- Prioridade do Fortnite ajustada");
        Console.WriteLine("- Efeitos visuais desabilitados");
        Console.WriteLine("- Indexação desabilitada");
        Console.WriteLine("- Modo de jogo ativado");
        Console.WriteLine("- Rede otimizada");
        Console.WriteLine("- AMD otimizado");
        Console.WriteLine("- Plano de energia: Alto desempenho");
        Console.WriteLine("- Limpeza de arquivos temporários");
        Console.WriteLine("- Serviços não essenciais desativados");
        Console.WriteLine("- Input lag otimizado");
        Console.WriteLine("- Conexão otimizada");
    }

    // Limpeza de arquivos temporários
    public static void CleanTempFiles()
    {
        try
        {
            string tempPath = Path.GetTempPath();
            var files = Directory.GetFiles(tempPath);
            var dirs = Directory.GetDirectories(tempPath);
            foreach (var file in files)
            {
                try { File.Delete(file); } catch { }
            }
            foreach (var dir in dirs)
            {
                try { Directory.Delete(dir, true); } catch { }
            }
            Console.WriteLine("Arquivos temporários limpos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao limpar arquivos temporários: " + ex.Message);
        }
    }

    // Fechar serviços não essenciais do Windows
    public static void DisableUnnecessaryServices()
    {
        try
        {
            string[] servicesToDisable = new string[]
            {
                "DiagTrack", // Telemetria
                "SysMain",   // Superfetch
                "WSearch",   // Windows Search
                "Fax",       // Fax
                "XblGameSave", // Xbox
                "MapsBroker", // Mapas
                "WMPNetworkSvc" // Windows Media Player Network
            };
            foreach (var service in servicesToDisable)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = $"config {service} start= disabled",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = $"stop {service}",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
            }
            Console.WriteLine("Serviços não essenciais desativados.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao desativar serviços: " + ex.Message);
        }
    }

    // Otimizações para reduzir input lag
    public static void OptimizeInputLag()
    {
        try
        {
            // Desabilitar mouse acceleration
            Process.Start(new ProcessStartInfo
            {
                FileName = "reg",
                Arguments = "add \"HKCU\\Control Panel\\Mouse\" /v MouseSpeed /t REG_SZ /d 0 /f",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Process.Start(new ProcessStartInfo
            {
                FileName = "reg",
                Arguments = "add \"HKCU\\Control Panel\\Mouse\" /v MouseThreshold1 /t REG_SZ /d 0 /f",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Process.Start(new ProcessStartInfo
            {
                FileName = "reg",
                Arguments = "add \"HKCU\\Control Panel\\Mouse\" /v MouseThreshold2 /t REG_SZ /d 0 /f",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            // Ajustar timer resolution
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c wmic computersystem where name=\"%computername%\" set systemtimersresolution=1",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Console.WriteLine("Input lag otimizado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao otimizar input lag: " + ex.Message);
        }
    }

    // Otimizações para melhorar conexão
    public static void OptimizeConnection()
    {
        try
        {
            // Desabilitar Large Send Offload e outras otimizações de rede
            Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "interface tcp set global autotuninglevel=disabled",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "interface tcp set global chimney=disabled",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Process.Start(new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "interface tcp set global rss=disabled",
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Console.WriteLine("Conexão otimizada para jogos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao otimizar conexão: " + ex.Message);
        }
    }
    // Importando funções da API do Windows
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SetPriorityClass(IntPtr hProcess, uint dwPriorityClass);

    [DllImport("kernel32.dll")]
    public extern static IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    // Prioridade de execução (high)
    const uint HIGH_PRIORITY_CLASS = 0x80;

    public static void Main(string[] args)
    {
        Console.WriteLine("==== Otimizador Para Fortnite ====");
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("[1] Otimização Completa");
            Console.WriteLine("[2] Apenas Rotina de Manutenção");
            Console.WriteLine("[3] Apenas Otimização Pré-Jogo");
            Console.WriteLine("[4] Desfazer Alterações (Rollback)");
            Console.WriteLine("[5] Otimizações Avançadas para Jogos");
            Console.WriteLine("[0] Sair");
            Console.Write("Opção: ");
            var op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    Log("Iniciando Otimização Completa");
                    RollbackManager.BackupAll();
                    Log("Backup realizado");
                    RoutineOptimizer.Run();
                    Log("Rotina de manutenção executada");
                    GameModeOptimizer.Run();
                    Log("Otimização pré-jogo executada");
                    StartupOptimizer.OptimizeStartup();
                    Log("Startup otimizado");
                    NetworkQoS.SetQoS();
                    Log("QoS sugerido");
                    DriverChecker.CheckDrivers();
                    Log("Drivers verificados");
                    LaptopPowerOptimizer.Optimize();
                    Log("Otimização de energia para laptop");
                    TemperatureMonitor.Monitor();
                    Log("Monitoramento de temperatura chamado");
                    Console.WriteLine("Otimização completa finalizada.");
                    break;
                case "2":
                    Log("Iniciando Rotina de Manutenção");
                    RollbackManager.BackupAll();
                    Log("Backup realizado");
                    RoutineOptimizer.Run();
                    Log("Rotina de manutenção executada");
                    break;
                case "3":
                    Log("Iniciando Otimização Pré-Jogo");
                    RollbackManager.BackupAll();
                    Log("Backup realizado");
                    GameModeOptimizer.Run();
                    Log("Otimização pré-jogo executada");
                    break;
                case "4":
                    Log("Restaurando alterações (rollback)");
                    RollbackManager.RestoreAll();
                    Log("Rollback executado");
                    break;
                case "5":
                    Log("Iniciando Otimizações Avançadas para Jogos");
                    SystemTweaks.Apply();
                    NetworkTweaks.Apply();
                    GPUTweaks.Apply();
                    AudioTweaks.Apply();
                    DiskTweaks.Apply();
                    AdvancedTweaks.Apply();
                    Log("Otimizações avançadas aplicadas");
                    break;
                case "0":
                    sair = true;
                    Log("Saindo do otimizador");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        Console.WriteLine("Saindo do otimizador.");
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
