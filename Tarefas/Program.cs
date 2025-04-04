List<string> tarefas =  new List<string>();
List<bool> statusTarefas = new List<bool>();

void ExibirMenu()
{
    Console.WriteLine($@"
============MENU============
== 1 - Adicionar Tarefa   ==
== 2 - Listar Tarefa      ==
== 3 - Concluir Tarefa    ==
== 4 - Excluir Tarefa     ==
== 5 - Exibir Resumo      ==
== 6 - Tarefas Concluidas ==
== 7 - Excluir Concluidas == 
== 8 - Modificar Tarefa   ==
== 0 - Sair do Programa   ==
============================
Escolha uma opcao acima:");
}

void AdicionarTarefa()
{
    Console.Write("====== ADICIONAR TAREFA ======\n\nDigite uma nova Tarefa: ");
    string novaTarefa = Console.ReadLine();
    tarefas.Add(novaTarefa);
    statusTarefas.Add(false);
    Console.WriteLine("Tarefa adicionada com sucesso");
}

bool ListaTarefas()
{
    if(tarefas.Count == 0)
    {
        Console.WriteLine("Nenhuma Tarefa Cadastrada");
        return false;
    }

    Console.WriteLine("\n─====== LISTA DE TAREFAS ======─");

    for(int i = 0; i< tarefas.Count; i++)
    {
        string status = statusTarefas[i] ? "Concluida" : "Pendente";
        Console.WriteLine($"{i + 1 } - {tarefas[i]} | {status}");
    }
    return true;
}

void MarcarComoConcluida()
{
    ListaTarefas();
    if (tarefas.Count == 0) return;

    Console.WriteLine("Digite o númenro da tarefa concluída");
    int indice = int.Parse(Console.ReadLine()) - 1;

    if (indice >= 0 && indice < tarefas.Count)
    {
        statusTarefas[indice] = true;
        Console.WriteLine("Tarefa marcada como concluida");
    }
    else
        Console.WriteLine("Numero Invalido!");
}

void ExcluirTarefas()
{
    ListaTarefas();
    string opcao;
    if (tarefas.Count == 0) return;

    Console.WriteLine("Digite o numero da tarefa a ser excluida: ");
    int indice = int.Parse(Console.ReadLine()) - 1;
    Console.WriteLine($"Você tem certeza que deseja excluir a tarefa {indice + 1}? \"S\" para Sim e \"N\" para Não");
    opcao = Console.ReadLine().ToLower();

    if (opcao == "s")
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas.RemoveAt(indice);
            statusTarefas.RemoveAt(indice);
            Console.WriteLine("Tarefa removida com sucesso!");
        }
        else
            Console.WriteLine("Número invalido");
    }
    else
        Console.WriteLine("Nenhuma tarefa removida!");

    return;
}

void ExibirResumo()
{
    int total = tarefas.Count;
    int concluidas = statusTarefas.FindAll(status => status).Count();
    int pendentes = total - concluidas;

    Console.WriteLine($@"
====== RESUMO ======
Total de tarefas: {total}
Concluidas: {concluidas}
Pendentes: {pendentes}");
}

void TarefasConcluidas()
{
    int concluidas = statusTarefas.FindAll(status => status).Count();

    if (concluidas < 1)
        Console.WriteLine("Você não tem tarefas concluídas.");
    else
    {
         Console.WriteLine($@"
====== Concluídas ======
Total de tarefas concluídas: {concluidas}"+"\n");

        for (int i = 0; i < tarefas.Count; i++)
            if (statusTarefas[i])
                Console.WriteLine($"{i + 1} - {tarefas[i]} | Concluida.");
    }
}

void ExcluirConcluidas()
{
    string opcao;
    Console.WriteLine("Esse Procedimento ira apagar todas as tarefas marcadas como concluidas, prosseguir?\nDigite S para Sim e N para Não");
    opcao = Console.ReadLine().ToLower();

    if (opcao == "n")
        return;
    else if (opcao == "s")
    {
        for (int i = 0; i < tarefas.Count; i++)
        {
            if (statusTarefas[i])
            {
                tarefas.RemoveAt(i);
                statusTarefas.RemoveAt(i);
            }
        }
    }
    else
        Console.WriteLine("Opção Inválida");    
}

void ModificarTarefa()
{
    string opcao;
    string novaDescricao = "";
    int opcaoInt = 0;

    ListaTarefas();
    if (ListaTarefas())
    {
        Console.WriteLine("Qual tarefa desej modificar? ou 0 para cancelar");
        opcao = Console.ReadLine();

        if (int.TryParse(opcao, out opcaoInt))
        {
            if (opcaoInt == 0)
                return;
            else
            {
                if (opcaoInt > tarefas.Count)
                {
                    Console.WriteLine("Tarefa não encontrada. \n Nada Modificado");
                    return;
                }
                else
                {
                    Console.WriteLine("Digite a nova descrição:");
                    novaDescricao = Console.ReadLine();
                    tarefas[opcaoInt - 1] = novaDescricao;
                    Console.Clear();
                    ListaTarefas();
                }             
            }
        } 
    }
    else
        return;
}

bool sairDoPrograma = false;
while(!sairDoPrograma)
{
    ExibirMenu();
    string opcao = Console.ReadLine();

    Console.Clear();

    switch(opcao)
    {
        case "1":
            AdicionarTarefa();
            break;
        case "2":
            ListaTarefas();
            break;
        case "3":
            MarcarComoConcluida();
            break;
        case "4":
            ExcluirTarefas();
            break;
        case "5":
            ExibirResumo();
            break;
        case "6":
            TarefasConcluidas();
            break;
        case "7":
            ExcluirConcluidas();
            break;
        case "8":
            ModificarTarefa();
            break;
        case "0":
            sairDoPrograma = true;
            Console.Clear();
            break;
        default:
            Console.WriteLine("OPÇÃO INVÁLIDA! LEIA O MENU ANTES DE PROSSEGUIR");
            await Task.Delay(2000);
            break;
    }
}
