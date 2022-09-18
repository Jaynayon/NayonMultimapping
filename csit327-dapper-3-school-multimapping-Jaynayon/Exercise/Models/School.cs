using Newtonsoft.Json;

namespace DapperExer3.Models
{
    internal class School
    {
        // TODO: Fill with properties

        /// <summary>
        /// Prints this object as JSON
        /// </summary>
        /// <returns>json string representation of this object</returns>
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Motto { get; set; }
        public string? AverageTuition { get; set; }
        public List<College> College { get; set; } = new List<College>();
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
