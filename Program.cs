using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Controllers;

namespace TestePleno {
  class Program {
    static void Main(string[] args) {
      var fare = new Fare();
      fare.Id = Guid.NewGuid();

      var operatorCode = new Operator();

      Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
      var fareValueInput = Console.ReadLine();
      fare.Value = decimal.Parse(fareValueInput);

      Console.WriteLine("Informe o código da operadotra para a tarifa:");
      Console.WriteLine("Exemplos: OP01, OP02, OP03...");
      var operatorCodeInput = Console.ReadLine();
      
      var fareControlle = new FareController();
      fareControlle.CreateFare(fare, operatorCodeInput);

      Console.WriteLine("Tarifa cadastrada com sucesso!");
      Console.Read();
    }
  }
}