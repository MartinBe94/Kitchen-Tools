using System.Globalization;
using System.Xml.Linq;
KitchenAppliances kitchenappliances = new KitchenAppliances();
kitchenappliances.Meny();
abstract class Kitchen
{
    List<string> Appliances = new List<string>() { null, "Microwave oven", "Toaster", "Oven" }; //Lista av strings
    List<bool> FunctionList = new List<bool>(){true,true,true,true}; //Lista av bools
    protected int Select = 0;
    protected string Type { get; set; }
    protected string Brand { get; set; }
    protected string Function { get; set; }
    protected bool Pick { get; set; }
    protected bool IsFunctioning { get; set; }
    protected void Selection() // En metod som skickar ut en integer som matas in av användaren som felhanteras ifall om det inte är int
    {

        Console.Write("Ange val:\n> ");
        Pick = int.TryParse(Console.ReadLine(), out Select); //Kör TryParse för att se att användaren inte matar in annat än integer
        if (!Pick) //Om bool Pick är false skrivs utskrift Console.WriteLine("Ange ett tal inte annat!\n"); ut
        {
            Console.WriteLine("Ange ett tal inte annat!\n");
        }
    }
    protected void Use()// En metod som kollar igenom ifall det går att använda köksapparten med felhantering ifall om det inte är int eller för stor inmatning av användaren
    {
        Console.Write("\nVälj köksapparat:");
        try
        {
            Lista();
            Selection();
            if (FunctionList[Select]==false&& Pick == true)//Om FunctionList[Select]==false&& Pick == true skrivs Console.WriteLine("Trasig!" + Appliances[Select] + " går inte att använda!\n" ut
            {
                Console.WriteLine("Trasig!" + Appliances[Select] + " går inte att använda!\n");
            }
            else if (FunctionList[Select] == true && Pick == true)//Annars om FunctionList[Select] == true && Pick == true skrivs Console.WriteLine("Använder " + Appliances[Select]+"\n");  ut
            {
                Console.WriteLine("Använder " + Appliances[Select]+"\n");
            }
        }catch (Exception e) { Console.WriteLine("Valet finns inte med i listan!"); }
    }
    protected void Add()// En metod som hämtar string värde från en array som sedan lägger till det i Listan Appliances
    {
        string[] Kitchenappliances = { "Ange typ:\n> ", "Ange namn:\n> ", "Ange om den fungerar (j/n):\n> " };
        string[] TypeBrandFunction = { Type, Brand, Function };
        for (int i = 0; i < Kitchenappliances.Length; i++) // En for loop som går igenom två arrays 
        {
            Console.Write(Kitchenappliances[i]); //Skriver ut Kitchenappliances i ordning
            TypeBrandFunction[i] = Console.ReadLine(); //Hämtar inmatning från user
            if(TypeBrandFunction[2]=="n") //Om index 2 av TypeBrandFunction är = "n" false får IsFunctioning en false värde annars true om "j"
            { IsFunctioning = false; }
            else if(TypeBrandFunction[2] == "j") { IsFunctioning = true; }   
        }
        if (TypeBrandFunction[2] == "j" || TypeBrandFunction[2] == "n")
        {
            Appliances.Add(TypeBrandFunction[0] + " " + TypeBrandFunction[1] + " (" + TypeBrandFunction[2] + ")"); //Tilldelar en string värde till listan Appliances
            FunctionList.Add(IsFunctioning); // Tilldelar en bool värde till listan FunctionList
            Console.WriteLine(TypeBrandFunction[0] + " " + TypeBrandFunction[1] + " (" + TypeBrandFunction[2] + ")" + "Är tillagd!\n");
        }else { Console.WriteLine("felinmatning"); }
    }
    protected void Lista()// En metod som skriver ut lista i nummer ordning och string som finns i listan
    {
        Console.WriteLine();
        for (int i = 1; i < Appliances.Count; i++)// Skriver ut Appliances listan i nummer ordning
        {
            Console.Write(i + ". " + Appliances[i] + "\n");
        }
    }
    protected void Remove()// En metod som ta bort string från listan och felhantera det ifall om det inte är int eller för stor inmatning av användaren
    {
        try
        {
            Lista();
            Selection();
            if (Pick == true)
            {
                Console.WriteLine(Appliances[Select] + " är bortaggen!\n");
                Appliances.Remove(Appliances[Select]);//Ta bort den valda string värdet från Appliances listan
                FunctionList.RemoveAt(Select);//Ta bort den valda bool värdet från FunctionList listan
            }
        }catch (Exception e) { Console.WriteLine("Valet finns inte med i listan!"); }
    }
    public abstract void Meny();
}
class KitchenAppliances : Kitchen 
{
    public override void Meny()
    {   bool Continues = true; // Sålänge bool Continues är = true så körs do while loopen
        do //En do while loop som loopar om Meny ifall om användaren inte matar in 5
        {   Console.Write("========KÖKET========\n1. Använd köksapparat\n2. Lägg till köksapparat\n3. Lista köksapparater\n4. Ta bort köksapparat\n5. Avsluta\n");
            Selection();// En metod hämtad från abstract class Kitchen som sedan ge ett värde till Select så switch case värde kan hanteras
            if (Select >= 6) { Console.WriteLine("Valet finns inte med i listan!"); }
            switch (Select)
            {
                case 1:
                    Use(); //Hämtar methoden Use(); från abstract class Kitchen
                    break;
                case 2:
                    Add(); //Hämtar methoden Add(); från abstract class Kitchen
                    break;
                case 3:
                    Lista(); //Hämtar methoden Lista(); från abstract class Kitchen
                    break;
                case 4:
                    Remove(); //Hämtar methoden Remove(); från abstract class Kitchen
                    break;
                case 5:
                    Continues = false; // Avslutar loopen
                    break;
            }
        } while (Continues); //Kör om loopen så Continues är = true
    }
}
