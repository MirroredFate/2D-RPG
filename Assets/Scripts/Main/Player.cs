using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Name and the Players Level
    string playerName; 
    int level;

    //HP
    int currentHP, maxHP;

    //Mana
    int currentMana, maxMana;

    //Gold / Currencies
    int gold;

    //Offensive Stats
    int intelligence, strength, dexterity;
    int criticalHitChance, criticalHitDamage;

    //Defensive Stats
    int armor, vitality, dodgeRating;

    //Elemental Resistances
    int fireResistance, grassResistance, waterResistance, lightResistance, darkResistance;

    #region Setter

    public void SetPlayerName(string name){
        this.playerName = name;
    }

    public void SetLevel(int level){
        this.level = level;
    }

    public void SetCurrentHP(int amount){
        this.currentHP = amount;
    }

    public void SetMaxHP(int amount){
        this.maxHP = amount;
    }

    public void SetCurrentMana(int amount){
        this.currentMana = amount;
    }

    public void SetMaxMana(int amount){
        this.maxMana = amount;
    }

    public void SetGold(int amount){
        this.gold = amount;
    }

    public void SetIntelligence(int amount){
        this.intelligence = amount;
    }

    public void SetStrength(int amount){
        this.strength = amount;
    }

    public void SetDexterity(int amount){
        this.dexterity = amount;
    }

    public void SetCriticalHitChance(int amount){
        this.criticalHitChance = amount;
    }

    public void SetCriticalHitDamage(int amount){
        this.criticalHitDamage = amount;
    }

    public void SetArmor(int armor){
        this.armor = armor;
    }

    public void SetVitality(int amount){
        this.vitality = amount;
    }

    public void SetDodgeRating(int amount){
        this.dodgeRating = amount;
    }

    public void SetFireResistance(int amount){
        this.fireResistance = amount;
    }

    public void SetGrassResistance(int amount){
        this.grassResistance = amount;
    }

    public void SetWaterResistance(int amount){
        this.waterResistance = amount;
    }

    public void SetLightResistance(int amount){
        this.lightResistance = amount;
    }

    public void SetDarkResistance(int amount){
        this.darkResistance = amount;
    }


    #endregion    

    #region Getter

    public string GetPlayerName(){
        return playerName;
    }

    public int GetLevel(){
        return level;
    }

    public int GetCurrentHP(){
        return currentHP;
    }

    public int GetMaxHP(){
        return maxHP;
    }

    public int GetCurrentMana(){
        return currentMana;
    }

    public int GetMaxMana(){
        return maxMana;
    }

    public int GetGold(){
        return gold;
    }

    public int GetIntelligence(){
        return intelligence;
    }

    public int GetStrength(){
        return strength;
    }

    public int GetDexterity(){
        return dexterity;
    }

    public int GetCriticalHitChance(){
        return criticalHitChance;
    }

    public int GetCriticalHitDamage(){
        return criticalHitDamage;
    }

    public int GetArmor(){
        return armor;
    }

    public int GetVitality(){
        return vitality;
    }

    public int GetDodgeRating(){
        return dodgeRating;
    }  

    public int GetFireResistance(){
        return fireResistance;
    }

    public int GetGrassResistance(){
        return grassResistance;
    }

    public int GetWaterResistance(){
        return waterResistance;
    }

    public int GetLightResistance(){
        return lightResistance;
    }

    public int GetDarkResistance(){
        return darkResistance;
    }


    #endregion

    
}
