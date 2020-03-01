using System;

namespace Domain
{
    public class Ticket
    {
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }      
       
        public string City { get; set; }
        public string Reporter { get; set; }
        public string Severity { get; set; }
        
       
    }
}