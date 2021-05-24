using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public static class LibraryDialogue
{
    public static int currentPortraitId;
    public static Sprite[] characterPortrait = new Sprite[7];

    public static string RetrieveDialogue(int level, int chatId, int sectionId, int lineId)
    {
        switch (level)
        {
            //Level 1 dialogues
            case 1:
                switch (chatId)
                {
                    //Quilla wakes up
                    case 1:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return ("Alguém na escuta? Precisamos de ajuda!");
                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return ("Tem alguém aí? Nós estamos sendo!");
                                    default: return null;
                                }
                            case 3:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return ("As máquinas do exército estão destruindo o portão! A base está sendo invadida! Nós não temos muito tempo!");
                                    default: return null;
                                }
                            case 4:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return ("Quilla na escuta. Quem está falando?");
                                    case 2:
                                        currentPortraitId = 2;
                                        return ("Um sobrevivente nessa frequência? Aqui é Reina, líder da Resistência. Estamos sob ataque dos militares e precisamos " +
                                            "de evacuação urgente! ");
                                    default: return null;
                                }
                            case 5:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return ("Estou enviando minha posição. Como chego até aí?");
                                    case 2:
                                        currentPortraitId = 2;
                                        return ("Você está no deserto? Está próxima! Siga na direção leste até chegar nos limites da cidade!");
                                    case 3:
                                        currentPortraitId = 0;
                                        return ("Positivo. Estou a caminho.");
                                    case 4:
                                        currentPortraitId = 2;
                                        return ("Entro em contato novamente quando você estiver se aproximando! Vou tentar encontrar outros membros da " +
                                            "Resistência nessa frequência.");
                                    case 5:
                                        currentPortraitId = 2;
                                        return ("Por favor, venha rápido e tome cuidado!");
                                    case 6:
                                        currentPortraitId = 0;
                                        return ("Entendido. Quilla desligando.");
                                    default: return null;
                                }
                            case 6:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return ("Operador, você está na escuta?");
                                    case 2:
                                        currentPortraitId = 1;
                                        return ("Sempre. Parece que a situação da Resistência é pior do que foi reportado, mas acredito que ainda há " +
                                            "tempo de chegar até eles.");
                                    case 3:
                                        currentPortraitId = 1;
                                        return ("Prepare seu equipamento, agente. Quando estiver pronta ative o interruptor para abrir a porta e siga " +
                                            "na direção leste. Estarei observando seu trajeto.");
                                    case 4:
                                        currentPortraitId = 0;
                                        return ("Certo. Me deseje sorte, Operador.");
                                    case 5:
                                        currentPortraitId = 1;
                                        return ("Sorte não é um fator, apenas suas decisões.");
                                    default: return null;
                                }
                            default: return null;

                        }
                    //Capsule found
                    case 2:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return ("Estou detectando altos níveis de radiação neste local, agente. É de extrema importância que você saia da área.");
                                    case 2:
                                        currentPortraitId = 0;
                                        return ("Uma cápsula quebrada saindo do chão... O que isso tá fazendo por aqui?");
                                    case 3:
                                        currentPortraitId = 1;
                                        return ("Sugiro focar em sua missão, agente.");
                                    case 4:
                                        currentPortraitId = 0;
                                        return ("Certo... Vamos sair daqui.");
                                    default: return null;
                                }
                            default: return null;
                        }
                    //Go back
                    case 3:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return ("Esta área é perigosa, devo tomar cuidado.");

                                    default: return null;
                                }

                            default: return null;
                        }
                    //Shredder in sight
                    case 4:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return ("Fique em alerta. Um dilacerador se encontra próximo da sua posição.");
                                    case 2:
                                        currentPortraitId = 0;
                                        return ("Coisinhas complicadas... Não acho que vou conseguir passar despercebida.");
                                    case 3:
                                        currentPortraitId = 1;
                                        return ("Esta variedade de oscilante é programada para atacar alvos se aproximando. Já foram responsáveis por muitas mortes.");
                                    case 4:
                                        currentPortraitId = 0;
                                        return ("Sei como lidar com eles, alguns disparos com o revolver serão o suficiente.");
                                    case 5:
                                        currentPortraitId = 1;
                                        return ("Sim, sugiro considerar uma aproximação corpo-a-corpo apenas se estiver com pouca munição.");
                                    default: return null;
                                }
                            default: return null;
                        }
                    //Watchout bombardments
                    case 5:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return ("Parece que os bombardeios atingiram essa área bem drasticamente...");
                                    case 2:
                                        currentPortraitId = 2;
                                        return ("Aqueles malditos! Esta área foi uma das mais afetadas pelas bombas que o governo disparou contra a gente...");
                                    case 3:
                                        currentPortraitId = 2;
                                        return ("Se os bombardeios não tivessem acontecido, minha mãe ainda estaria viva...");
                                    case 4:
                                        currentPortraitId = 0;
                                        return ("...");

                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "Eu entendo, Reina. Eu também perdi alguém muito importante nos ataques.";
                                    case 2:
                                        currentPortraitId = 2;
                                        return "Eu... Eu sinto muito... O que aconteceu?";
                                    case 3:
                                        currentPortraitId = 0;
                                        return "Minha filha, mas já faz muito tempo.";
                                    case 4:
                                        currentPortraitId = 2;
                                        return "...";
                                    case 5:
                                        currentPortraitId = 0;
                                        return "Quantos anos você tem, Reina?";
                                    case 6:
                                        currentPortraitId = 2;
                                        return "Eu? Vinte e um...";
                                    case 7:
                                        currentPortraitId = 0;
                                        return "Acredito que ela teria sua idade hoje.";
                                    case 8:
                                        currentPortraitId = 2;
                                        return "Eu...";
                                    case 0:
                                        currentPortraitId = 1;
                                        return "...";

                                    default: return null;
                                }

                            default: return null;
                        }
                    //Watchout escavation pit
                    case 6:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return ("Um possível obstáculo a frente.");

                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "O que é aquilo?";
                                    case 2:
                                        currentPortraitId = 1;
                                        return "Um antigo poço de escavação do governo. Estou recebendo algumas leituras elétricas comparáveis àquelas presentes " +
                                            "em sistemas de defesa avançados.";

                                    default: return null;
                                }
                            case 3:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "Isso está no meio do caminho... Vou ter que me preparar...";

                                    default: return null;
                                }

                            default: return null;
                        }
                    //Escavation Pit Puzzle
                    case 7:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "Porcaria... Como vou chegar do outro lado? Preciso encontrar uma maneira de chegar la em cima.";

                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return "Estas plataformas parecem ser o caminho. Você terá que saltar nelas para alcançar o topo.";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "Saltar? Eu não vou conseguir pular estas distâncias!";
                                    case 3:
                                        currentPortraitId = 1;
                                        return "Este é um problema e tanto... Vou demorar para encontrar outro caminho até a cidade...";

                                    default: return null;
                                }
                            case 3:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "Quilla? Pela sua localização, parece que você está próxima do poço de escavação!";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "Exatamente. Afinal, que tipo de lugar é esse?";
                                    case 3:
                                        currentPortraitId = 2;
                                        return "Uma antiga operação para estabelecer uma mina da época do governo antes da guerra. Um obstáculo bem grande no " +
                                            "caminho da cidade!";

                                    default: return null;
                                }
                            case 4:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "E esse não é o único problema! O lugar é protegido por um perigoso sistema de defesa! Eu sugiro você tentar desarmar " +
                                            "ele antes de prosseguir!";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "Certo. Como eu faço isso?";
                                    case 3:
                                        currentPortraitId = 2;
                                        return "Err... Você precisa subir até a sala de controle acima da torre de defesa!";
                                    case 4:
                                        currentPortraitId = 0;
                                        return "...";
                                    case 5:
                                        currentPortraitId = 0;
                                        return "Reina, eu não sou capaz de voar.";
                                    case 6:
                                        currentPortraitId = 2;
                                        return "Ahhhhh! É verdade! As plataformas!";

                                    default: return null;
                                }
                            case 5:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "Desculpe! Devem ter uns controles perto de você que eram usados para mover as plataformas! É possível que hoje em " +
                                            "dia os circuitos não estejam funcionando direito, mas talvez você consiga fazer alguma coisa com eles?";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "Entendido... Vou ver o que consigo fazer.";

                                    default: return null;
                                }
                            case 6:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "E tome cuidado para não cair! Nenhum humano conseguiria sobreviver a queda!";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "Tomarei cuidado. Obrigado, Reina.";

                                    default: return null;
                                }

                            default: return null;
                        }
                    //Defense system turned off
                    case 8:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return "Sistema de defesa desligado, sua passagem por este local agora está mais segura.";

                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 3;
                                        return "O que temos aqui? Um verme vestindo as cores da resistência tem a audácia de sabotar uma instalação governamental " +
                                            "oficial?";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "General Narus... O líder do governo lida pessoalmente com infrações como essas?";
                                    case 3:
                                        currentPortraitId = 3;
                                        return "O que eu faço ou não não é de seu interesse, rato imundo! Reinicie o sistema imediatamente!";
                                    case 4:
                                        currentPortraitId = 0;
                                        return "Eu acho que não... Vai ser muito mais fácil entrar na cidade sem essa coisa atirando nas minhas costas.";
                                    case 5:
                                        currentPortraitId = 3;
                                        return "Ah! Então você está vindo? Vou preparar um lugar especial pra você observar enquanto eu esmago seus companheiros, " +
                                            "rebelde imprestável!";
                                    case 6:
                                        currentPortraitId = 0;
                                        return "Pode deixar, eu também tenho planos de esmagar um certo general quando eu o encontrar. Nos vemos em breve.";

                                    default: return null;
                                }
                            case 3:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "Quilla! Você está bem? Conseguiu passar pelo poço de escavação?";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "O sistema de defesa foi desligado. E parece que o general Narus não gostou nem um pouco disso.";
                                    case 3:
                                        currentPortraitId = 2;
                                        return "Ele falou com você?! Ele foi avistado liderando o ataque lá fora! Preciso que você venha logo, não consegui encontrar " +
                                            "nenhum outro membro da resistência aí fora!";
                                    case 4:
                                        currentPortraitId = 0;
                                        return "Estou a caminho, Reina. Por favor, aguente.";

                                    default: return null;
                                }

                            default: return null;
                        }
                    //Watchout anihilator
                    case 9:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "Você está bem próxima da cidade, Quilla! Consegue ver a entrada?";

                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "Sim, mas parece que tem algum tipo de oscilante grande bloqueando a passagem.";
                                    case 2:
                                        currentPortraitId = 2;
                                        return "Esse modelo é extremamente perigoso e durável! Eu não sei se armas convencionais serão o suficiente!";
                                    case 3:
                                        currentPortraitId = 0;
                                        return "Hm... Vou ter de pensar em uma possível estratégia...";

                                    default: return null;
                                }
                            case 3:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return "Por favor, cuidado! A entrada da cidade esta cheia de minas terrestres!";
                                    case 2:
                                        currentPortraitId = 0;
                                        return "Vou ser cautelosa, obrigado Reina.";
                                    case 3:
                                        currentPortraitId = 2;
                                        return "Estou torcendo por você!";

                                    default: return null;
                                }

                            default: return null;
                        }
                    //City gates
                    case 10:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "Reina? O oscilante foi destruído.";

                                    default: return null;
                                }
                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 0;
                                        return "Reina?";
                                    case 2:
                                        currentPortraitId = 2;
                                        return "Quilla! Eles conseguiram atravessar as defesas internas! Estamos mobilizando a maior quantidade de homens possíveis!";
                                    case 3:
                                        currentPortraitId = 2;
                                        return "A base está um caos... Muitos estão morrendo... Eu... eu não sei o que fazer!";
                                    case 4:
                                        currentPortraitId = 0;
                                        return "Tenha força! Você é a líder destas pessoas. Deve mostrar a eles que consegue aguentar a pressão.";
                                    case 5:
                                        currentPortraitId = 0;
                                        return "Deve liderar eles neste momento de dificuldade, eu acredito que você seja capaz disso!";
                                    case 6:
                                        currentPortraitId = 1;
                                        return "...";
                                    case 7:
                                        currentPortraitId = 2;
                                        return "Eu... Eu farei o meu melhor.";
                                    case 8:
                                        currentPortraitId = 0;
                                        return "Eu sei que fará. Eu estou a caminho. Como chego até vocês?";
                                    case 9:
                                        currentPortraitId = 2;
                                        return "Você precisa entrar na cidade e encontrar a entrada do metrô. A base da resistência fica no subsolo.";
                                    case 10:
                                        currentPortraitId = 2;
                                        return "A cidade está cheia de soldados do governo, Quilla... Eles estabeleceram um perímetro para nenhum de nós escapar!";
                                    case 11:
                                        currentPortraitId = 0;
                                        return "Não se preocupe, vou fazer o possível para lidar com eles. Encontro você quando encontrar a entrada do metrô. Fique " +
                                            "em segurança, querida.";
                                    case 12:
                                        currentPortraitId = 2;
                                        return "Eu... Eu...";
                                    case 13:
                                        currentPortraitId = 2;
                                        return "Certo! Você também! E obrigada!";

                                    default: return null;
                                }
                            case 3:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return "...";
                                    case 2:
                                        currentPortraitId = 1;
                                        return "A maneira que você trata esta garota é notável, agente.";
                                    case 3:
                                        currentPortraitId = 0;
                                        return "Ela precisa da minha ajuda, operador.";
                                    case 4:
                                        currentPortraitId = 1;
                                        return "Sim, mas é apenas isso?";
                                    case 5:
                                        currentPortraitId = 0;
                                        return "...";
                                    case 6:
                                        currentPortraitId = 0;
                                        return "Ela... Ela me lembra da minha filha.";
                                    case 7:
                                        currentPortraitId = 1;
                                        return "...";
                                    case 8:
                                        currentPortraitId = 0;
                                        return "Eu... Já te contei sobre ela, operador?";
                                    case 9:
                                        currentPortraitId = 1;
                                        return "Sim, agente. Mas discutir relações pessoais do passado não é o foco de sua missão.";
                                    case 10:
                                        currentPortraitId = 0;
                                        return "Você tem razão...";
                                    case 11:
                                        currentPortraitId = 0;
                                        return "Vamos continuar, tenho que encontrar a entrada do metrô e chegar na base da resistência.";

                                    default: return null;
                                }

                            default: return null;
                        }

                    default: return null;
                }

            //Level 2 dialogues
            case 2:
                switch (chatId)
                {
                    //Intro city
                    case 1:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 2;
                                        return ("Quilla, você precisa encontrar a entrada do metrô! É onde fica a nossa base!");

                                    case 2:
                                        currentPortraitId = 0;
                                        return ("Tem muito entulho e obstáculos por aqui, acho que vou ter de entrar em algumas construções para atravessar a cidade.");

                                    case 3:
                                        currentPortraitId = 2;
                                        return ("E tome cuidado para não danificar sua máscara, o ar desse lugar não é respirável.");

                                    case 4:
                                        currentPortraitId = 0;
                                        return ("Não precisa se preocupar com isso, como está sua situação por aí?");

                                    case 5:
                                        currentPortraitId = 2;
                                        return ("Estou ouvindo um barulho mecânico muito alto lá fora! Eu acho que o exército está preparando algum tipo de armamento novo!");

                                    case 6:
                                        currentPortraitId = 0;
                                        return ("Mantenha-se em segurança, Reina. Os outros membros da Resistência estão contando com você.");

                                    default: return null;

                                }
                            default: return null;
                        }

                    //First soldier encounter
                    case 2:
                        switch (sectionId)
                        {

                            case 1:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return ("Você está prestes a lidar com soldados do novo governo, agente. Sugiro cautela.");

                                    case 2:
                                        currentPortraitId = 0;
                                        return ("Não tenho escolha, tenho de derrotá-los para chegar até Reina.");

                                    default: return null;
                                }

                            case 2:
                                switch (lineId)
                                {
                                    case 1:
                                        currentPortraitId = 1;
                                        return ("As armas do exército são especialmente perigosas. Sugiro encontrar cobertura toda vez que engajar estes soldados.");

                                    case 2:
                                        currentPortraitId = 0;
                                        return ("Vou ficar de olho. Não vai ser hoje que vou morrer.");

                                    default: return null;

                                }

                            default: return null;
                        }

                    //Park
                    case 3:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {
                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Este lugar... Completamente tomado pela arma química...");

                                    case 2:

                                        currentPortraitId = 0;
                                        return ("Tem... Tem brinquedos e pertences de crianças espalhados por... Toda a parte...");
                                    case 3:

                                        currentPortraitId = 1;
                                        return ("...");
                                    case 4:

                                        currentPortraitId = 0;
                                        return ("Como foram capazes disso?!");

                                    default: return null;
                                }

                            case 2:
                                switch (lineId)
                                {
                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Reina, está aí?");

                                    case 2:

                                        currentPortraitId = 2;
                                        return ("Sim, o que foi Quilla?");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("Estou próxima de um bairro residencial. Muitos inocentes foram mortos por essa névoa tóxica maldita.");

                                    case 4:

                                        currentPortraitId = 2;
                                        return ("Eu... Eu sei disso, Quilla...");

                                    default: return null;

                                }

                            case 3:
                                switch (lineId)
                                {
                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Meu operador disse que o governo não foi responsável por esta arma.");

                                    default: return null;
                                }

                            case 4:
                                switch (lineId)
                                {
                                    case 1:

                                        currentPortraitId = 2;
                                        return ("...");

                                    default: return null;

                                }

                            case 5:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Reina?");

                                    default: return null;
                                }

                            case 6:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 2;
                                        return ("Você...Disse operador? Eu... Eu não sabia que você tinha um operador...");

                                    case 2:

                                        currentPortraitId = 0;
                                        return ("Você sabe quem criou a arma, Reina?");

                                    default: return null;

                                }

                            case 7:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 2;
                                        return ("...");

                                    default: return null;
                                }

                            case 8:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Reina?!");

                                    default: return null;
                                }
                            case 9:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 1;
                                        return ("A conexão foi perdida, agente.");

                                    case 2:

                                        currentPortraitId = 0;
                                        return ("...");

                                    default: return null;
                                }

                            default: return null;
                        }

                    //Hospital victims
                    case 4:
                        switch (sectionId)
                        {

                            case 1:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Estas mortes são recentes... O que aconteceu com elas, operador?");

                                    case 2:

                                        currentPortraitId = 1;
                                        return ("Alguns corpos têm ferimentos causados por disparos, mas a maioria das mortes foram causadas por dilaceradores.");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("Um grupo de sobreviventes é muito raro nestes dias. Parece que estavam sendo perseguidos pelos soldados.");

                                    case 4:

                                        currentPortraitId = 1;
                                        return ("Eles foram encurralados no hospital e os dilaceradores terminaram o serviço.");

                                    default: return null;
                                }

                            case 2:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("...");

                                    case 2:

                                        currentPortraitId = 1;
                                        return ("Encontre uma saída, agente, este lugar não é nem um pouco seguro.");

                                    default: return null;

                                }

                            default: return null;
                        }

                    //Barricade
                    case 5:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Esta barricada parece recente. Os soldados que a construíram?");

                                    case 2:

                                        currentPortraitId = 1;
                                        return ("Agora sabemos o porquê os sobreviventes no hospital não conseguiram escapar dos dilaceradores.");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("Malditos! Eles bloquearam a saída e deixaram aquelas pessoas serem cortadas vivas?!");

                                    case 4:

                                        currentPortraitId = 1;
                                        return ("Uma maneira eficiente de economizar munição.");

                                    case 5:

                                        currentPortraitId = 0;
                                        return ("Como você pode dizer uma coisa dessas, operador?!");

                                    case 6:

                                        currentPortraitId = 1;
                                        return ("...");

                                    case 7:

                                        currentPortraitId = 1;
                                        return ("Você está apresentando um comportamento bastante empático, agente. Tomarei nota e evitarei comentários como estes no futuro.");

                                    default: return null;
                                }

                            default: return null;
                        }

                    //Military complex
                    case 6:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 2;
                                        return ("Você... Você está se aproximando, Quilla.");

                                    case 2:

                                        currentPortraitId = 2;
                                        return ("Eu... Eu sinto muito...Eu...");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("Reina, me escute. No momento o importante é eu chegar até você. Discutiremos outros assuntos quando você estiver em segurança.");

                                    case 4:

                                        currentPortraitId = 2;
                                        return ("...");

                                    case 5:

                                        currentPortraitId = 2;
                                        return ("Obrigada... Eu estou vendo sua localização... Você está próxima do complexo militar do governo...");

                                    default: return null;
                                }

                            case 2:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Sim, estou vendoo lugar. E acho que vou ter que entrar pela porta da frente.");

                                    case 2:

                                        currentPortraitId = 2;
                                        return ("Tome cuidado. Eles possuem máquinas de guerra perigosas nesse lugar!");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("Porcaria... A entrada do metrô é muito distante daqui?");

                                    case 4:

                                        currentPortraitId = 2;
                                        return ("Não! Ela está logo depois do...");

                                    default: return null;
                                }

                            case 3:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Reina? Consegue me ouvir?");

                                    case 2:

                                        currentPortraitId = 3;
                                        return ("Então é nessa frequência que você está se comunicando com seus amiguinhos, ratazana?");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("General Narus!");

                                    case 4:

                                        currentPortraitId = 3;
                                        return ("Admito que a subestimei muito. Você não é igual os outros vermes da Resistência. Todos os homens que matou até agora... Você vai pagar.");

                                    case 5:

                                        currentPortraitId = 0;
                                        return ("E você será o próximo!");

                                    case 6:

                                        currentPortraitId = 3;
                                        return ("Serei? Vamos ver se você é realmente uma boa ratazana e consegue se esgueirar pelo complexo mais bem defendido dessa cidade!" +
                                            " Meus homens estão esperando por você!");

                                    case 7:

                                        currentPortraitId = 3;
                                        return ("Quem sabe? Se você conseguir, talvez consiga chegar a tempo de me ver pessoalmente estrangulando aquela garota maldita.");

                                    case 8:

                                        currentPortraitId = 0;
                                        return ("Não ouse tocar nela! Eu vou te matar, seu desgraçado!");

                                    case 9:

                                        currentPortraitId = 3;
                                        return ("Confesso que uma parte de mim quer que você sobreviva, já que estou louco para testar meu brinquedo novo em um lixo da Resistência." +
                                            " Você será o camundongo perfeito!");

                                    default: return null;
                                }

                            case 4:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Aquele... Aquele miserável! Eu vou garantir que ele tenha uma morte horrenda!");

                                    case 2:

                                        currentPortraitId = 1;
                                        return ("...");

                                    case 3:

                                        currentPortraitId = 1;
                                        return ("Eu... Eu não esperava esta reação vinda de você, agente. Todo esse comportamento é por causa da ameaça à vida da garota?");

                                    case 4:

                                        currentPortraitId = 0;
                                        return ("Tenho de chegar até eles o mais rápido possível! Reina está em perigo!");

                                    case 5:

                                        currentPortraitId = 1;
                                        return ("Definitivamente.");

                                    default: return null;
                                }

                            default: return null;
                        }

                    //Puzzle
                    case 7:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 1;
                                        return ("Agente, a saída desta seção está fechada eletronicamente. Você precisa encontrar uma maneira de a destrancar.");

                                    default: return null;
                                }

                            case 2:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 1;
                                        return ("Acredito que possa encontrar todos os interruptores necessários para abrir a porta nesta seção," +
                                            " mas eles só ficam ativados por um tempo limitado, você terá de ser rápida.");

                                    case 2:

                                        currentPortraitId = 0;
                                        return ("Esse lugar maldito é uma armadilha!" +
                                            " Não acredito que vou ter que brincar de apertar botões enquanto aquele desgraçado está colocando a vida de Reina em perigo!");

                                    case 3:

                                        currentPortraitId = 1;
                                        return ("Não existe outro caminho, agente. Se apresse.");

                                    default: return null;
                                }

                            default: return null;
                        }

                    //Tank ahead
                    case 8:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 1;
                                        return ("Estou recebendo a leitura de um tanque a frente, agente. É um obstáculo preocupante.");

                                    default: return null;
                                }

                            case 2:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Droga! Eu estou tão perto! A entrada do metrô fica logo depois!");

                                    default: return null;
                                }

                            case 3:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 1;
                                        return ("Essa parece ser outra armadilha... O caminho até ele é um túnel cheio de vazamentos de gás." +
                                            " Creio que você terá de eliminar a ameaça antes de prosseguir.");

                                    case 2:

                                        currentPortraitId = 0;
                                        return ("Eu não tenho escolha." +
                                            " Se Narus realmente tem uma surpresa me esperando no final do trajeto, preciso destruir esse tanque, ou vou ter que lidar com os dois problemas juntos depois...");

                                    case 3:

                                        currentPortraitId = 1;
                                        return ("Analise a situação e prossiga com cautela.");

                                    default: return null;
                                }

                            default: return null;
                        }

                    //Metro entrance
                    case 9:
                        switch (sectionId)
                        {
                            case 1:
                                switch (lineId)
                                {

                                    case 1:

                                        currentPortraitId = 0;
                                        return ("Reina... Eu estou chegando.");

                                    case 2:

                                        currentPortraitId = 1;
                                        return ("Sua missão está terminando, agente. Agora só faltam dois passos.");

                                    case 3:

                                        currentPortraitId = 0;
                                        return ("O primeiro deles é eliminar aquele maldito do Narus! Osegundo vai ser finalmente encontrar a Reina!");

                                    case 4:

                                        currentPortraitId = 1;
                                        return ("Sim, agente. Exatamente.");

                                    default: return null;

                                }

                            default: return null;
                        }

                    default: return null;
                }

            default:
                return null;


        }
    }

    public static string RetrieveComment(int level, int chatId, int lineId)
    {
        switch (level)
        {
            case 1:
                switch (chatId)
                {
                    //Quilla leaves bunker through left
                    case 1:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 1;
                                return ("A base da resistência não fica nesta direção, agente.");
                            case 2:
                                currentPortraitId = 0;
                                return ("Mas talvez possamos encontrar algo de útil nesta direção.");
                            case 3:
                                currentPortraitId = 1;
                                return ("É sua decisão, mas se atente à importância de sua tarefa.");
                            case 4:
                                currentPortraitId = 1;
                                return ("Explore o ambiente com cuidado, você pode encontrar munição e outros recursos.");
                            default: return null;
                        }
                    //Abandoned camp    
                    case 2:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 0;
                                return ("Um acampamento abandonado... O que será que aconteceu com seus antigos habitantes?");
                            case 2:
                                currentPortraitId = 1;
                                return "Procure por documentos deixados por sobreviventes. Estas perguntas podem ser respondidas.";

                            default: return null;
                        }
                    //Outpost 
                    case 3:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 0;
                                return "Um posto avançado da Resistência? Me parece abandonado...";
                            case 2:
                                currentPortraitId = 1;
                                return "É comum encontrar suprimentos em lugares como estes.";
                            case 3:
                                currentPortraitId = 0;
                                return "Hm... Talvez eu consiga ter uma boa visão do terreno no topo da torre?";

                            default: return null;
                        }
                    //Radioactive swamp 
                    case 4:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 0;
                                return "O que aconteceu com este lugar?";
                            case 2:
                                currentPortraitId = 1;
                                return "O ambiente foi profundamente afetado pela guerra. A radiação dizimou a flora e a fauna.";

                            default: return null;
                        }
                    //Landmines 
                    case 5:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 1;
                                return "Minas terrestres, agente. Tente não correr pela área.";
                            case 2:
                                currentPortraitId = 0;
                                return "Seria ótimo se os dilaceradores as ativassem...";
                            case 3:
                                currentPortraitId = 0;
                                return "Hm... Mas eles não são imunes as explosões delas...";

                            default: return null;
                        }
                    //Upgrade found 
                    case 6:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 1;
                                return "Esta é uma melhoria valiosa para seu revólver agente.";
                            case 2:
                                currentPortraitId = 0;
                                return "Devo ficar atenta. Talvez eu consiga encontrar mais peças como esta em outros lugares.";

                            default: return null;
                        }
                    //Biologist's corpse 
                    case 7:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 0;
                                return "Um cientista morto? O que ele estava fazendo aqui?";
                            case 2:
                                currentPortraitId = 1;
                                return "A análise médica indica fraturas ósseas nas pernas, mas a morte ocorreu por hemorragia causada por dilacerações.";
                            case 3:
                                currentPortraitId = 0;
                                return "Os dilaceradores pegaram ele, aí ele rastejou até aqui...";
                            case 4:
                                currentPortraitId = 1;
                                return "Esta completamente desarmado. Ele não deveria ter se exposto aos perigos do deserto.";
                            case 5:
                                currentPortraitId = 0;
                                return "Tenha um pouco de respeito com os mortos, operador.";
                            case 6:
                                currentPortraitId = 1;
                                return "...";
                            case 7:
                                currentPortraitId = 1;
                                return "Tomarei nota de seus sentimentos, agente.";

                            default: return null;
                        }
                    //Battlefield
                    case 8:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 0;
                                return "Tantos destroços e máquinas de guerra quebradas... Um grande confronto aconteceu aqui.";
                            case 2:
                                currentPortraitId = 1;
                                return "Fique atenta para uma possível emboscada. Inimigos podem estar escondidos entre os detritos.";

                            default: return null;
                        }
                    //Rifle ammo found
                    case 9:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 1;
                                return "Esta munição não é compatível com seu equipamento atual, agente.";
                            case 2:
                                currentPortraitId = 0;
                                return "Sim, mas talvez eu consiga encontrar um fuzil em bom estado no futuro. Vou ficar com ela.";

                            default: return null;
                        }
                    //Religious survivor's corpse
                    case 10:
                        switch (lineId)
                        {
                            case 1:
                                currentPortraitId = 0;
                                return "Essa pessoa já morreu a muito tempo.";
                            case 2:
                                currentPortraitId = 1;
                                return "A análise médica indica um adolescente do sexo masculino morto por inanição.";
                            case 3:
                                currentPortraitId = 0;
                                return "Hm... E este santuário? Que lugar incomum, o que o garoto fazia aqui?";
                            case 4:
                                currentPortraitId = 1;
                                return "...";
                            case 5:
                                currentPortraitId = 0;
                                return "Espero que tenha encontrado o que procurava.";

                            default: return null;
                        }

                    default:
                        return null;

                }

            case 2:
                switch (chatId)
                {
                    //Traffic jam
                    case 1:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 0;
                                return ("Quantos carros. Parece que as pessoas tentaram fazer o possível para escapar desse lugar.");

                            case 2:

                                currentPortraitId = 1;
                                return ("Os civis entraram em pânico quando ocorreu o vazamento da arma química. Como o maior impacto aconteceu na cidade, muitos morreram.");

                            case 3:

                                currentPortraitId = 0;
                                return ("Como o governo foi capaz disso?");

                            case 4:

                                currentPortraitId = 1;
                                return ("A arma química não foi lançada pelo governo, agente.");

                            case 5:

                                currentPortraitId = 0;
                                return ("Eu... Eu não sabia disso...");

                            default: return null;

                        }

                    //Welcome sign
                    case 2:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 0;
                                return ("Essa placa é um tanto apropriada vendo o estado desse lugar.");

                            case 2:

                                currentPortraitId = 1;
                                return ("A revolta da população precede a guerra por muito tempo, agente. Esta pichação é extremamente antiga.");

                            case 3:

                                currentPortraitId = 0;
                                return ("Será que as coisas teriam sido diferentes se Narus não tivesse existido?");

                            case 4:

                                currentPortraitId = 1;
                                return ("Os arquivos indicam que Narus foi eleito democraticamente ao posto de presidente, agente.");

                            default: return null;
                        }

                    //Gas leak
                    case 3:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 1;
                                return ("Estou identificando vazamentos de gás combustível em muitos lugares desta região, agente.");

                            case 2:

                                currentPortraitId = 0;
                                return ("Droga. Qualquer disparo vai ser suficiente para iniciar uma explosão. Tenho que evitar tiroteios dentro destas áreas.");

                            default: return null;

                        }

                    //Soldier's corridor
                    case 4:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 1;
                                return ("A leitura indica uma grande quantidade de soldados no corredor a sua direita, agente. Um engajamento direto não é aconselhável.");

                            case 2:

                                currentPortraitId = 0;
                                return ("Talvez tenha outro caminho. Posso tentar subir mais um pouco.");

                            default: return null;
                        }

                    //Hospital leaks
                    case 5:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 1;
                                return ("Agente, a parte inferior do hospital está completamente preenchida por gás combustível. Evite usar armas de fogo enquanto estiver aqui embaixo.");

                            case 2:

                                currentPortraitId = 1;
                                return ("E este não é o único problema. Estou detectando múltiplas leituras de oscilantes dilaceradores no local.");

                            case 3:

                                currentPortraitId = 0;
                                return ("Ótimo. Parece que os soldados do governo não fizeram uma boa limpeza desse lugar. Vai ser um problema sair daqui.");

                            default: return null;
                        }

                    //Tunnels
                    case 6:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 0;
                                return ("Estes túneis não são naturais.");

                            case 2:

                                currentPortraitId = 1;
                                return ("Dilaceradores são exímios escavadores. Quando se movem pelo substrato, eles deixam túneis como estes.");

                            case 3:

                                currentPortraitId = 0;
                                return ("Eles devem ter descoberto os sobreviventes se escondendo no hospital e os pegaram de surpresa.");

                            case 4:

                                currentPortraitId = 1;
                                return ("Os assassinos perfeitos. É tarde demais para fugir quando eles aparecem.");

                            default: return null;

                        }

                    //Hideout
                    case 7:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 1;
                                return ("A Resistência estocava suprimentos em lugares escondidos como este, no começo da guerra.");

                            case 2:

                                currentPortraitId = 0;
                                return ("É estranho pensar que pessoas viviam com explosivos estocados alguns metros abaixo de suas casas.");

                            case 3:

                                currentPortraitId = 1;
                                return ("Um comportamento irresponsável dos rebeldes. Muitos acidentes foram causados por práticas como estas.");

                            default: return null;
                        }

                    //Truck crash
                    case 8:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 0;
                                return ("Um fuzil em bom estado...");

                            case 2:

                                currentPortraitId = 1;
                                return ("Um achado bem raro. Estas armas de assalto possuem grande capacidade de munição e disparam muito rápido.");

                            case 3:

                                currentPortraitId = 0;
                                return ("Vai ser bem útil. Vou cuidar bem dele.");

                            default: return null;
                        }

                    //Filled cemetery
                    case 9:
                        switch (lineId)
                        {

                            case 1:

                                currentPortraitId = 0;
                                return ("Esse cemitério me lembra o começo da guerra... Quando as baixas começaram a aumentar, as pessoas tiveram de começar a ser enterradas em covas coletivas.");

                            case 2:

                                currentPortraitId = 1;
                                return ("Esta memória... É marcante para você, agente?");

                            case 3:

                                currentPortraitId = 0;
                                return ("O que quer dizer?");

                            case 4:

                                currentPortraitId = 1;
                                return ("Desconsidere minha curiosidade. Tome o tempo que achar necessário para refletir, agente.");

                            default: return null;
                        }

                    default: return null;


                }

            default: return null;
        }
    }
}
