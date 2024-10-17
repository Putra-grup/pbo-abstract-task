using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
     
        RobotBiasa robot1 = new RobotBiasa("Nexus", 120, 30, 40);
        RobotBiasa robot2 = new RobotBiasa("Taiga", 125, 20, 55);

        BosRobot bos = new BosRobot("Justice", 200, 40, 50);

        robot1.CetakInformasi();
        robot2.CetakInformasi();
        bos.CetakInformasi();

        robot1.Serang(robot2);
        robot2.Serang(bos);

        Perbaikan perbaikan = new Perbaikan();
        SeranganListrik seranganListrik = new SeranganListrik();
        SeranganPlasma seranganpPlasma = new SeranganPlasma();
        PertahananSuper pertahananSuper = new PertahananSuper();

        robot1.GunakanKemampuan(perbaikan);
        robot2.GunakanKemampuan(seranganListrik);
        robot1.GunakanKemampuan(seranganpPlasma);
        bos.GunakanKemampuan(pertahananSuper);

        robot2.Serang(bos);
        robot2.Serang(bos);
    }
}
public abstract class Robot
{
    public string nama;
    public int energi;
    public int armor;
    public int serangan;

    public Robot(string nama, int energi, int armor, int serangan)
    {
        this.nama = nama;
        this.energi = energi;
        this.armor = armor;
        this.serangan = serangan;
    }

    public abstract void Serang(Robot target);
    public abstract void GunakanKemampuan(Kemampuan kemampuan);
    public abstract void Mati();

    // Mengatur output informasi robot agar lebih rapi
    public void CetakInformasi()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine($"Robot Name : {nama}");
        Console.WriteLine($"Energy     : {energi}");
        Console.WriteLine($"Armor      : {armor}");
        Console.WriteLine($"Damage     : {serangan}");
        Console.WriteLine("=====================================");
    }
}

// Class Bos Robot, turunan dari Robot
public class BosRobot : Robot
{
    public BosRobot(string nama, int energi, int armor, int serangan) : base(nama, energi, armor, serangan) { }

    public override void Serang(Robot target)
    {
        int damage = serangan - target.armor;
        if (damage < 0) damage = 0;
        target.energi -= damage;
        Console.WriteLine($"{nama} menyerang {target.nama} dengan damage {damage}\n" +
            $"Energi {target.nama} sekarang: {target.energi}");
        Console.WriteLine($"===========================================================================");

        if (target.energi <= 0)
        {
            target.Mati();
        }
    }

    public override void GunakanKemampuan(Kemampuan kemampuan)
    {
        kemampuan.Gunakan(this);
    }

    public override void Mati()
    {
        Console.WriteLine($"{nama} telah mati.");
    }
}

// Class RobotBiasa, turunan dari Robot
public class RobotBiasa : Robot
{
    public RobotBiasa(string nama, int energi, int armor, int serangan) : base(nama, energi, armor, serangan) { }

    public override void Serang(Robot target)
    {
        int damage = serangan - target.armor;
        if (damage < 0) damage = 0;
        target.energi -= damage;
        Console.WriteLine($"{nama} menyerang {target.nama} dengan damage {damage}\n" +
            $"Energi {target.nama} sekarang: {target.energi}");
        Console.WriteLine($"===========================================================================");

        if (target.energi <= 0)
        {
            target.Mati();
        }
    }

    public override void GunakanKemampuan(Kemampuan kemampuan)
    {
        kemampuan.Gunakan(this);
    }

    public override void Mati()
    {
        Console.WriteLine($"{nama} telah mati.");
    }
}

// Interface untuk kemampuan
public interface Kemampuan
{
    void Gunakan(Robot robot);
}

// Implementasi beberapa kemampuan
public class Perbaikan : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        robot.energi += 20;
        Console.WriteLine($"{robot.nama} menggunakan Perbaikan, memulihkan energi sebanyak {robot.energi}");
        Console.WriteLine($"===========================================================================");
    }
}

public class SeranganListrik : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        Console.WriteLine($"{robot.nama} menggunakan Serangan Listrik, memberikan efek listrik pada lawan!");
        Console.WriteLine($"===========================================================================");
    }
}

public class SeranganPlasma : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        Console.WriteLine($"{robot.nama} menggunakan Serangan Plasma yang menembak hingga menembus armor lawan!");
        Console.WriteLine($"===========================================================================");
    }
}

public class PertahananSuper : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        robot.armor += 10;
        Console.WriteLine($"{robot.nama} menggunakan Super Shield, meningkatkan kekuatan armor menjadi {robot.armor}");
        Console.WriteLine($"===========================================================================");
    }
}
