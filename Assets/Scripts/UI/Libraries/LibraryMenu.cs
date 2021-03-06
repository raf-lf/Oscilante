using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LibraryMenu
{
    public static string ReturnUpgradeInfo(bool ignoraAvaiability, bool returnTitle, int upgradeId)
    {
        if (returnTitle)
        {
            if (GameManager.weaponUpgrades[upgradeId])
            {
                switch (upgradeId)
                {
                    case 0: return "Pente Duplo";
                    case 1: return "Cano Tripartido";
                    case 2: return "Propulsor Magnético";
                    case 3: return "Canhão Iônico";
                    case 4: return "Instinto Assassino";
                    default: return null;
                }
            }
            else return "Melhoria Não-Encontrada";
        }
        else
        {
            if (GameManager.weaponUpgrades[upgradeId])
            {
                switch (upgradeId)
                {
                    case 0: return 
                            "Pente especial para armas de fogo secundária, fábricado para as forças do novo governo. Além de possuir uma capacidade de munição aumentada, " +
                            "aumenta a eficiência dos disparos, fazendo com que mais munição possa ser aproveitada de cada clipe usado em uma recarga. \n\n " +
                            "Aumenta de 6 para 10 a quantidade de munição que cabe em um único clipe da pistola. Clipes de pistola também passam a conter 4 disparos adicionais.";
                    case 1: return "";
                    case 2: return "Propulsor magnético prototipado por engenheiros militares do novo governo que pode ser instalado em um fuzil. Disparos são impulsionados por " +
                            "magnetismo para aumentar seu impacto. A tecnologia ainda não foi aperfeiçoada, então o propulsor tem apenas uma chance baixa de funcionar. \n\n" +
                            "Disparos tem 15 % de ter sua velocidade aumentada e causar dano adicional.";
                    case 3: return "";
                    case 4: return "";
                    default: return null;
                    }
                }
            else return "A melhoria para esta arma ainda não foi encontrada.";
        }
    }

    public static string ReturnMedalInfo(bool returnTitle, int medalId)
    {
        if (returnTitle)
        {
            if (GameManager.medals[medalId])
            {
                switch (medalId)
                {
                    case 0: return "Natureza Verdadeira";
                    case 1: return "Colecionador 5 Estrelas";
                    case 2: return "Mestre Acumulador";
                    default: return null;
                }
            }
            else return "Medalha Desconhecida";
        }
        else
        {
            if (GameManager.medals[medalId])
            {
                switch (medalId)
                {
                    case 0: return "Descobriu a verdadeira natureza de Quilla e dos oscilantes.";
                    case 1: return "Encontrou todas as armas, melhorias e documentos jogo!";
                    case 2: return "Acumulou um total de 30 recursos não usados!";
                    default: return null;
                }
            }
            else return "Medalha ainda não conquistada.";
        }
    }
    public static string LogAmmo(int weaponType, int qty)
    {
        string weaponName = "";

        switch (weaponType)
        {
            case 1:
                weaponName = "Pistola";
                break;
            case 2:
                weaponName = "Rifle";
                break;
        }

        if (qty == 1) return "Pente de munição de " + weaponName + " encontrado";
        else return qty + " pentes de munição de " + weaponName + " encontrado";

    }

    public static string LogGrenade(int qty)
    {
        if (qty == 1) return "Granada encontrada";
        else return qty + " granadas encontradas";
    }

    public static string LogHeal(int qty)
    {
        if (qty == 1) return "Cura recuperada";
        else return qty + " curas recuperadas";
    }

    public static string LogMultiple()
    {
        return "Múltiplos itens encontrados";
    }

    public static string LogWeaponPickup (int weaponId)
    {
        switch(weaponId)
        {
            case 0: return "Facão encontrado";
            case 1: return "Pistola encontrada";
            case 2: return "Fuzil encontrado";
            default: return null;

        }

    }

    public static string LogUpgrade(int upgradeId)
    {
        switch (upgradeId)
        {
            case 0: return "Melhoria de Pistola: '" + ReturnUpgradeInfo(true,true,0) + "' instalada";
            case 1: return "Modificação de Pistola: '" + ReturnUpgradeInfo(true,true, 1) + "' instalada";
            case 2: return "Melhoria de Fuzil: '" + ReturnUpgradeInfo(true, true, 2) + "' instalada";
            case 3:  return "Modificação de Fuzil: '" + ReturnUpgradeInfo(true, true, 3) + "' instalada";
            case 4: return "Melhoria Corpo-a-corpo: '" + ReturnUpgradeInfo(true, true, 4) + "' instalada";
            default: return null;
        }
    }
    public static string LogDocument(string documentName)
    {
        return "Documento '" + documentName + "' encontrado";

    }
    public static string LogMedal(string medalName)
    {
        return "Medalha '" + medalName + "' conquistada!";

    }
}
