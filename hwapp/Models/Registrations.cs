using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hwapp.Models
{
    public partial class Registrations
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^(([Aa][EeLlKkSsZzRr])|([Cc][AaOoTt])|([Dd][EeCc])|([Ff][MmLl])|([Gg][AaUu])|([Hh][Ii])|([Ii][DdLlNnAa])|([Kk][SsYy])|([Ll][Aa])|([Mm][EeHhDdAaIiNnSsOoTt])|([Nn][EeVvHhJjMmYyCcDd])|([Mm][Pp])|([Oo][HhKkRr])|([Pp][WwAaRr])|([Rr][Ii])|([Ss][CcDd])|([Tt][NnXx])|([Uu][Tt])|([Vv][TtIiAa])|([Ww][AaVvIiYy]))$", ErrorMessage = "Invalid State")]
        public string State { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        public DateTime Date { get; set; }
    }
}
