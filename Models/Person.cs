
using Newtonsoft.Json;

namespace Zadanie3_przetwarzanie_rozproszone.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; } = 0;
        [JsonProperty("salary")]
        public double Salary { get; set; } = 0;

        public Person(int id, string firstName, string lastName, int age, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}
