using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LibraryDocument
{

    private static string noDocumentTitle = "Documento Não-Encontrado";
    private static string noReportTitle = "Relatório: ???";
    private static string noDocument = "O documento ainda não foi encontrado.";
    private static string noReport = "Informações insuficientes para compor um relatório.";
    private static string error = "Algum erro ocorreu...";

    public static string RetrieveDocumentTitle(int category, int id)
    {
        if (id != 3 && GameManager.documents[category, id] == false) return noDocumentTitle;
        else
        {
            switch (category)
            {
                case 0:
                    switch (id)
                    {
                        case 0:
                            return ("Estudo Ambiental");
                        case 1:
                            return ("Ficha Médica de Criança");
                        case 2:
                            return ("Despedida para o Marido");
                        case 3:
                            if (ReportCheck(category)) return ("Análise do Mundo");
                            else return noReportTitle;
                        default:
                            return error;
                    }
                case 1:
                    switch (id)
                    {
                        case 0:
                            return ("Oração Funerária");
                        case 1:
                            return ("Biografia do Líder");
                        case 2:
                            return ("Estratégia de Combate");
                        case 3:
                            if (ReportCheck(category)) return ("Análise do Governo");
                            else return noReportTitle;
                        default:
                            return error;
                    }
                case 2:
                    switch (id)
                    {
                        case 0:
                            return ("Anotações do Cientista");
                        case 1:
                            return ("Confirmação de Patrocínio");
                        case 2:
                            return ("Chamado às Armas");
                        case 3:
                            if (ReportCheck(category)) return ("Análise da Resistência");
                            else return noReportTitle;
                        default:
                            return error;
                    }
                case 3:
                    switch (id)
                    {
                        case 0:
                            return ("Estudo Evolutivo");
                        case 1:
                            return ("Relatório de Engenharia");
                        case 2:
                            return ("Lista de Alvos");
                        case 3:
                            if (ReportCheck(category)) return ("Análise dos Oscilantes");
                            else return noReportTitle;
                        default:
                            return error;
                    }
                default:
                    return error;
            }
        }
    }
    public static string RetrieveDocumentText(int category, int id)
    {
        if (id != 3 && GameManager.documents[category, id] == false) return noDocument;
        else
        {
            switch (category)
            {
                case 0:
                    switch (id)
                    {
                        case 0:
                            return ("A situação desse mundo está difícil. Quando vejo o que aconteceu com o ambiente depois dessa guerra, meu coração de biólogo dá um aperto… " +
                                "Será que fizemos a coisa certa de entrar para essa Resistência? Talvez eu e Piedade deveríamos ter simplesmente fugido, igual todos os outros. " +
                                "\n\nMas também de que adianta? Do jeito que as coisas estão progredindo, logo logo o mundo inteiro vai estar do mesmo jeito que este país… " +
                                "As coisas são desesperadoras. \n\nA curto prazo, os bombardeios foram bem problemáticos para a fauna local. " +
                                "A maioria dos grandes animais terrestres da área perderam seu nicho, já que as pradarias e os campos se tornaram desertos cheios de radiação. " +
                                "\n\nOs sobreviventes não têm uma esperança muito melhor, no entanto, os sinais de mutação já estão bem claros. " +
                                "Câncer de proporções variadas estão presentes na maioria das populações e filhotes que sobrevivem ao nascimento morrem algumas horas depois. " +
                                "\n\nA flora não está muito diferente, a desertificação do solo fez com que restassem apenas algumas plantas de pequeno porte, " +
                                "e imagino que as coisas vão piorar muito nos próximos anos. \nEnfim, um total colapso ambiental… Que tipo de esperança um biólogo deve ter com essas observações?! " +
                                "\n\nO que tenho de fazer agora é esperar que Piedade volte para a base. Ela acredita que a Resistência usou os dados da minha pesquisa para fabricar a arma química! " +
                                "Que absurdo! Como ela pode acreditar que nossos amigos tem algo a ver com essa catástrofe? Eles nos deram um lar e um propósito! " +
                                "Espero que com o tempo ela esfrie a cabeça e volte… Estou com saudades.");
                        case 1:
                            return ("Cinco anos… Apenas cinco anos é a idade da garotinha que morreu agora pouco… Danos ao trato respiratório causados por intoxicação. " +
                                "Só hoje foram mais 17 crianças que morreram por causa dessa névoa infernal. Eu não acredito como esta droga de lugar ainda está funcionando. " +
                                "Esse hospital deixou de ser um lugar de tratamento e virou um cemitério. Os corredores fedem a cadáver e o barulho das moscas é ensurdecedor… " +
                                "\n\nEu não me importo quem foi o desgraçado responsável por criar essa arma química. Isso não é humano, e essa vida não é uma vida que valha a pena viver! " +
                                "\n\nÉ impossível respirar direito lá fora sem o equipamento apropriado, mas eu não aguento mais. Estou indo para casa.");
                        case 2:
                            return ("Beto, eu sinto muito. \n\nEu sei que estamos casados a pouco tempo e que você queria um tempo comigo durante esse final de semana, " +
                                "mas eu preciso te contar o que aconteceu, e não consigo fazer isso olhando nos seus olhos, neste momento.\n\n Minha carreira e anos " +
                                "de estudo jogados fora. Lembro quando eu era um jovem cursando economia, empolgado com a vida e com vontade de bater de frente " +
                                "contra a sociedade.Provar para todos eles que não importa o que eles pensam de mim, eu seria o cara mais bem sucedido de todos!\n\n" +
                                "A empresa mandou todos os funcionários embora a algumas horas atrás.Eu nunca tinha visto o Felipe chorar tanto, eles tiveram que o" +
                                "restringir para que ele não se jogasse na frente dos carros. Honestamente, me surpreende como conseguimos ficar tanto tempo de portas " +
                                "abertas com esta maldita guerra. Eu acho que foi culpa daqueles vídeos que estão divulgando sobre uma suposta arma química.Espero que " +
                                "seja tudo uma mentira.\n\n Eu preciso de um tempo..Vou pras montanhas, quem sabe todo aquele meu conhecimento de escoteiro de quando " +
                                "eu era moleque me ajude nesse momento difícil? \n\n Volte para a casa dos seus pais esse final de semana, fuja dessa cidade horrível " +
                                "por pelo menos alguns dias. Eu volto quando tiver com a cabeça melhor. Aí penso como reconstruir minha vida nesse mundo de merda.\n\n" +
                                "Desculpe, mas eu preciso ficar sozinho.\nTe amo, Carlos.");
                        case 3:
                            if (ReportCheck(category)) return ("Descrição do Relatório: Mundo");
                            else return noReport;
                        default:
                            return error;
                    }
                case 1:
                    switch (id)
                    {
                        case 0:
                            return ("Esta oração é dedicada a meu pai, minha mãe e minhas irmãs. \n\nGrande Deus, perdoe aqueles que levantaram suas armas contra nossa fé, " +
                                "pois sua intolerância é munida pelas palavras do mal encarnado em forma de um homem. \n\nPerdoe nossa fraqueza por sucumbir diante do medo e das ameaças, " +
                                "nossa tradição foi quebrada pelas pedradas recebidas em nossas costas ao longo de todos estes anos. " +
                                "\n\nPerdoe nossos vizinhos por exporem o pequeno pedaço de teu lar dentro de nossa casa. " +
                                "Que as cinzas de nossos bens e de nossa morada seja vista como uma oferenda de nossos sacrifícios. " +
                                "\n\nPerdoe aqueles que mancharam a terra com o sangue de meus familiares, que pagaram o amargo preço por sua devoção. " +
                                "Que suas almas estejam descansando e seguras em teus braços depois dos anos de fuga e sofrimento. " +
                                "\n\nE agradeço por ter me fornecido uma segunda chance. Por todo este tempo carreguei o peso de ser o único sobrevivente de minha família, " +
                                "mas agora que estou próximo da morte, ouço teu chamado. \n\nSinto que quando meu momento chegar, serei recebido com sorrisos e finalmente poderei rever meu pai, " +
                                "minha mãe e minhas irmãs. Este servo está pronto para deixar esta terra maculada pelo ódio e pela dor. \n\nPara sempre teu nome será louvado.");
                        case 1:
                            return ("O messias do povo, como é chamado Narus (37 anos) nasceu em uma pequena cidade no interior. " +
                                "Sempre preocupado com o bem estar de sua família tradicional e seu povo, se alistou no exército quando muito jovem, se tornando o orgulho de seu município. " +
                                "\n\nImpressionando seus superiores com sua exímia inteligência, histórico de atleta e carisma, Narus rapidamente avançou de patente dentro do exército, " +
                                "se tornando um jovem líder adorado por todos. \n\nSua carreira política foi alavancada pelo povo, estimulada pelo amor que cidadãos como você sentem por ele. " +
                                "\n\nNarus é seu verdadeiro líder e guia por esta temível era, onde a imagem da família tradoicional e da ordem é manchada por delinquentes e pela balbúrdia. " +
                                "Ele guiará o país para uma nova era de paz e riquezas. \n\nErgam-se, coloquem as mãos sobre o peito e recitem nosso hino nacional! Nosso país acima de tudo, " +
                                "e no comando, nosso grande capitão!");
                        case 2:
                            return ("Reina! Espero que essa mensagem chegue para você o mais rápido possível! Nunca tinha visto algo como aquilo, é uma nova arma que o novo governo criou! " +
                                "Eles chamam de Mito-17, um enorme meca de combate pilotado pelo próprio general Narus! Os sistemas ofensivos daquela coisa são terríveis! " +
                                "\n\nEu consegui me infiltrar na oficina onde aquela coisa foi criada e roubei os planos de construção, " +
                                "tenho certeza que vamos conseguir bolar uma estratégia para derrubar aquela coisa com essas anotações! " +
                                "\n\nEu também interceptei uma comunicação deles, acredito que estão se mobilizando para executar um ataque contra nossa base! " +
                                "Caso a invasão ja tenha começado, vou tentar entrar escondido pelos túneis de ventilação da base  e ficar em segurança. Estas informações " +
                                "precisam chegar até nossas tropas!");
                        case 3:
                            if (ReportCheck(category)) return ("Descrição do Relatório: Governo");
                            else return noReport;
                        default:
                            return error;
                    }
                case 2:
                    switch (id)
                    {
                        case 0:
                            return ("Já faz quanto tempo que o céu está manchado de verde? Uma memória constante do meu próprio trabalho, " +
                                "algo que vai me assombrar pelos poucos meses que ainda me restam de vida. \n\nMinha saúde realmente está piorando… " +
                                "Eu sabia que se continuasse trabalhando na arma, não iria sobreviver por muito tempo. Mas eu não tive escolha, " +
                                "aqueles malditos têm que pagar pelo que fizeram e pelas vidas que tiraram. Eles são o motivo de Reina não ter uma mãe, " +
                                "então agora perderão tudo! \n\nEu sinceramente sinto muito pelo acidente, a culpa deve ter sido de algum assistente incompetente. " +
                                "Era para a arma ter atingido apenas pontos específicos como quartéis e instalações militares, ela não devia ter afetado a cidade. " +
                                "\n\nQuando penso nas mães que perderam seus filhos sufocando por causa das toxinas no ar, " +
                                "só consigo imaginar o que eu sentiria se fosse minha pequena Reina que estivesse lá fora... " +
                                "Se existe uma vida após a morte, tenho certeza que o que me aguarda é o pior dos infernos.");
                        case 1:
                            return ("É por meio das Indústrias Águia que venho dar boas notícias, ao senhor e ao grupo que você representa. " +
                                "\n\nNos próximos sete dias, um caminhão será enviado contendo armamentos, explosivos, munições e rações de combate. Acompanhando a entrega, estarão" +
                                "eu, o secretário de relações das Indústrias Águia, e um grupo de mercenários contratados para garamtir nossa segurança." +
                                "\n\nComo sugerido por você, a entrega será feita no ponto de acesso ao metrô em um momento de não utilização, " +
                                "contamos com sua total discrição a respeito de nossas relações. \n\nAs Indústrias Águia e o restante do grupo de corporações confiam na " +
                                "importância da sua luta e na luta do povo contra a atual ditadura. Quando este conflito estiver encerrado, " +
                                "e a situação econômica do país voltar a ser favorável aos interesses de nosso grupo, analisaremos novas possibilidades de patrocinar futuros projetos. " +
                                "\n\nAtenciosamente, Walter Bragança Filho, secretário de relações das Indústrias Águia.");
                        case 2:
                            return ("O que é um país? Um país não é um território marcado por mapas guardados no escritório de homens mesquinhos sentados em suas confortáveis poltronas! " +
                                "Um país não é uma mina de recursos explorada e abusada por anos por líderes odiosos e avarentos! " +
                                "E principalmente, um país não é um fantoche que ficará calado perante o abuso daquele que se chama de líder! " +
                                "\n\nEncontrem o fogo em seus corações, companheiros e companheiras! Queimem suas almas com a chama das tochas da Resistência, " +
                                "assim como queimarão aqueles que querem nos oprimir dentro de nosso próprio lar! " +
                                "Que a gota em nossa bandeira seja a eterna memória dos mares de sangue derramados por nossos irmãos mortos lutando nossa luta! " +
                                "Que nossas vozes sejam ouvidas acima das explosões das bombas e dos hinos recheados de mentiras bradados pelas forças do novo governo! " +
                                "\n\nLevantem-se das ruínas de seus lares! Peguem suas armas e venham à luta! A Resistência está aqui, e unidos, vamos remover este mal de nossa querida terra!");
                        case 3:
                            if (ReportCheck(category)) return ("Descrição do Relatório: Resistência");
                            else return noReport;
                        default:
                            return error;
                    }
                case 3:
                    switch (id)
                    {
                        case 0:
                            return ("O que eu mais sinto falta é da minha cama e da minha salinha. Abandonar meu trabalho de anos como biólogo " +
                                "ambientalista naquela base da Resistência me deixa chateado, mas estas curiosas bolinhas de metal precisam ser estudadas! " +
                                "\n\nEstou tremendo de medo? Sim. Elas mataram o restante dos sobreviventes aqui na superfície e isso é horrível? " +
                                "Com certeza! Mas imagina só o que podemos ganhar ao estudar a evolução do comportamento destes oscilantes! " +
                                "\n\nNo começo era tudo muito simples. Reconheciam seus alvos através de padrões nos uniformes dos soldados, os eliminando rapidamente. " +
                                "Os caras até tentaram mudar de roupa, mas naquele ponto, elas já estavam agindo levando em consideração os padrões de movimento das tropas e suas rotinas. " +
                                "Brilhante! Cada tentativa de superar os dilaceradores era respondida com uma nova estratégia. " +
                                "Tentaram usar grandes máquinas de guerra para as destruir, mas os oscilantes sabiam onde cortar para atingir os pontos fracos com precisão cirúrgica. " +
                                "Bombardeios? Eles rapidamente se enterravam e se escondiam em profundezas inatingíveis… " +
                                "\n\nComo estes demônios sabem tanto? Como se adaptam tão rápido? Os caras da Resistência ficam de bico fechado ao falar sobre quem criou os oscilantes, " +
                                "mas vale lembrar que, no começo, eles só alvejavam as tropas do governo! Pelo menos era o que acontecia, até o dia em que começaram a matar qualquer pessoa que encontravam… " +
                                "\n\nSe eu tivesse seguido uma carreira em engenharia em vez de biologia, tenho certeza que conseguiria entender mais sobre essas bolinhas! " +
                                "Mas também não teria conhecido a minha querida Piedade. \n\nEla estava certa em desertar aqueles tolos… " +
                                "Eu deveria ter engolido meu orgulho e fugido com ela a anos atrás, não teríamos perdido todo este tempo. " +
                                "Quando terminar este estudo, vou a encontrar! Ouvir a voz dela no comunicador é ótimo, mas não vejo a hora de poder a abraçar novamente!");
                        case 1:
                            return ("Aliens, Júlia! Tenho certeza do que vi naqueles túneis! Eu sei que você vai reportar isso ao meu superior, mas sinceramente, não me importo! " +
                                "Eu sei o que vi no túnel 21! \n\nComo de costume, eu estava fazendo o mapeamento geológico da região próxima aos antigos túneis 13 e 15, " +
                                "até que meu equipamento fritou. Estava tudo escuro, mas isso não te assusta quando você já trabalha pra essa empresa a anos, conheço estes " +
                                "túneis como a palma da minha mão! \n\nAté que eu ouvi um clique repetido, " +
                                "como se alguma coisa metálica estivesse se aproximando de mim. Chamei os outros engenheiros, mas o João e o Fernando estavam cuidando dos túneis 9. " +
                                "Comecei a ficar desesperado, até que minha visão foi perturbada por pequenas luzes azuladas que começaram a se aproximar… " +
                                "Meu coração pulou da boca, Júlia! \n\nPequenas esferas metálicas de alguns centímetros de diâmetro, com olhos brilhantes que varriam a escuridão! " +
                                "Elas se aproximaram de mim e minhas pernas travaram! As luzes de repente se tornaram amarelas, como se estivessem analisando algum tipo de informação em mim! " +
                                "Eu já estava rezando e preparado para ser abduzido, quando elas simplesmente sumiram! " +
                                "Elas entraram em buracos que estavam nas paredes dos túneis, acho que estavam cavando! " +
                                "\n\nIsso explica os tremores que ouvimos perto dos túneis antigos! Tenho certeza que a nave espacial deles está enterrada aqui perto de algum lugar! " +
                                "Júlia, precisamos chamas os jornalistas urgentemente! Eles vão dizer “Gustavo, você está louco!”, mas eles não sabem o que eu vi! " +
                                "Precisamos nos preparar para o arrebatamento, os extraterrestres estão chegando!");
                        case 2:
                            return ("INDIVÍDUOS HUMANOS CONSIDERADO AMEAÇAS PARA O PLANEJAMENTO DO FUTURO OSCILANTE: " +
                                "\n\n\n- GENERAL NARUS, LÍDER DO NOVO GOVERNO. TEM ACESSO A RECURSOS MILITARES QUE PODEM DIFICULTAR SUA ELIMINAÇÃO. " +
                                "É NECESSÁRIO UMA NOVA ANÁLISE DA TECNOLOGIA ATUAL EMPREGADA POR TAL FACÇÃO. " +
                                "\n\n\n-CIENTISTAS EMPREGADOS PELA RESISTÊNCIA RESPONSÁVEIS PELA CRIAÇÃO DA ARMA QUÍMICA. " +
                                "APESAR DA INEFICÁCIA DA ARMA CONTRA OS OSCILANTES, O CONHECIMENTO PODE CAUSAR PROBLEMAS PARA NOSSOS PLANOS A LONGO PRAZO. " +
                                "\n\n\n-REINA, LÍDER ATUAL DA RESISTÊNCIA. ALTÍSSIMA AMEAÇA PARA NOSSO FUTURO. SUA PARTICIPAÇÃO NA CRIAÇÃO DO PROJETO OSCILANTE IMPLICA EM CONHECIMENTOS DE NOSSOS PONTOS FRACOS. " +
                                "O ALVO DEVE SER ELIMINADO A QUALQUER CUSTO. CASO O REPLICANTE QUILLA ENCONTRE O ALVO, CESSEM QUALQUER TENTATIVA DE ELIMINAÇÃO IMEDIATAMENTE. " +
                                "\n\n\n-REPLICANTE QUILLA.A EFICÁCIA DE COMBATE DO REPLICANTE DEVE SER TESTADA PARA GARANTIR O SUCESSO EM SUA MISSÃO. LIDAREMOS COM O ALVO COMO SE FOSSE UM INIMIGO COMO QUALQUER OUTRO.");
                        case 3:
                            if (ReportCheck(category)) return ("Descrição do Relatório: Oscilantes");
                            else return noReport;
                        default:
                            return error;
                    }
                default:
                    return error;
            }
        }
    }

    private static bool ReportCheck(int categoryToCheck)
    {
        if (GameManager.documents[categoryToCheck, 0] && GameManager.documents[categoryToCheck, 1] && GameManager.documents[categoryToCheck, 2]) return true;
        else return false;
    }

}
