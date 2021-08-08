using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace CommanderGQL.Models
{
    //annotation or code first => PlatformType.cs
    //[GraphQLDescription("Request any software or service that has a platform interface")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; }

    }
}