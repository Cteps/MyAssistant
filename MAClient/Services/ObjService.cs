using MAlib.ComplexModels;
using MAlib.Entity.Models._Obj;
using MAlib.Services;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MAlib.ComplexModels.CheckList;

public class ObjService
{
    private readonly ApiService _client;
    private string _baseEndPoint = "api/Obj";
    public ObjService()
    {
        _client = new ApiService();
    }

    public async Task<List<ObjEsp>> GetObjEspAsync()
    {
        try
        {
            var response = await _client.GetDataAsync<List<ObjEsp>>($"{_baseEndPoint}/Geral");

            return response.Data;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao obter objetos gerais da API.", ex);
        }
    }
}

public static class OffService
{
    static List<string> OFPEJ1 = new List<string>
    {
    "Atacar a bola e controla-la",
    "Condução em direção à baliza adv",
    "Finalizar assim que tiver condições",
    "Decisão(passe|finta|remate)"
    };
    static List<string> OFPEJ2 = new List<string>
    {
    "Linha de passe ao lado e atrás do portador",
    "Orientar ações para o lado contrario",
    "Ajustar a distancia as ações do 2 defesa"
    };
    static List<string> OFPEJ3 = new List<string>
    {
    "Deslocar-se à máxima velocidade para a baliza adversária após o passe",
    "Ocupação de espaços livres",
    "Troca de funções",
    "Criação de linha de passe" ,
    "Manter a posse"
    };
    static List<string> OFPEJ4 = new List<string>
    {
    "Campo Grande (Ocupar 3 corredores)",
    "Profundidade (Ocupar 3 setores)",
    "1º e 2º Poste (Na finalização)",
    "Missão TT"
    };
    static List<string> DFPEJ1 = new List<string>
    {
        "Colocar-se entre bola e baliza",
        "Reduzir espaço de progressão do adv e travar perto",
        "Adequar distancia ao adv",
        "Reagir as ações do portador da bola",
        "Orientar o adversário para o corredor lateral"
    };
    static List<string> DFPEJ2 = new List<string>
    {
        "Colocação atrás e ao lado do colega em contenção",
        "Posicionar-se de acordo com as ações do 2 atacante",
        "Troca de funções",
        "Cortar linhas de passe ofensivas"
    };
    static List<string> DFPEJ3 = new List<string>
    {
        "Diminuição das distancias aos companheiros",
        "Cobertura de eventuais espaços vazios ou linhas de passe"
    };
    static List<string> DFPEJ4 = new List<string>
    {
        "Defender corredor central e da bola",
        "Missão TT",
        "Ocupar 2 setores"
    };
    static List<string> CF = new List<string>
    {
    "Resistência Aeróbica",
    "Resistência Anaeróbica",
    "Velocidade",
    "Força",
    "Coordenação e Equilíbrio"
    };
    static List<string> ET = new List<string>
    {
        "Cantos DF",
        "Cantos OF",
        "Livres DF",
        "Livres OF",
        "Saída de bola"
    };
    static List<string> TI = new List<string>
    {
        "Receção",
        "Finta",
        "Drible",
        "Condução",
        "Remate",
        "Desarme",
        "Passe",
        "Cabeceamento",
        "Cruzamento",
        "Desmarcação",
        "Combinação Tática",
        "Lançamento Lateral",
        "Posição Básica Defensiva",
        "Desdobramento e compensação",
        "Dobra"
    };
    static List<string> MONTHS = new List<string> {
    "JAN",
    "FEV",
    "MAR",
    "ABR",
    "MAI",
    "JUN",
    "JUL",
    "AGO",
    "SET",
    "OUT",
    "NOV",
    "DEZ"
    };
    static List<PEJ> PEJ = new List<PEJ> {
    new PEJ("Progressão e Contenção",1),
    new PEJ("Cobertura Ofensiva e Defensiva",2),
    new PEJ("Mobilidade e Equilibrio",3),
    new PEJ("Espaço",4),
    new PEJ("Concentração",4)
    };

    public static async Task<List<CheckList>> GetMaterials()
    {
        return new List<CheckList>
                                {
                                new CheckList("Sinalizadores"),
                                new CheckList("Cones"),
                                new CheckList("Coletes"),
                                new CheckList("Balizas"),
                                new CheckList("Bolas"),
                                new CheckList("Varas")
                                };

    }

    public static async Task<List<CheckListTyped>> GetEspObj()
    {
        List<CheckListTyped> list = new List<CheckListTyped>();
        foreach (var item in OFPEJ1) list.Add(new CheckListTyped(GeralType.OF_PEJ1, item));
        foreach (var item in OFPEJ2) list.Add(new CheckListTyped(GeralType.OF_PEJ2, item));
        foreach (var item in OFPEJ3) list.Add(new CheckListTyped(GeralType.OF_PEJ3, item));
        foreach (var item in OFPEJ4) list.Add(new CheckListTyped(GeralType.OF_PEJ4, item));
        foreach (var item in DFPEJ1) list.Add(new CheckListTyped(GeralType.DF_PEJ1, item));
        foreach (var item in DFPEJ2) list.Add(new CheckListTyped(GeralType.DF_PEJ2, item));
        foreach (var item in DFPEJ3) list.Add(new CheckListTyped(GeralType.DF_PEJ3, item));
        foreach (var item in DFPEJ4) list.Add(new CheckListTyped(GeralType.DF_PEJ4, item));
        foreach (var item in CF) list.Add(new CheckListTyped(GeralType.CF, item));
        foreach (var item in ET) list.Add(new CheckListTyped(GeralType.EsqTatico, item));
        foreach (var item in TI) list.Add(new CheckListTyped(GeralType.TI, item));

        return await Task.FromResult(list);
    }

    public static async Task<List<CheckList>> GetGeralObj()
    {
        return new List<CheckList>
                            {
                                new CheckList("Tecnica Individual","TI"),
                                new CheckList("Ludico"),
                                new CheckList("Capacidades Fisicas","CF"),
                                new CheckList("Progressão","OF_PEJ1"),
                                new CheckList("Contenção","DF_PEJ1"),
                                new CheckList("Cobertura Ofensiva","OF_PEJ2"),
                                new CheckList("Cobertura Defensiva","DF_PEJ2"),
                                new CheckList("Mobilidade","OF_PEJ3"),
                                new CheckList("Equilibrio","DF_PEJ3"),
                                new CheckList("Espaço","OF_PEJ4"),
                                new CheckList("Concentração","DF_PEJ4"),
                                new CheckList("Esquema Tatico","EsqTatico")
                            };
    }

    public static async Task<List<string>> GetMonths()
    {
        return await Task.FromResult(MONTHS);
    }

    public static async Task<List<CheckList>> GetTT()
    {
        List<CheckList> list = new List<CheckList>();
        foreach (var item in TI) list.Add(new CheckList(item));
        return await Task.FromResult(list);
    }
    public static async Task<List<PEJ>> GetPEJ()
    {
        return await Task.FromResult(PEJ);
    }
    public static async Task<List<string>> GetET()
    {
        return await Task.FromResult(ET);
    }
    public static async Task<List<string>> GetCF()
    {
        return await Task.FromResult(CF);
    }
}


