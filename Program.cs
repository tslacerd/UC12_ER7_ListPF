using CadastroPessoa.Classes;


Console.Clear();

Console.WriteLine(@$"
##########################################
|   Bem vindo ao sistema de cadastro de  |
|      Pessoas Físicas e Jurídicas       |
##########################################
");


List<PessoaFisica> listaPf = new List<PessoaFisica>();


string? opcao;

do
{
    Console.Clear();
    Console.WriteLine(@$"
 ===================================
|   Escolha uma das opções abaixo   |
|-----------------------------------|
|       1 - Pessoa Física           |
|       2 - Pessoa Jurídica         |
|       0 - Sair                    |
 ===================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":


            PessoaFisica metodoPF = new PessoaFisica();
            string? opcaoPf;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
  ==================================
|   Escolha uma das opções abaixo    |
|------------------------------------|
|      1 - Cadastrar Pessoa Física   |
|      2 - Listar Pessoa Física      |
|      0 - Voltar para menu anterior |
  ==================================
");


                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":

                        PessoaFisica novaPf = new PessoaFisica();
                        endereco novoEnd = new endereco();

                        Console.WriteLine($"Digite o nome do usuário");
                        novaPf.Nome = Console.ReadLine();

                        bool dataValida;

                        do
                        {
                            Console.WriteLine($"Digite data de nascimento Ex.:DD/MM/AAAA");
                            string? dataNasc = Console.ReadLine();


                            dataValida = metodoPF.ValidarDataNasc(dataNasc);

                            if (dataValida)
                            {
                                novaPf.dataNasc = dataNasc;
                            }
                            else
                            {
                                Console.WriteLine($"Data inválida, digite data válida por favor");

                            }

                        } while (!dataValida);



                        Console.WriteLine($"Digite cpf apenas com números");
                        novaPf.Cpf = Console.ReadLine();

                        Console.WriteLine($"Digite rendimento mensal apenas com números");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte enter para vazio)");
                        novoEnd.Complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;

                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }


                        novaPf.Endereco = novoEnd;

                        listaPf.Add(novaPf);

                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Thread.Sleep(3000);


                        break;


                    case "2":

                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"

        Nome: {cadaPessoa.Nome}
        CPF: {cadaPessoa.Cpf}
        Endereço: {cadaPessoa.Endereco.logradouro}, {cadaPessoa.Endereco.numero}
        Rendimento: {cadaPessoa.rendimento.ToString("C")}
        Taxa de imposto R$: {metodoPF.PagarImposto(cadaPessoa.rendimento).ToString("C")}

        ");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(3000);

                        }

                        Console.WriteLine($"Enter para continuar");
                        Console.ReadLine();
                        break;
                    case "0":

                        break;
                    default:

                        Console.Clear();
                        Console.WriteLine($"Digite um opção válida!!!");
                        Thread.Sleep(3000);
                        break;
                }


            } while (opcaoPf != "0");



        case "2":
            Console.Clear();
            PessoaJuridica metodoPj = new PessoaJuridica();
            PessoaJuridica novaPj = new PessoaJuridica();
            endereco endPJ = new endereco();

            novaPj.Nome = "Nome Pj";
            novaPj.razaoSocial = "Razão social Pj";
            novaPj.Cnpj = "00.000.000/0001-00";
            novaPj.rendimento = 10000.5f;

            endPJ.logradouro = "Rua";
            endPJ.numero = 5333;
            endPJ.Complemento = "frente 4beer";
            endPJ.endComercial = true;

            novaPj.Endereco = endPJ;

            Console.WriteLine(@$"
Nome: {novaPj.Nome}
Razão Social: {novaPj.razaoSocial}
CNPJ: {novaPj.Cnpj}
CNPJ Válido: {(metodoPj.ValidarCnpj(novaPj.Cnpj) ? "Sim" : "Não")}
Rendimento: {novaPj.rendimento.ToString("C")}
Taxa de imposto R$: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
");

            Console.WriteLine($"Enter para continuar");
            Console.ReadLine();
            break;



        case "0":

            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar o sistema");


            break;

        default:
            Console.Clear();
            Console.WriteLine($"Digite um opção válida!!!");
            Console.WriteLine($"Enter para continuar");
            Console.ReadLine();
            break;


    }
} while (opcao != "0");




























