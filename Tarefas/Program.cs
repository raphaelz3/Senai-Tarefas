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
== 5 - Exibir Resulmo     ==
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

void ListaTarefas()
{
    if(tarefas.Count == 0)
    {
        Console.WriteLine("Nenhuma Tarefa Cadastrada");
        return;
    }

    Console.WriteLine("\n─====== LISTA DE TAREFAS ======─");

    for(int i = 0; i< tarefas.Count; i++)
    {
        string status = statusTarefas[i] ? "Concluida" : "Pendente";
        Console.WriteLine($"{i + 1 } - {tarefas[i]} | {status}");
    }
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
        Console.WriteLine("Tarefa marcada como conclida");
    }
    else
        Console.WriteLine("Numero Invalido!");
}

void ExcluirTarefas()
{
    ListaTarefas();
    if (tarefas.Count == 0) return;

    Console.WriteLine("Digite o numero da tarefa a ser excluida: ");
    int indice = int.Parse(Console.ReadLine()) - 1;

    if (indice >= 0 && indice < tarefas.Count)
    {
        tarefas.RemoveAt(indice);
        statusTarefas.RemoveAt(indice);
        Console.WriteLine("Tarefa removida com sucesso!");
    }
    else
        Console.WriteLine("Numero invalido");
}

void ExibirResulmo()
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

bool sairDoPrograma = false;
while(!sairDoPrograma)
{
    ExibirMenu();
    string opcao = Console.ReadLine();

    Console.Clear();

    switch(opcao)
    {
        case "1":
            //Console.Clear();
            AdicionarTarefa();
            break;
        case "2":
           // Console.Clear();
            ListaTarefas();
            break;
        case "3":
           // Console.Clear();
            MarcarComoConcluida();
            break;
        case "4":
            ExcluirTarefas();
            break;
        case "5":
            ExibirResulmo();
            break;
        case "0":
            sairDoPrograma = true;
           // Console.WriteLine("Você está saindo");
           // await Task.Delay(1000);
            Console.Clear();
            break;
        default:
            Console.WriteLine("OPÇÃO INVÁLIDA! LEIA O MENU ANTES DE PROSSEGUIR");
            await Task.Delay(2000);
           // Console.Clear();
            break;
    }
}
